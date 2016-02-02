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
        public Combiner()
        {

        }
        public FileInfo[] getTxtFiles(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            return di.GetFiles("*.txt");
        }
    }
}
