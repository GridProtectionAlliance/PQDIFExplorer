namespace PQDIFExplorer
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DetailsTextBox = new System.Windows.Forms.TextBox();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.RecordTree = new PQDIFExplorer.BufferedTreeView();
            this.SplashScreenLabel = new System.Windows.Forms.Label();
            this.RootPanel = new System.Windows.Forms.Panel();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PQDiffractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindPreviousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.GPALockButton = new System.Windows.Forms.Button();
            this.FindPanel = new System.Windows.Forms.Panel();
            this.FindPanelCloseButton = new System.Windows.Forms.Label();
            this.FindNextButton = new System.Windows.Forms.Button();
            this.FindPreviousButton = new System.Windows.Forms.Button();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.RootPanel.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.FindPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DetailsTextBox
            // 
            this.DetailsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsTextBox.Location = new System.Drawing.Point(0, 0);
            this.DetailsTextBox.Multiline = true;
            this.DetailsTextBox.Name = "DetailsTextBox";
            this.DetailsTextBox.ReadOnly = true;
            this.DetailsTextBox.Size = new System.Drawing.Size(572, 545);
            this.DetailsTextBox.TabIndex = 1;
            this.DetailsTextBox.WordWrap = false;
            this.DetailsTextBox.TextChanged += new System.EventHandler(this.DetailsTextBox_TextChanged);
            this.DetailsTextBox.Resize += new System.EventHandler(this.DetailsTextBox_Resize);
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer.Location = new System.Drawing.Point(10, 10);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.RecordTree);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.SplashScreenLabel);
            this.SplitContainer.Panel2.Controls.Add(this.DetailsTextBox);
            this.SplitContainer.Size = new System.Drawing.Size(864, 545);
            this.SplitContainer.SplitterDistance = 288;
            this.SplitContainer.TabIndex = 0;
            this.SplitContainer.TabStop = false;
            // 
            // RecordTree
            // 
            this.RecordTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordTree.Location = new System.Drawing.Point(0, 0);
            this.RecordTree.Name = "RecordTree";
            this.RecordTree.Size = new System.Drawing.Size(288, 545);
            this.RecordTree.TabIndex = 0;
            this.RecordTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RecordTree_AfterSelect);
            this.RecordTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RecordTree_MouseDown);
            // 
            // SplashScreenLabel
            // 
            this.SplashScreenLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplashScreenLabel.Location = new System.Drawing.Point(0, 0);
            this.SplashScreenLabel.Name = "SplashScreenLabel";
            this.SplashScreenLabel.Size = new System.Drawing.Size(572, 545);
            this.SplashScreenLabel.TabIndex = 0;
            // 
            // RootPanel
            // 
            this.RootPanel.Controls.Add(this.SplitContainer);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 46);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Padding = new System.Windows.Forms.Padding(10);
            this.RootPanel.Size = new System.Drawing.Size(884, 565);
            this.RootPanel.TabIndex = 0;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.OpenToolStripMenuItem.Text = "Open...";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.SaveAsToolStripMenuItem.Text = "Save As...";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // PQDiffractorToolStripMenuItem
            // 
            this.PQDiffractorToolStripMenuItem.Name = "PQDiffractorToolStripMenuItem";
            this.PQDiffractorToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.PQDiffractorToolStripMenuItem.Text = "PQDiffractor®";
            this.PQDiffractorToolStripMenuItem.Click += new System.EventHandler(this.PQDiffractorToolStripMenuItem_Click);
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.SearchToolStripMenuItem,
            this.PQDiffractorToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(860, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "MenuBar";
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindToolStripMenuItem,
            this.FindNextToolStripMenuItem,
            this.FindPreviousToolStripMenuItem});
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            this.SearchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.SearchToolStripMenuItem.Text = "Search";
            // 
            // FindToolStripMenuItem
            // 
            this.FindToolStripMenuItem.Enabled = false;
            this.FindToolStripMenuItem.Name = "FindToolStripMenuItem";
            this.FindToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.FindToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.FindToolStripMenuItem.Text = "Find...";
            this.FindToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
            // 
            // FindNextToolStripMenuItem
            // 
            this.FindNextToolStripMenuItem.Enabled = false;
            this.FindNextToolStripMenuItem.Name = "FindNextToolStripMenuItem";
            this.FindNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.FindNextToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.FindNextToolStripMenuItem.Text = "Find Next";
            this.FindNextToolStripMenuItem.Click += new System.EventHandler(this.FindNextButton_Click);
            // 
            // FindPreviousToolStripMenuItem
            // 
            this.FindPreviousToolStripMenuItem.Enabled = false;
            this.FindPreviousToolStripMenuItem.Name = "FindPreviousToolStripMenuItem";
            this.FindPreviousToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.FindPreviousToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.FindPreviousToolStripMenuItem.Text = "Find Previous";
            this.FindPreviousToolStripMenuItem.Click += new System.EventHandler(this.FindPreviousButton_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.AutoSize = true;
            this.TopPanel.Controls.Add(this.MenuBar);
            this.TopPanel.Controls.Add(this.GPALockButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(884, 24);
            this.TopPanel.TabIndex = 0;
            // 
            // GPALockButton
            // 
            this.GPALockButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.GPALockButton.Location = new System.Drawing.Point(860, 0);
            this.GPALockButton.Name = "GPALockButton";
            this.GPALockButton.Size = new System.Drawing.Size(24, 24);
            this.GPALockButton.TabIndex = 1;
            this.GPALockButton.UseVisualStyleBackColor = true;
            this.GPALockButton.Click += new System.EventHandler(this.GPALockButton_Click);
            // 
            // FindPanel
            // 
            this.FindPanel.Controls.Add(this.FindPanelCloseButton);
            this.FindPanel.Controls.Add(this.FindNextButton);
            this.FindPanel.Controls.Add(this.FindPreviousButton);
            this.FindPanel.Controls.Add(this.FindTextBox);
            this.FindPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FindPanel.Location = new System.Drawing.Point(0, 24);
            this.FindPanel.Name = "FindPanel";
            this.FindPanel.Size = new System.Drawing.Size(884, 22);
            this.FindPanel.TabIndex = 1;
            this.FindPanel.Visible = false;
            // 
            // FindPanelCloseButton
            // 
            this.FindPanelCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindPanelCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FindPanelCloseButton.Location = new System.Drawing.Point(863, 1);
            this.FindPanelCloseButton.Name = "FindPanelCloseButton";
            this.FindPanelCloseButton.Size = new System.Drawing.Size(20, 20);
            this.FindPanelCloseButton.TabIndex = 3;
            this.FindPanelCloseButton.Text = "x";
            this.FindPanelCloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FindPanelCloseButton.Click += new System.EventHandler(this.FindPanelCloseButton_Click);
            this.FindPanelCloseButton.MouseEnter += new System.EventHandler(this.FindPanelCloseButton_MouseEnter);
            this.FindPanelCloseButton.MouseLeave += new System.EventHandler(this.FindPanelCloseButton_MouseLeave);
            // 
            // FindNextButton
            // 
            this.FindNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindNextButton.Location = new System.Drawing.Point(844, 1);
            this.FindNextButton.Name = "FindNextButton";
            this.FindNextButton.Size = new System.Drawing.Size(20, 20);
            this.FindNextButton.TabIndex = 2;
            this.FindNextButton.Text = "˅";
            this.FindNextButton.UseVisualStyleBackColor = true;
            this.FindNextButton.Click += new System.EventHandler(this.FindNextButton_Click);
            this.FindNextButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindTextBox_KeyDown);
            // 
            // FindPreviousButton
            // 
            this.FindPreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindPreviousButton.Location = new System.Drawing.Point(825, 1);
            this.FindPreviousButton.Name = "FindPreviousButton";
            this.FindPreviousButton.Size = new System.Drawing.Size(20, 20);
            this.FindPreviousButton.TabIndex = 1;
            this.FindPreviousButton.Text = "˄";
            this.FindPreviousButton.UseVisualStyleBackColor = true;
            this.FindPreviousButton.Click += new System.EventHandler(this.FindPreviousButton_Click);
            this.FindPreviousButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindTextBox_KeyDown);
            // 
            // FindTextBox
            // 
            this.FindTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindTextBox.Location = new System.Drawing.Point(601, 1);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(224, 20);
            this.FindTextBox.TabIndex = 0;
            this.FindTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindTextBox_KeyDown);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.RootPanel);
            this.Controls.Add(this.FindPanel);
            this.Controls.Add(this.TopPanel);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainWindow";
            this.Text = "PQDIFExplorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            this.SplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.RootPanel.ResumeLayout(false);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.FindPanel.ResumeLayout(false);
            this.FindPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox DetailsTextBox;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.Panel RootPanel;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PQDiffractorToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button GPALockButton;
        private System.Windows.Forms.Label SplashScreenLabel;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindNextToolStripMenuItem;
        private System.Windows.Forms.Panel FindPanel;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.Button FindNextButton;
        private System.Windows.Forms.Button FindPreviousButton;
        private System.Windows.Forms.ToolStripMenuItem FindPreviousToolStripMenuItem;
        private System.Windows.Forms.Label FindPanelCloseButton;
        private BufferedTreeView RecordTree;
    }
}

