using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twiist
{
    internal class GUI
    {
        private char[] ProgressArray = {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};

        public void ProgressBar(float totalSize, float processed)
        {
            decimal percentage = Math.Round(Convert.ToDecimal(processed / totalSize * 100))+1;
            decimal pieces = Math.Ceiling((Math.Round((percentage / 100), 2) * ProgressArray.Length));
            for (int i = 0; i < pieces; i++)
            {
                ProgressArray[i] = '#';
            }

            Console.Write('[');
            for (int i = 0; i < ProgressArray.Length; i++)
            {
                Console.Write(ProgressArray[i]);
            }
            Console.Write(']');
            Console.Write(percentage + "%");
        }
    }
}
