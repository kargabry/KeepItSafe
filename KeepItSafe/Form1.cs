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
        private string folderPath;
        private string message;
        Files files = new Files();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if(FBD.ShowDialog() == DialogResult.OK)
            {
                this.folderPath = FBD.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkIputInfo(folderPath, passBox.Text, out message) == false)
            {
                MessageBox.Show(message, "Missing information");
                return;
            }

            files.Encrypt(folderPath, passBox.Text);
        }

        private bool checkIputInfo(string folderPath, string pass, out string message)
        {
            bool check = true;
            message = "You did not enter ";

            if(folderPath == null && pass.Length < 1)
            {
                message += "folder path and password.";
                check = false;
            }
            else if (folderPath == null)
            {
                message += "folder path.";
                check = false;
            }
            else if (pass.Length < 1)
            {
                message += "password.";
                check = false;
            }
            
            return check;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkIputInfo(folderPath, passBox.Text, out message) == false)
            {
                MessageBox.Show(message, "Missing information");
                return;
            }

            files.Decrypt(folderPath, folderPath, passBox.Text);
        }
    }
}
