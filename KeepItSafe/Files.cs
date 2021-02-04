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
        public static void Encrypt(string folderPath, string pass)
        {
            string[] files = Directory.GetFiles(folderPath);
            SecureFile sf = new SecureFile();
            GCHandle gch = GCHandle.Alloc(pass, GCHandleType.Pinned);

            foreach (string file in files)
            {
                sf.FileEncrypt(file, pass);
                
            }
        }

        public bool checkInputInfo()
        {

            bool missingInfo = false;

            if (folderDir == null && pass == "")
            {
                this.message += "folder path and password.";
                missingInfo = true;
            }
            else if (folderDir == null)
            {
                this.message += "folder path.";
                missingInfo = true;
            }
            else if (pass == "")
            {
                this.message += "folder password.";
                missingInfo = true;
            }

            return missingInfo;
        }
    }
}
