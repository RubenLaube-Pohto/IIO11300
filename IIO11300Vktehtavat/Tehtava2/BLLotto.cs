/*
 * This file is part of the IIO11300 coursework.
 *
 * Created: 22.1.2016 Modified: 23.1.2016
 * Authors: Ruben Laube-Pohto
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
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
        public string DrawNumbers(int lines = 1)
        {
            string result = "";

            for (int i = 0; i < lines; i++)
            {
                switch (type)
                {
                    #region Suomi-lotto
                    case "Suomi":
                    {
                        int[] numbers = new int[39];
                        for (int j = 0; j < numbers.Length; j++)
                            numbers[j] = j + 1;
                        // Shuffle numbers
                        int[] rndNumbers = numbers.OrderBy(x => rnd.Next()).ToArray();
                        // Pick first 7 numbers
                        for (int j = 0; j < 7; j++)
                            result += (rndNumbers[j] + " ");
                    } break;
                    #endregion
                    #region VikingLotto
                    case "VikingLotto":
                    {
                        int[] numbers = new int[48];
                        for (int j = 0; j < numbers.Length; j++)
                            numbers[j] = j + 1;
                        // Shuffle numbers
                        int[] rndNumbers = numbers.OrderBy(x => rnd.Next()).ToArray();
                        // Pick first 6 numbers
                        for (int j = 0; j < 6; j++)
                            result += (rndNumbers[j] + " ");
                    } break;
                    #endregion
                    #region Eurojackpot
                    case "Eurojackpot":
                    {
                        // Main numbers
                        int[] numbers = new int[50];
                        for (int j = 0; j < numbers.Length; j++)
                            numbers[j] = j + 1;
                        // Shuffle numbers
                        int[] rndNumbers = numbers.OrderBy(x => rnd.Next()).ToArray();
                        // Pick first 5 numbers
                        for (int j = 0; j < 5; j++)
                            result += (rndNumbers[j] + " ");

                        // Star numbers
                        result += "* ";
                        int[] starNumbers = new int[8];
                        for (int j = 0; j < starNumbers.Length; j++)
                            starNumbers[j] = j + 1;
                        // Shuffle numbers
                        int[] rndStarNumbers = starNumbers.OrderBy(x => rnd.Next()).ToArray();
                        // Pick first 2 numbers
                        for (int j = 0; j < 2; j++)
                            result += (rndStarNumbers[j] + " ");
                    } break;
                    #endregion
                    #region default
                    default: { } break;
                    #endregion
                }
                result += '\n';
            }

            return result;
        }
        #endregion
    }
    class BLLotto
    {
    }
}
