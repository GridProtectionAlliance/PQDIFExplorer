//******************************************************************************************************
//  MainWindow.cs - Gbtc
//
//  Copyright © 2015, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the MIT License (MIT), the "License"; you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://opensource.org/licenses/MIT
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  12/14/2015 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GSF;
using GSF.IO;
using GSF.PQDIF;
using GSF.PQDIF.Logical;
using GSF.PQDIF.Physical;
using PQDIFExplorer.Properties;

namespace PQDIFExplorer
{
    /// <summary>
    /// The main window of the PQDIF Explorer application.
    /// </summary>
    public partial class MainWindow : Form
    {
        #region [ Members ]

        // Fields
        private string m_filePath;
        private List<DetailsWindow> m_detailsWindows;
        private TreeNode m_previouslySelectedNode;
        private List<Exception> m_exceptionList;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            CreateRecordTree();
        }

        #endregion

        #region [ Properties ]

        private TreeView RecordTree { get; set; }

        #endregion

        #region [ Methods ]

        // Opens the given file for exploration.
        private void OpenFile(string filePath)
        {
            Record record;
            List<TreeNode> recordNodes;
            IEnumerable<List<TreeNode>> childNodes;
            ContainerRecord containerRecord;

            try
            {
                Cursor = Cursors.WaitCursor;
                m_exceptionList = new List<Exception>();
                recordNodes = new List<TreeNode>();

                // Close existing details windows
                foreach (DetailsWindow window in new List<DetailsWindow>(m_detailsWindows))
                    window.Close();

                // Refresh the tree view
                CreateRecordTree();

                // Use the physical parser to more closely display the structure of the file
                using (PhysicalParser parser = new PhysicalParser(filePath))
                {
                    parser.Open();

                    try
                    {
                        while (parser.HasNextRecord())
                        {
                            // Parse the next record
                            record = parser.NextRecord();

                            // The compression algorithm and compression style are necessary for properly parsing the file
                            // and must be obtained by parsing the logical structure of the container record
                            if (record.Header.TypeOfRecord == RecordType.Container)
                            {
                                containerRecord = ContainerRecord.CreateContainerRecord(record);
                                parser.CompressionAlgorithm = containerRecord.CompressionAlgorithm;
                                parser.CompressionStyle = containerRecord.CompressionStyle;
                            }

                            // Convert this record and all its child elements to a node for
                            // the tree view and add the node to the list of record nodes
                            recordNodes.Add(ToTreeNode(record));
                        }
                    }
                    catch (Exception e)
                    {
                        parser.ExceptionList.Add(e);
                        string message = "A fatal error occured while reading the file:\n\n" + e.Message;
                        string caption = "Exception";
                        MessageBoxButtons button = MessageBoxButtons.OK;

                        MessageBox.Show(message, caption, button, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (parser.ExceptionList.Count > parser.MaximumExceptionsAllowed)
                        {
                            parser.ExceptionList.Add(new InvalidOperationException("Maximum number of exceptions reached"));
                            string message = "Maximum number of exceptions reached.";
                            string caption = "Unable to continue";
                            MessageBoxButtons button = MessageBoxButtons.OK;

                            MessageBox.Show(message, caption, button, MessageBoxIcon.Error);
                        }
                    }

                    // If the file has has more than one record with the same
                    // type, add an index to the nodes to aid navigation
                    childNodes = recordNodes
                        .GroupBy(node => ((Record)node.Tag).Header.TypeOfRecord)
                        .Select(grouping => grouping.ToList())
                        .Where(list => list.Count > 1);

                    foreach (List<TreeNode> list in childNodes)
                    {
                        for (int i = 0; i < list.Count; i++)
                            list[i].Text = $"[{i}] {list[i].Text}";
                    }

                    // Add all record nodes to the root of the tree
                    RecordTree.Nodes.AddRange(recordNodes.ToArray());

                    m_exceptionList = parser.ExceptionList;
                }

                // Enable menu items that only work when a file is open
                OpenInNewWindowToolStripMenuItem.Enabled = true;
                SaveToolStripMenuItem.Enabled = true;
                SaveAsToolStripMenuItem.Enabled = true;
                FindToolStripMenuItem.Enabled = true;
                FindNextToolStripMenuItem.Enabled = true;
                FindPreviousToolStripMenuItem.Enabled = true;
                DetailsToolStripMenuItem.Enabled = true;
                ShowExceptionsToolStripMenuItem.Enabled = true;

                // Update the file path and window title
                Text = $"PQDIFExplorer - [{filePath}]";
                DetailsTextBox.Text = string.Empty;
                m_filePath = filePath;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Saves data to the file at the given path.
        private void SaveFile(string filePath)
        {
            using (PhysicalWriter physicalWriter = new PhysicalWriter(filePath))
            {
                foreach (TreeNode treeNode in RecordTree.Nodes)
                {
                    Record r = (Record)treeNode.Tag;

                    if (treeNode.NextNode == null)
                        physicalWriter.WriteRecord((Record)treeNode.Tag, true);
                    else
                        physicalWriter.WriteRecord((Record)treeNode.Tag);

                    if (r.Header.TypeOfRecord == RecordType.Container)
                    {
                        ContainerRecord containerRecord = ContainerRecord.CreateContainerRecord(r);
                        physicalWriter.CompressionAlgorithm = containerRecord.CompressionAlgorithm;
                        physicalWriter.CompressionStyle = containerRecord.CompressionStyle;
                    }

                    //File.AppendAllText("log2.txt", treeNode.Tag.ToString());
                }
            }

            // Saving the file may modify the information in the header of the PQIDF records
            // so update the details text box if the selected node represents a PQDIF record
            Record record = RecordTree.SelectedNode?.Tag as Record;

            if ((object)record != null)
                DetailsTextBox.Text = GetDetails(record);

            UpdateDetailsWindows();

            // Update window title and file path
            Text = $"PQDIFExplorer - [{filePath}]";
            m_filePath = filePath;
        }

        private TreeNode ToTreeNode(Record record)
        {
            TreeNode node;

            // Create a new tree node for the record
            node = new TreeNode();

            // If the record has a body, add a stub node to represent its children
            if ((object)record.Body != null)
                node.Nodes.Add(new TreeNode());

            // Use the type of the record to identify it in the tree view
            node.Text = record.Header.TypeOfRecord.ToString();

            // Set the tag of the node so that we can quickly associate
            // a selected node with the record that spawned it
            node.Tag = record;

            // Determine the icon to apply to this
            // node based on the record type
            switch (record.Header.TypeOfRecord)
            {
                case RecordType.Container:
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    break;

                case RecordType.DataSource:
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    break;

                case RecordType.MonitorSettings:
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                    break;

                case RecordType.Observation:
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 4;
                    break;

                case RecordType.Blank:
                    node.ImageIndex = 5;
                    node.SelectedImageIndex = 5;
                    break;
            }

            // Return the node that represents the record
            return node;
        }

        private TreeNode ToTreeNode(Element element)
        {
            TreeNode node;
            CollectionElement collection;
            Tag tag;

            IEnumerable<List<TreeNode>> childNodes;

            // Look up the tag and create a leaf node identified by
            // the tag name or the tag itself if no name is available
            tag = GSF.PQDIF.Tag.GetTag(element.TagOfElement);

            if ((object)tag != null)
                node = new TreeNode(tag.Name);
            else
                node = new TreeNode(element.TagOfElement.ToString());

            // Set the image of the node based on the type of the element
            switch (element.TypeOfElement)
            {
                case ElementType.Collection:
                    node.ImageIndex = 6;
                    node.SelectedImageIndex = 6;
                    break;

                case ElementType.Vector:
                    node.ImageIndex = 7;
                    node.SelectedImageIndex = 7;
                    break;

                case ElementType.Scalar:
                    node.ImageIndex = 8;
                    node.SelectedImageIndex = 8;
                    break;
            }

            // Use the error image for error elements
            if (element is ErrorElement)
            {
                node.ImageIndex = 9;
                node.SelectedImageIndex = 9;
            }

            // Use the blank image for blank elements
            if ((object)tag != null && tag.StandardName == "tagBlank")
            {
                node.ImageIndex = 5;
                node.SelectedImageIndex = 5;
            }

            // Set the tag of the node so that we can quickly associate
            // a selected node with the element that spawned it
            node.Tag = element;

            // If the element is a collection element,
            // convert each of the elements in the collection
            // into child nodes of this element's tree node
            collection = element as CollectionElement;

            if ((object)collection != null)
            {
                foreach (Element child in collection.Elements)
                    node.Nodes.Add(ToTreeNode(child));

                // If the collection element has more than
                // one child with the same tag, add an index
                // to the nodes to aid navigation
                childNodes = node.Nodes
                    .Cast<TreeNode>()
                    .GroupBy(childNode => ((Element)childNode.Tag).TagOfElement)
                    .Select(grouping => grouping.ToList())
                    .Where(list => list.Count > 1);

                foreach (List<TreeNode> list in childNodes)
                {
                    for (int i = 0; i < list.Count; i++)
                        list[i].Text = $"[{i}] {list[i].Text}";
                }
            }

            // Return the node that represents the element
            return node;
        }

        // Finds the next node in the tree that matches the find text.
        private void FindNext()
        {
            try
            {
                TreeNode startNode = RecordTree.SelectedNode ?? RecordTree.Nodes[0];
                TreeNode node = startNode;
                string findText = Regex.Escape(FindTextBox.Text);
                bool found = false;

                Cursor = Cursors.WaitCursor;

                if ((object)RecordTree.SelectedNode == null)
                    found = Regex.IsMatch(node.Text + GetDetails(node), findText, RegexOptions.IgnoreCase);

                while (!found)
                {
                    node = GetNextNode(node);
                    found = Regex.IsMatch(node.Text + GetDetails(node), findText, RegexOptions.IgnoreCase);

                    if (ReferenceEquals(node, startNode))
                        break;
                }

                if (found)
                {
                    // If the node is in a detached subtree,
                    // we must attach it before setting the selected node
                    if ((object)node.TreeView == null)
                    {
                        TreeNode ancestor = node;

                        while ((object)ancestor.Parent != null)
                            ancestor = ancestor.Parent;

                        TreeNode recordNode = (TreeNode)ancestor.Tag;
                        TreeNode[] childNodes = ancestor.Nodes.Cast<TreeNode>().ToArray();
                        ancestor.Nodes.Clear();
                        recordNode.Nodes.Clear();
                        recordNode.Nodes.AddRange(childNodes);
                    }

                    RecordTree.SelectedNode = node;
                }
                else
                {
                    MessageBox.Show($"The text '{FindTextBox.Text}' could not be found in this PQDIF file.", "Text not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Finds the prior node in the tree that matches the find text.
        private void FindPrevious()
        {
            try
            {
                TreeNode startNode = RecordTree.SelectedNode ?? RecordTree.Nodes[0];
                TreeNode node = startNode;
                string findText = Regex.Escape(FindTextBox.Text);
                bool found;

                Cursor = Cursors.WaitCursor;

                do
                {
                    node = GetPreviousNode(node);
                    found = Regex.IsMatch(node.Text + GetDetails(node), findText, RegexOptions.IgnoreCase);
                }
                while (!ReferenceEquals(node, startNode) && !found);

                if (found)
                {
                    // If the node is in a detached subtree,
                    // we must attach it before setting the selected node
                    if ((object)node.TreeView == null)
                    {
                        TreeNode ancestor = node;

                        while ((object)ancestor.Parent != null)
                            ancestor = ancestor.Parent;

                        TreeNode recordNode = (TreeNode)ancestor.Tag;
                        TreeNode[] childNodes = ancestor.Nodes.Cast<TreeNode>().ToArray();
                        ancestor.Nodes.Clear();
                        recordNode.Nodes.Clear();
                        recordNode.Nodes.AddRange(childNodes);
                    }

                    RecordTree.SelectedNode = node;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Gets the next node after the given node in an inorder traversal of the tree.
        private TreeNode GetNextNode(TreeNode currentNode)
        {
            // Next node is one of the following:
            //   1. The first child node of the current node
            //   2. If there are no child nodes, use the next sibling
            //   3. If there is no next sibling, use the next sibling
            //      of the nearest ancestor with a next sibling
            //   4. If there is no such ancestor, use the first node in the tree
            TreeNode nextNode = currentNode.FirstNode ?? currentNode.NextNode;

            if ((object)nextNode == null)
            {
                nextNode = currentNode;

                while ((object)nextNode != null && !(nextNode.Tag is TreeNode) && (object)nextNode.NextNode == null)
                    nextNode = nextNode.Parent;

                // Special case:
                // If at this point the tag of nextNode is a TreeNode,
                // that means this is the end of a detached subtree so
                // we need to move to the next node of the tree view
                nextNode = (nextNode?.Tag as TreeNode) ?? nextNode;

                nextNode = nextNode?.NextNode ?? RecordTree.Nodes[0];
            }

            // Special case:
            // If the node has no tag, it is a stub node
            // and we need to create the parent's subtree
            if ((object)nextNode.Tag == null)
            {
                TreeNode recordNode = nextNode.Parent;
                TreeNode subTree = ToTreeNode(((Record)recordNode.Tag).Body?.Collection ?? new CollectionElement());
                subTree.Tag = recordNode;
                nextNode = subTree.FirstNode;
            }

            return nextNode;
        }

        // Gets the nearest node before the given node in an inorder traversal of the tree.
        private TreeNode GetPreviousNode(TreeNode currentNode)
        {
            // Previous node is one of the following:
            //   1. The last descendant node of the previous sibling
            //   2. If there is no sibling node, use the parent node
            //   3. If there is no parent node, use the last descendant node of the last node in the tree
            TreeNode previousNode = currentNode.PrevNode ?? currentNode.Parent ?? RecordTree.Nodes[RecordTree.Nodes.Count - 1];

            // Special case:
            // If at this point the tag of previousNode is a TreeNode,
            // that means this is the beginning of a detached subtree
            // so we need to move to return to the nodes of the tree view
            TreeNode tagNode = previousNode.Tag as TreeNode;

            if ((object)tagNode != null)
                return tagNode;

            if (previousNode != currentNode.Parent)
            {
                while ((object)previousNode.LastNode != null)
                    previousNode = previousNode.LastNode;
            }

            // Special case:
            // If the node has no tag, it is a stub node
            // and we need to create the parent's subtree
            if ((object)previousNode.Tag == null)
            {
                TreeNode recordNode = previousNode.Parent;
                TreeNode subTree = ToTreeNode(((Record)recordNode.Tag).Body?.Collection ?? new CollectionElement());
                subTree.Tag = recordNode;
                previousNode = subTree.LastNode;

                while ((object)previousNode.LastNode != null)
                    previousNode = previousNode.LastNode;
            }

            return previousNode;
        }

        // Gets detailed information about the object represented by the given node.
        private string GetDetails(TreeNode node)
        {
            Record record = node.Tag as Record;
            Element element = node.Tag as Element;

            if ((object)record != null)
                return GetDetails(record);

            if ((object)element != null)
                return GetDetails(element);

            return null;
        }

        // Gets detailed information about the given record.
        private string GetDetails(Record record)
        {
            StringBuilder details = new StringBuilder();
            Tag tag;

            // Display the fields in the record's header
            details.AppendLine($"  Signature: {record.Header.RecordSignature}");
            details.AppendLine($"       Type: {record.Header.TypeOfRecord} ({record.Header.RecordTypeTag})");
            details.AppendLine($"Header Size: {record.Header.HeaderSize}");
            details.AppendLine($"  Body Size: {record.Header.BodySize}");

            if ((object)record.Body != null)
            {
                details.AppendLine($"  Read Size: {record.Body.Collection.ReadSize}");
                details.AppendLine($"   Checksum: 0x{record.Header.Checksum:X} (Computed: 0x{record.Body.Checksum:X})");
            }

            else
            {
                details.AppendLine($"  Read Size: 0");
                details.AppendLine($"   Checksum: 0x{record.Header.Checksum:X} (Computed: 0x1)");
            }

            // Look up the record's tag to display detailed
            // information about the record as defined by its tag
            tag = GSF.PQDIF.Tag.GetTag(record.Header.RecordTypeTag);

            if ((object)tag != null)
            {
                details.AppendLine();
                details.AppendLine($"-- Tag details --");
                details.AppendLine($"           Name: {tag.Name}");
                details.AppendLine($"  Standard Name: {tag.StandardName}");
                details.AppendLine($"    Description: {tag.Description}");
                details.AppendLine($"       Required: {(tag.Required ? "Yes" : "No")}");
            }

            return details.ToString();
        }

        // Gets detailed information about the given element.
        private string GetDetails(Element element)
        {
            StringBuilder details = new StringBuilder();
            Tag tag;

            // Display the value if the element is a vector or a scalar
            if (element.TypeOfElement != ElementType.Collection)
                details.AppendLine($"        Value: {ValueAsString(element)}").AppendLine();
            else
                details.AppendLine($"    Read Size: {((CollectionElement)element).ReadSize}").AppendLine();

            // Display the tag of the element and the actual type of the
            // element and its value as defined by the data in the file
            details.AppendLine($"          Tag: {element.TagOfElement}");
            details.AppendLine($" Element type: {element.TypeOfElement}");
            details.AppendLine($"Physical type: {element.TypeOfValue}");

            // Look up the element's tag to display detailed information about the element as defined
            // by its tag as well as the expected type of the element and its value based on the tag
            tag = GSF.PQDIF.Tag.GetTag(element.TagOfElement);

            if ((object)tag != null)
            {
                details.AppendLine();
                details.AppendLine($"-- Tag details --");
                details.AppendLine($"           Name: {tag.Name}");
                details.AppendLine($"  Standard Name: {tag.StandardName}");
                details.AppendLine($"    Description: {tag.Description}");
                details.AppendLine($"   Element type: {tag.ElementType}");
                details.AppendLine($"  Physical type: {tag.PhysicalType}");
                details.AppendLine($"       Required: {(tag.Required ? "Yes" : "No")}");
            }

            return details.ToString();
        }

        // Converts the value of the given element
        // to the appropriate string representation.
        private string ValueAsString(Element element)
        {
            try
            {
                return element.ValueAsString();
            }
            catch
            {
                return $"ERROR ({element.ValueAsHex()})";
            }
        }

        // Creates a new tree view and replaces the old one.
        private void CreateRecordTree()
        {
            TreeView oldTree = RecordTree;

            SplitContainer.Panel1.Controls.Clear();

            if ((object)oldTree != null)
            {
                // Create asynchronous loop to gradually dispose of
                // the old record tree so that the UI does not hang
                EventHandler disposeAction = null;

                disposeAction = (sender, args) =>
                {
                    int count = Math.Min(oldTree.Nodes.Count, 10);
                    
                    for (int i = 0; i < count; i++)
                        oldTree.Nodes.RemoveAt(oldTree.Nodes.Count - 1);

                    if (oldTree.Nodes.Count == 0)
                    {
                        Application.Idle -= disposeAction;
                        oldTree.Dispose();
                    }
                };

                Application.Idle += disposeAction;
            }

            RecordTree = new BufferedTreeView();
            RecordTree.Dock = DockStyle.Fill;
            RecordTree.Location = new Point(0, 0);
            RecordTree.Name = "RecordTree";
            RecordTree.Size = new Size(288, 545);
            RecordTree.TabIndex = 0;
            RecordTree.BeforeExpand += RecordTree_BeforeExpand;
            RecordTree.AfterSelect += RecordTree_AfterSelect;
            RecordTree.KeyDown += RecordTree_KeyDown;
            RecordTree.MouseDown += RecordTree_MouseDown;

            // Create the list of images to be displayed in the tree view
            RecordTree.ImageList = new ImageList();
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.default.png")));
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.container.png")));
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.datasource.png")));
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.monitorsettings.png")));
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.observation.png")));
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.blank.png")));
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.collection.png")));
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.vector.png")));
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.scalar.png")));
            RecordTree.ImageList.Images.Add(Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.error.png")));

            SplitContainer.Panel1.Controls.Add(RecordTree);
        }

        // Creates the context menu for the given tree node.
        private void CreateContextMenu(TreeNode node)
        {
            ToolStripMenuItem menuItem;
            Element element;

            // Add a context menu if one does not already exist
            if ((object)node == null || (object)node.ContextMenuStrip != null)
                return;

            node.ContextMenuStrip = new ContextMenuStrip();
            element = node.Tag as Element;

            if ((object)element != null && (element.TypeOfElement == ElementType.Scalar || element.TypeOfElement == ElementType.Vector))
            {
                menuItem = new ToolStripMenuItem("Edit Value");
                menuItem.Click += (sender, args) => DisplayEditDialog(element);
                node.ContextMenuStrip.Items.Add(menuItem);
            }

            menuItem = new ToolStripMenuItem("Open Details Window");
            menuItem.Click += (sender, args) => DisplayDetailsWindow(node);
            node.ContextMenuStrip.Items.Add(menuItem);
        }

        // Displays the dialog used to edit a value.
        private void DisplayEditDialog(Element element)
        {
            string value;

            using (EditDialog editDialog = new EditDialog())
            {
                editDialog.Initialize(element);

                if (editDialog.ShowDialog() != DialogResult.OK)
                    return;

                value = editDialog.Value;

                if ((object)value == null)
                    return;

                try
                {
                    element.SetValue(value);

                    if (RecordTree.SelectedNode.Tag == element)
                        DetailsTextBox.Text = GetDetails(element);

                    UpdateDetailsWindows();

                    if (!Text.EndsWith("*"))
                        Text += "*";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error setting value of PQDIF element: {ex.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Displays the given details in its own details window.
        private void DisplayDetailsWindow(TreeNode node)
        {
            DetailsWindow detailsWindow = new DetailsWindow();
            detailsWindow.Node = node;
            detailsWindow.Text = $"{node.Text} Details";
            detailsWindow.SetText(GetDetails(node));
            detailsWindow.Show();
            detailsWindow.FormClosing += (obj, args) => m_detailsWindows.Remove(detailsWindow);
            m_detailsWindows.Add(detailsWindow);
        }

        private void UpdateDetailsWindows()
        {
            foreach (DetailsWindow window in m_detailsWindows)
                window.SetText(GetDetails(window.Node));
        }

        // Fixes the scroll bars in the details view
        // based on whether the text fits inside the text box.
        private void FixScrollBars()
        {
            Size textSize = TextRenderer.MeasureText(DetailsTextBox.Text, DetailsTextBox.Font);
            bool showVertical = DetailsTextBox.ClientSize.Height < textSize.Height + Convert.ToInt32(DetailsTextBox.Font.Size);
            bool showHorizontal = DetailsTextBox.ClientSize.Width < textSize.Width;

            if (showVertical && showHorizontal)
                DetailsTextBox.ScrollBars = ScrollBars.Both;
            else if (showVertical)
                DetailsTextBox.ScrollBars = ScrollBars.Vertical;
            else if (showHorizontal)
                DetailsTextBox.ScrollBars = ScrollBars.Horizontal;
            else
                DetailsTextBox.ScrollBars = ScrollBars.None;
        }

        // Handles the case when the user double-clicks in the record tree.
        private void HandleDoubleClick()
        {
            TreeNode node;
            string details;

            // Figure out which node the user double-clicked on
            node = RecordTree.GetNodeAt(RecordTree.PointToClient(MousePosition));

            if ((object)node == null || !node.Bounds.Contains(RecordTree.PointToClient(MousePosition)))
                return;

            // Get details about the record or
            // element the user double-clicked on
            details = GetDetails(node);

            if ((object)details == null)
                return;

            // Creates a new window in which to display the details
            BeginInvoke(new Action<TreeNode>(DisplayDetailsWindow), node);

            // Cancel expand or collapse once to suppress the
            // default behavior of expand/collapse on double-click
            if (node.Nodes.Count > 0)
                CancelExpandCollapseOnce();
        }

        // Handles the case when the user right-clicks in the record tree.
        private void HandleRightClick()
        {
            // Figure out which node the user right-clicked on
            TreeNode node = RecordTree.GetNodeAt(RecordTree.PointToClient(MousePosition));

            // Add a context menu if one does not already exist
            CreateContextMenu(node);
        }

        // Cancels the next expand or collapse operation in the tree view.
        // This is used to suppress the behavior where double-clicking
        // causes a node to expand or collapse.
        private void CancelExpandCollapseOnce()
        {
            TreeViewCancelEventHandler expandCollapseHandler = null;

            expandCollapseHandler = (expandSender, args) =>
            {
                args.Cancel = true;
                RecordTree.BeforeExpand -= expandCollapseHandler;
                RecordTree.BeforeCollapse -= expandCollapseHandler;
            };

            RecordTree.BeforeExpand += expandCollapseHandler;
            RecordTree.BeforeCollapse += expandCollapseHandler;
        }
        
        // Prompts the user, asking whether they would like to save their changes to the file.
        // If the user chooses to save the changes, this writes changes to the file at the given path.
        // Returns false if the user chooses to cancel the operation that triggered the prompt.
        private bool PromptForSave(string filePath)
        {
            if (Text.EndsWith("*"))
            {
                DialogResult result = MessageBox.Show("Do you want to save your changes?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                    return false;

                if (result == DialogResult.Yes)
                    SaveFile(filePath);
            }

            return true;
        }

        // Handler called when the window loads.
        private void MainWindow_Load(object sender, EventArgs e)
        {
            string[] args;
            string file;

            m_detailsWindows = new List<DetailsWindow>();

            // Set the working directory to the executable's directory
            // so that the PQDIF library can locate TagDefinitions.xml
            Directory.SetCurrentDirectory(FilePath.GetAbsolutePath(""));

            // Set the icon used by the main window
            Icon = new Icon(typeof(MainWindow), "Icons.explorer.ico");

            // Set the GPA Lock icon in the upper right corner
            GPALockButton.Image = Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.Icons.gpalock.png"));

            // Set splash screen label image
            SplashScreenLabel.Image = Image.FromStream(typeof(MainWindow).Assembly.GetManifestResourceStream("PQDIFExplorer.SplashScreen.png"));


            // Set initial size of the form
            if (Settings.Default.WindowSize != null)
                Size = Settings.Default.WindowSize;

            args = Environment.GetCommandLineArgs();
            file = args.FirstOrDefault(arg => arg.EndsWith(".pqd", StringComparison.OrdinalIgnoreCase));

            if ((object)file != null)
                OpenFile(file);
        }

        // Handler called when the user selects the option to open a PQDIF file.
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PromptForSave(m_filePath))
                return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.DefaultExt = ".pqd";
                openFileDialog.Filter = "PQDIF Files|*.pqd|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    OpenFile(openFileDialog.FileName);
            }
        }

        // Handler called when the user selects the option to open the current PQDIF file in a new window.
        private void OpenInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = Application.ExecutablePath;
            string arguments = "\"" + m_filePath + "\"";
            using (Process.Start(fileName, arguments)) { }
        }

        // Handler called when the user selects the option to reload a PQDIF file.
        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PromptForSave(m_filePath))
                return;

            OpenFile(m_filePath);
        }

        // Handler called when the user drags files onto the window.
        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Any(file => file.EndsWith(".pqd", StringComparison.OrdinalIgnoreCase)))
                e.Effect = DragDropEffects.Copy;
        }

        // Handler called when the user drags and drops files onto the window.
        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string file = files.FirstOrDefault(f => f.EndsWith(".pqd", StringComparison.OrdinalIgnoreCase));

            if ((object)file != null)
                OpenFile(file);
        }

        // Handler called when user selects the option to open in PQDiffractor.
        private void PQDiffractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set up the collection of paths to be searched for PQDiffractor.exe.
            // This prefers the path from the configuration file, but will also search
            // "Program Files" and "Program Files(x86)" in the default install location
            string[] paths =
            {
                Settings.Default.PQDiffractorPath,
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "PQDiffractor", "PQDiffractor.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "PQDiffractor", "PQDiffractor.exe")
            };

            bool pqdiffractorNotFound = true;

            foreach (string path in paths)
            {
                try
                {
                    // Attempt to run PQDiffractor using the current path
                    using (Process.Start(path, m_filePath.QuoteWrap()))
                    {
                    }

                    // If it works okay, set this flag to false
                    pqdiffractorNotFound = false;

                    // If the file was found,
                    // no need to try any more paths
                    break;
                }
                catch
                {
                    // Ignore the exception and try the next path
                }
            }

            // If the file was not found,
            // display the PQDiffractorNotFoundWindow to the user
            if (pqdiffractorNotFound)
            {
                using (PQDiffractorNotFoundWindow window = new PQDiffractorNotFoundWindow())
                {
                    window.ShowDialog();
                }
            }
        }

        // Handler called after the user selects a node in the tree view.
        private void RecordTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string details;

            if ((object)m_previouslySelectedNode != null)
            {
                m_previouslySelectedNode.BackColor = Color.Empty;
                m_previouslySelectedNode.ForeColor = Color.Empty;
            }

            m_previouslySelectedNode = e.Node;

            if ((object)e.Node == null)
                return;

            e.Node.BackColor = SystemColors.Highlight;
            e.Node.ForeColor = SystemColors.HighlightText;

            // Get details about the record or
            // element selected in the tree view
            details = GetDetails(e.Node);

            if ((object)details == null)
                return;

            // Updates the details text box with
            // information about the selected item
            DetailsTextBox.Clear();
            DetailsTextBox.AppendText(details);
        }

        // Handler called before expanding a node in the tree view.
        private void RecordTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Record record = e.Node.Tag as Record;
            TreeNodeCollection children = e.Node.Nodes;
            
            if ((object)record != null && (object)children[0].Tag == null)
            {
                children.Clear();
                children.AddRange(record.Body.Collection.Elements.Select(ToTreeNode).ToArray());
            }
        }

        // Handler called when the user clicks on the tree view.
        private void RecordTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
                HandleDoubleClick();
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
                HandleRightClick();
        }

        // Handler called when the user uses the keyboard on the tree view.
        private void RecordTree_KeyDown(object sender, KeyEventArgs e)
        {
            TreeNode node = RecordTree.SelectedNode;

            if (e.Shift && e.KeyCode == Keys.F10 && (object)node != null)
            {
                CreateContextMenu(node);
                node.ContextMenuStrip.Show(RecordTree, node.Bounds.Location);
            }
        }

        // Handler called when the text is changed in the details text box.
        private void DetailsTextBox_TextChanged(object sender, EventArgs e)
        {
            SplashScreenLabel.Visible = string.IsNullOrEmpty(DetailsTextBox.Text);
            FixScrollBars();
        }

        // Handler called when the details text box is resized.
        private void DetailsTextBox_Resize(object sender, EventArgs e)
        {
            if (IsHandleCreated)
                BeginInvoke(new Action(FixScrollBars));
        }

        // Handler called when the user clicks on the GPA lock logo.
        private void GPALockButton_Click(object sender, EventArgs e)
        {
            using (Process.Start("http://www.gridprotectionalliance.org/"))
            {
            }
        }

        // Handler called when the user selects the Exit option in the toolbar menu.
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Handler called when the main window is closing so we can clean up
        // any details windows that were spawned while the application was running.
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<DetailsWindow> detailsWindows = new List<DetailsWindow>(m_detailsWindows);

            if (!PromptForSave(m_filePath))
            {
                e.Cancel = true;
                return;
            }

            foreach (DetailsWindow detailsWindow in detailsWindows)
                detailsWindow.Close();

            if (WindowState == FormWindowState.Normal)
                Settings.Default.WindowSize = Size;
            else
                Settings.Default.WindowSize = RestoreBounds.Size;

            Settings.Default.Save();

            // Explicitly terminate the process here,
            // otherwise a sufficiently large tree view may
            // suspend shutdown of the application for several minutes
            Environment.Exit(0);
        }

        // Handler called when the user selects the Save option in the toolbar menu.
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(m_filePath);
        }

        // Handler called when the user selects the Save As... option in the toolbar menu.
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.DefaultExt = ".pqd";
                saveFileDialog.Filter = "PQDIF Files|*.pqd|All Files|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    SaveFile(saveFileDialog.FileName);
            }
        }

        // Handler called when user selects the Find option in the toolbar menu.
        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindPanel.Visible = true;
            FindTextBox.Focus();
            FindTextBox.SelectAll();
        }

        // Handler called when the user types in the FindTextBox.
        private void FindTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                FindPanel.Visible = false;

            if (sender == FindTextBox && e.KeyCode == Keys.Enter)
            {
                if (!e.Shift)
                    FindNext();
                else
                    FindPrevious();
            }
        }

        // Handler called when the user clicks on the Find Next button.
        private void FindNextButton_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        // Handler called when the user clicks on the Find Previous button.
        private void FindPreviousButton_Click(object sender, EventArgs e)
        {
            FindPrevious();
        }

        // Handler called when the user clicks on the close button in the FindPanel.
        private void FindPanelCloseButton_Click(object sender, EventArgs e)
        {
            FindPanel.Visible = false;
        }

        // Handler called when the user mouses over the close button in the FindPanel.
        private void FindPanelCloseButton_MouseEnter(object sender, EventArgs e)
        {
            FindPanelCloseButton.Font = new Font(FindPanelCloseButton.Font, FontStyle.Underline);
        }

        // Handler called when the user's mouse is no longer over the close button in the FindPanel.
        private void FindPanelCloseButton_MouseLeave(object sender, EventArgs e)
        {
            FindPanelCloseButton.Font = new Font(FindPanelCloseButton.Font, FontStyle.Regular);
        }

        // Handler called when the user requests to view the Details window.
        private void DetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((object)RecordTree.SelectedNode != null)
                DisplayDetailsWindow(RecordTree.SelectedNode);
        }

        // Handler called when the users requests to view the Exceptions list.
        private void ShowExceptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ExceptionListWindow exceptionWindow = new ExceptionListWindow())
            {
                StringBuilder message = new StringBuilder();

                message.AppendLine("Exceptions:");

                foreach (Exception exception in m_exceptionList)
                    message.AppendLine(exception.Message);

                exceptionWindow.ExceptionList.Text = message.ToString();
                exceptionWindow.ShowDialog();
            }
        }

        #endregion
    }
}
