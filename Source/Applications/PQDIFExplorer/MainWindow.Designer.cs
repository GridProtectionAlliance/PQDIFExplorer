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
            this.RecordTree = new System.Windows.Forms.TreeView();
            this.DetailsTextBox = new System.Windows.Forms.TextBox();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.SplashScreenLabel = new System.Windows.Forms.Label();
            this.RootPanel = new System.Windows.Forms.Panel();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAltSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PQDiffractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.GPALockButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.RootPanel.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RecordTree
            // 
            this.RecordTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordTree.Location = new System.Drawing.Point(0, 0);
            this.RecordTree.Name = "RecordTree";
            this.RecordTree.Size = new System.Drawing.Size(288, 567);
            this.RecordTree.TabIndex = 1;
            this.RecordTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RecordTree_AfterSelect);
            this.RecordTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RecordTree_MouseDown);
            // 
            // DetailsTextBox
            // 
            this.DetailsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsTextBox.Location = new System.Drawing.Point(0, 0);
            this.DetailsTextBox.Multiline = true;
            this.DetailsTextBox.Name = "DetailsTextBox";
            this.DetailsTextBox.ReadOnly = true;
            this.DetailsTextBox.Size = new System.Drawing.Size(572, 567);
            this.DetailsTextBox.TabIndex = 2;
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
            this.SplitContainer.Size = new System.Drawing.Size(864, 567);
            this.SplitContainer.SplitterDistance = 288;
            this.SplitContainer.TabIndex = 0;
            // 
            // SplashScreenLabel
            // 
            this.SplashScreenLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplashScreenLabel.Location = new System.Drawing.Point(0, 0);
            this.SplashScreenLabel.Name = "SplashScreenLabel";
            this.SplashScreenLabel.Size = new System.Drawing.Size(572, 567);
            this.SplashScreenLabel.TabIndex = 3;
            // 
            // RootPanel
            // 
            this.RootPanel.Controls.Add(this.SplitContainer);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 24);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Padding = new System.Windows.Forms.Padding(10);
            this.RootPanel.Size = new System.Drawing.Size(884, 587);
            this.RootPanel.TabIndex = 0;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.saveAltSToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.OpenToolStripMenuItem.Text = "Open...";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveAltSToolStripMenuItem
            // 
            this.saveAltSToolStripMenuItem.Enabled = false;
            this.saveAltSToolStripMenuItem.Name = "saveAltSToolStripMenuItem";
            this.saveAltSToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.saveAltSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAltSToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.saveAltSToolStripMenuItem.Text = "Save";
            this.saveAltSToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.saveAsToolStripMenuItem.Text = "Save As ";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
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
            this.PQDiffractorToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(860, 24);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "MenuBar";
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
            this.TopPanel.TabIndex = 1;
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
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.RootPanel);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView RecordTree;
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
        private System.Windows.Forms.ToolStripMenuItem saveAltSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}

