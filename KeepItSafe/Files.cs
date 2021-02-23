using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KeepItSafe
{
    public class Files : SecureFile
    {
        private string[] files;
        Files fs = new Files();

        private void openFolder(string folderPath)
        {
            this.files = Directory.GetFiles(folderPath);
        }
        public void Encrypt(string folderPath, string pass)
        {
            this.openFolder(folderPath);
            GCHandle gch = GCHandle.Alloc(pass, GCHandleType.Pinned);

            foreach (string file in this.files)
            {
                fs.FileEncrypt(file, pass);
            }
        }

        public void Decrypt(string folderPath, string outputFile, string pass)
        {
            this.openFolder(folderPath);
            foreach (string file in this.files)
            {
                fs.FileDecrypt(file, outputFile, pass);
            }
        }
    }
}
