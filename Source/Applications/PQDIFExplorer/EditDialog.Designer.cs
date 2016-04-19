namespace PQDIFExplorer
{
    partial class EditDialog
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
            this.RootPanel = new System.Windows.Forms.Panel();
            this.ValueCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.ValueListBox = new System.Windows.Forms.ListBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.RootPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootPanel
            // 
            this.RootPanel.Controls.Add(this.ValueCheckedListBox);
            this.RootPanel.Controls.Add(this.ValueListBox);
            this.RootPanel.Controls.Add(this.ValueTextBox);
            this.RootPanel.Controls.Add(this.ButtonPanel);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 0);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Padding = new System.Windows.Forms.Padding(10);
            this.RootPanel.Size = new System.Drawing.Size(434, 209);
            this.RootPanel.TabIndex = 0;
            // 
            // ValueCheckedListBox
            // 
            this.ValueCheckedListBox.CheckOnClick = true;
            this.ValueCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueCheckedListBox.FormattingEnabled = true;
            this.ValueCheckedListBox.Location = new System.Drawing.Point(10, 10);
            this.ValueCheckedListBox.Name = "ValueCheckedListBox";
            this.ValueCheckedListBox.Size = new System.Drawing.Size(414, 156);
            this.ValueCheckedListBox.TabIndex = 0;
            this.ValueCheckedListBox.Visible = false;
            // 
            // ValueListBox
            // 
            this.ValueListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueListBox.FormattingEnabled = true;
            this.ValueListBox.Location = new System.Drawing.Point(10, 10);
            this.ValueListBox.Name = "ValueListBox";
            this.ValueListBox.Size = new System.Drawing.Size(414, 156);
            this.ValueListBox.TabIndex = 0;
            this.ValueListBox.Visible = false;
            this.ValueListBox.DoubleClick += new System.EventHandler(this.ValueListBox_DoubleClick);
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ValueTextBox.Location = new System.Drawing.Point(10, 10);
            this.ValueTextBox.Multiline = true;
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(414, 156);
            this.ValueTextBox.TabIndex = 0;
            this.ValueTextBox.Visible = false;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.AutoSize = true;
            this.ButtonPanel.Controls.Add(this.CancelButton);
            this.ButtonPanel.Controls.Add(this.OKButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonPanel.Location = new System.Drawing.Point(10, 166);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(414, 33);
            this.ButtonPanel.TabIndex = 1;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(334, 5);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(249, 5);
            this.OKButton.Margin = new System.Windows.Forms.Padding(5);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // EditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 209);
            this.Controls.Add(this.RootPanel);
            this.Name = "EditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditDialog";
            this.RootPanel.ResumeLayout(false);
            this.RootPanel.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel RootPanel;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.FlowLayoutPanel ButtonPanel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ListBox ValueListBox;
        private System.Windows.Forms.CheckedListBox ValueCheckedListBox;
    }
}