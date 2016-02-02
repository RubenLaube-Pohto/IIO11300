/*
 * Weekly Task 3
 * Created: 02.02.2016
 * Author: Ruben Laube-Pohto
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    class Combiner
    {
        public static FileInfo[] getTxtFiles(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            return di.GetFiles("*.txt");
        }
        public static void writeToOneFile(string sourceDir, string destDir)
        {
            string content = "";
            FileInfo[] fiArray = getTxtFiles(sourceDir);

            foreach (FileInfo fi in fiArray)
            {
                content += File.ReadAllText(fi.FullName);
            }

            File.WriteAllText(destDir, content);
        }
    }
}
