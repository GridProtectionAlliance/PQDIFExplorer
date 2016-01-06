using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
