using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempAnalyse
{
    internal class Durchschnitt
    {
        private string[] _lines;

        public Durchschnitt(string[] lines)
        {
            _lines = lines;
        }

        public void Main()
        {

            foreach (string messStelle in InputHelper.GetMesstellen())
            {
                List<string> liste = InputHelper.ReadData(_lines, messStelle);
                Console.WriteLine($"Messfühler {messStelle} hat eine Durchschnittstemperatur von: {Durchschnittt(liste):0.00}");
            }

            return;
        }

        public double Durchschnittt(List<string> list)
        {
            double list2 = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int index = list[i].LastIndexOf(",");
                string list1 = list[i].Substring(index + 1);
                list2 += double.Parse(list1, CultureInfo.InvariantCulture.NumberFormat);


                list1 = "";
            }
            double result = Math.Round(list2, 2);
            return result / list.Count;
        }
    }
}

