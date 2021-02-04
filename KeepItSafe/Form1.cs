using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepItSafe
{
    public partial class Form1 : Form
    {
        private string folderDir;
        private string message;
        private string pass;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if(FBD.ShowDialog() == DialogResult.OK)
            {
                this.folderDir = FBD.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.message = "You did not enter ";
            this.pass = passBox.Text;

            if (Files.checkInputInfo() == true)
            {
                MessageBox.Show(message, "Missing information");
                return;
            }

            Files.Encrypt(folderDir, pass);
        }
    }
}
