using System;
using System.IO;
using System.Windows.Forms;

namespace Excel_2010_Measure_Reader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            try
            {
                txtResults.Text = ExcelFiles.ReadAllMeasures(directoryTree);
                txtResults.Text = txtResults.Text.Length == 0 ? "No measures were read" : txtResults.Text;
            }
            catch (Exception ex)
            {
                txtResults.Text = string.Format("Exception Message: {0}", ex.Message);
            }

            tabControl.SelectTab(pgResults);
            pgResults.Focus();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            directoryTree.ReadDrives();
            CenterToScreen();
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            readButton.Enabled = (e.TabPage == pgSelect);
            saveResultsButton.Enabled = !readButton.Enabled;
        }

        private void saveResultsButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "Results.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, txtResults.Text);
            }
        }
    }
}