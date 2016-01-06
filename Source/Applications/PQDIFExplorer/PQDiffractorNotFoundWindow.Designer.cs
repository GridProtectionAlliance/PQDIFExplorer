namespace PQDIFExplorer
{
    partial class PQDiffractorNotFoundWindow
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
            this.NotFoundLabel = new System.Windows.Forms.Label();
            this.PQDiffractorLink = new System.Windows.Forms.LinkLabel();
            this.CanDownloadLabel = new System.Windows.Forms.Label();
            this.EnterFilePathLabel = new System.Windows.Forms.Label();
            this.FilePathPanel = new System.Windows.Forms.Panel();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.FilePathBrowseButton = new System.Windows.Forms.Button();
            this.FilePathPaddingPanel = new System.Windows.Forms.Panel();
            this.RootPanel = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.FilePathPanel.SuspendLayout();
            this.RootPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotFoundLabel
            // 
            this.NotFoundLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NotFoundLabel.Location = new System.Drawing.Point(10, 10);
            this.NotFoundLabel.Name = "NotFoundLabel";
            this.NotFoundLabel.Size = new System.Drawing.Size(414, 23);
            this.NotFoundLabel.TabIndex = 0;
            this.NotFoundLabel.Text = "Unable to find PQDiffractor® on this system.";
            this.NotFoundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PQDiffractorLink
            // 
            this.PQDiffractorLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.PQDiffractorLink.Location = new System.Drawing.Point(10, 56);
            this.PQDiffractorLink.Name = "PQDiffractorLink";
            this.PQDiffractorLink.Size = new System.Drawing.Size(414, 23);
            this.PQDiffractorLink.TabIndex = 1;
            this.PQDiffractorLink.TabStop = true;
            this.PQDiffractorLink.Text = "http://www.pqview.com/pqdiffractor/";
            this.PQDiffractorLink.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PQDiffractorLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PQDiffractorLink_LinkClicked);
            // 
            // CanDownloadLabel
            // 
            this.CanDownloadLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CanDownloadLabel.Location = new System.Drawing.Point(10, 33);
            this.CanDownloadLabel.Name = "CanDownloadLabel";
            this.CanDownloadLabel.Size = new System.Drawing.Size(414, 23);
            this.CanDownloadLabel.TabIndex = 2;
            this.CanDownloadLabel.Text = "Click the following link to download it.";
            this.CanDownloadLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // EnterFilePathLabel
            // 
            this.EnterFilePathLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.EnterFilePathLabel.Location = new System.Drawing.Point(10, 79);
            this.EnterFilePathLabel.Name = "EnterFilePathLabel";
            this.EnterFilePathLabel.Size = new System.Drawing.Size(414, 23);
            this.EnterFilePathLabel.TabIndex = 3;
            this.EnterFilePathLabel.Text = "Enter the file path to PQDiffractor.exe below:";
            this.EnterFilePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FilePathPanel
            // 
            this.FilePathPanel.Controls.Add(this.FilePathTextBox);
            this.FilePathPanel.Controls.Add(this.FilePathPaddingPanel);
            this.FilePathPanel.Controls.Add(this.FilePathBrowseButton);
            this.FilePathPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilePathPanel.Location = new System.Drawing.Point(10, 102);
            this.FilePathPanel.Name = "FilePathPanel";
            this.FilePathPanel.Size = new System.Drawing.Size(414, 20);
            this.FilePathPanel.TabIndex = 4;
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilePathTextBox.Location = new System.Drawing.Point(0, 0);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(329, 20);
            this.FilePathTextBox.TabIndex = 0;
            this.FilePathTextBox.TextChanged += new System.EventHandler(this.FilePathTextBox_TextChanged);
            // 
            // FilePathBrowseButton
            // 
            this.FilePathBrowseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.FilePathBrowseButton.Location = new System.Drawing.Point(339, 0);
            this.FilePathBrowseButton.Name = "FilePathBrowseButton";
            this.FilePathBrowseButton.Size = new System.Drawing.Size(75, 20);
            this.FilePathBrowseButton.TabIndex = 1;
            this.FilePathBrowseButton.Text = "Browse...";
            this.FilePathBrowseButton.UseVisualStyleBackColor = true;
            this.FilePathBrowseButton.Click += new System.EventHandler(this.FilePathBrowseButton_Click);
            // 
            // FilePathPaddingPanel
            // 
            this.FilePathPaddingPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.FilePathPaddingPanel.Location = new System.Drawing.Point(329, 0);
            this.FilePathPaddingPanel.Name = "FilePathPaddingPanel";
            this.FilePathPaddingPanel.Size = new System.Drawing.Size(10, 20);
            this.FilePathPaddingPanel.TabIndex = 2;
            // 
            // RootPanel
            // 
            this.RootPanel.Controls.Add(this.ButtonPanel);
            this.RootPanel.Controls.Add(this.FilePathPanel);
            this.RootPanel.Controls.Add(this.EnterFilePathLabel);
            this.RootPanel.Controls.Add(this.PQDiffractorLink);
            this.RootPanel.Controls.Add(this.CanDownloadLabel);
            this.RootPanel.Controls.Add(this.NotFoundLabel);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 0);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Padding = new System.Windows.Forms.Padding(10);
            this.RootPanel.Size = new System.Drawing.Size(434, 191);
            this.RootPanel.TabIndex = 5;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(182, 14);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(50, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.OKButton);
            this.ButtonPanel.Location = new System.Drawing.Point(10, 131);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(414, 50);
            this.ButtonPanel.TabIndex = 6;
            // 
            // PQDiffractorNotFoundWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 191);
            this.Controls.Add(this.RootPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PQDiffractorNotFoundWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PQDiffractor® Not Found";
            this.Load += new System.EventHandler(this.PQDiffractorNotFoundWindow_Load);
            this.FilePathPanel.ResumeLayout(false);
            this.FilePathPanel.PerformLayout();
            this.RootPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NotFoundLabel;
        private System.Windows.Forms.LinkLabel PQDiffractorLink;
        private System.Windows.Forms.Label CanDownloadLabel;
        private System.Windows.Forms.Label EnterFilePathLabel;
        private System.Windows.Forms.Panel FilePathPanel;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Button FilePathBrowseButton;
        private System.Windows.Forms.Panel FilePathPaddingPanel;
        private System.Windows.Forms.Panel RootPanel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Panel ButtonPanel;
    }
}