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
            Files fs = new Files();
            GCHandle gch = GCHandle.Alloc(pass, GCHandleType.Pinned);

            foreach (string file in files)
            {
                fs.FileEncrypt(file, pass);
            }
        }
    }
}
