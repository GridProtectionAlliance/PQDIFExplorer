//******************************************************************************************************
//  EditDialog.cs - Gbtc
//
//  Copyright © 2016, Grid Protection Alliance.  All Rights Reserved.
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
//  04/19/2016 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GSF.PQDIF;
using GSF.PQDIF.Physical;

namespace PQDIFExplorer
{
    public partial class EditDialog : Form
    {
        private Func<string> m_getValue;

        // Creates a new instance ofthe EditDialog class.
        public EditDialog()
        {
            m_getValue = () => null;
            InitializeComponent();
        }

        // Gets the value entered by the user.
        public string Value
        {
            get
            {
                return m_getValue();
            }
        }

        // Initializes the edit dialog to set the value of the given element.
        public void Initialize(Element element)
        {
            if ((object)element == null)
                return;

            Tag tag = GSF.PQDIF.Tag.GetTag(element.TagOfElement);

            // Determine whether the tag definition contains
            // a list of identifiers which can be used to
            // display the value in a more readable format
            IReadOnlyCollection<Identifier> identifiers = tag?.ValidIdentifiers ?? new List<Identifier>();

            // Some identifier collections define a set of bitfields which can be
            // combined to represent a collection of states rather than a single value
            // and these are identified by the values being represented in hexadecimal
            List<Identifier> bitFields = identifiers.Where(id => id.Value.StartsWith("0x")).ToList();

            if (bitFields.Count > 0)
            {
                // Get the value of the element
                uint value = Convert.ToUInt32(((ScalarElement)element).Get());

                // Values with bitfields will be displayed in a checked list box
                ValueCheckedListBox.Visible = true;
                ValueCheckedListBox.Focus();

                // Populate the checked list box with the valid bitfields
                foreach (Identifier bitField in bitFields)
                {
                    uint bit = Convert.ToUInt32(bitField.Value, 16);
                    ValueCheckedListBox.Items.Add(bitField.Name, (value & bit) > 0u);
                }

                // Set up the function to get the value entered by the user
                m_getValue = () => "{ " + string.Join(", ", ValueCheckedListBox.CheckedItems.Cast<string>()) + " }";
            }
            else if (identifiers.Count > 0)
            {
                // Get the value of the element
                string value = ((ScalarElement)element).Get().ToString();

                // Values with IDs will be displayed in a regular list box
                ValueListBox.Visible = true;
                ValueListBox.Focus();

                // Populate the list box with the valid identifiers
                foreach (Identifier identifier in identifiers.OrderBy(identifier => identifier.Name))
                {
                    ValueListBox.Items.Add(identifier.Name);

                    if (value == identifier.Value)
                        ValueListBox.SelectedIndex = ValueListBox.Items.Count - 1;
                }

                // Set up the function to get the value entered by the user
                m_getValue = () => ValueListBox.SelectedItem?.ToString();
            }
            else
            {
                // All other values will be displayed in an editable text box
                ValueTextBox.Visible = true;
                ValueTextBox.Focus();
                ValueTextBox.Text = element.ValueAsString();

                // Set up the function to get the value entered by the user
                m_getValue = () => ValueTextBox.Text;
            }
        }

        // Closes the window when the escape key is pressed.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && !ValueTextBox.Focused)
            {
                DialogResult = DialogResult.OK;
                Close();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Handler called when the user double-clicks the list box.
        private void ValueListBox_DoubleClick(object sender, EventArgs e)
        {
            // Ensure that the user double-clicked on an item in the list box.
            int index = ValueListBox.IndexFromPoint(ValueListBox.PointToClient(MousePosition));

            if (index != ListBox.NoMatches)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
