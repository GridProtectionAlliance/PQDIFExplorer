//******************************************************************************************************
//  ExceptionListWindow.Designer.cs - Gbtc
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
//  06/22/2016 - Stephen Jenks
//       Generated original version of source code.
//
//******************************************************************************************************

namespace PQDIFExplorer
{
    partial class ExceptionListWindow
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
            this.ExceptionList = new System.Windows.Forms.TextBox();
            this.RootPanel = new System.Windows.Forms.Panel();
            this.RootPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExceptionList
            // 
            this.ExceptionList.AcceptsReturn = true;
            this.ExceptionList.AcceptsTab = true;
            this.ExceptionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExceptionList.Location = new System.Drawing.Point(10, 10);
            this.ExceptionList.Multiline = true;
            this.ExceptionList.Name = "ExceptionList";
            this.ExceptionList.ReadOnly = true;
            this.ExceptionList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ExceptionList.Size = new System.Drawing.Size(562, 359);
            this.ExceptionList.TabIndex = 0;
            // 
            // RootPanel
            // 
            this.RootPanel.Controls.Add(this.ExceptionList);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 0);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Padding = new System.Windows.Forms.Padding(10);
            this.RootPanel.Size = new System.Drawing.Size(582, 379);
            this.RootPanel.TabIndex = 1;
            // 
            // ExceptionListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 379);
            this.Controls.Add(this.RootPanel);
            this.Name = "ExceptionListWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExceptionListWindow";
            this.RootPanel.ResumeLayout(false);
            this.RootPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox ExceptionList;
        private System.Windows.Forms.Panel RootPanel;
    }
}