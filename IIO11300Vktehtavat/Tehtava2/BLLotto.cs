using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava2
{
    public class Lotto
    {
        #region Variables
        private string type;
        Random rnd;
        #endregion
        #region Properties
        public string Type
        {
            set { type = value; }
        }
        #endregion
        #region Constructors
        public Lotto()
        {
            type = "Suomi";
            rnd = new Random();
        }
        public Lotto(string type)
        {
            this.type = type;
            rnd = new Random();
        }
        #endregion
        #region Methods
        public string drawNumbers(int lines = 1)
        {
            string result = "";

            for (int i = 0; i < lines; i++)
            {
                switch (type)
                {
                    case "Suomi": {
                        int[] numbers = new int[39];
                        for (int j = 0; j < numbers.Length; j++)
                            numbers[j] = j + 1;
                        // Shuffle numbers
                        int[] rndNumbers = numbers.OrderBy(x => rnd.Next()).ToArray();
                        // Pick first 7 numbers
                        for (int j = 0; j < 7; j++)
                            result += (rndNumbers[j] + " ");
                        result += '\n';
                    } break;
                    case "VikingLotto": {

                        } break;
                    case "Eurojackpot": { } break;
                    default: { } break;
                }
            }

            return result;
        }
        #endregion
    }
    class BLLotto
    {
    }
}
