//******************************************************************************************************
//  PQDiffractorNotFoundWindow.cs - Gbtc
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
//  01/07/2016 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Diagnostics;
using System.Windows.Forms;
using PQDIFExplorer.Properties;

namespace PQDIFExplorer
{
    public partial class PQDiffractorNotFoundWindow : Form
    {
        public PQDiffractorNotFoundWindow()
        {
            InitializeComponent();
        }

        private void PQDiffractorNotFoundWindow_Load(object sender, EventArgs e)
        {
            FilePathTextBox.Text = Settings.Default.PQDiffractorPath;
        }

        private void FilePathBrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.DefaultExt = ".exe";
                openFileDialog.Filter = "Executable Files|*.exe|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    FilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void FilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.PQDiffractorPath = FilePathTextBox.Text;
            Settings.Default.Save();
        }

        private void PQDiffractorLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Process.Start("http://www.pqview.com/pqdiffractor/"))
            {
            }
        }
    }
}
