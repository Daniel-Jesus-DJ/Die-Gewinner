using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempAnalyse
{
    internal class Hottest
    {
        public string[] _lines;

        public Hottest()
        {
        }
        public void Main()
        {
            int year = 2021;
            double ergebnis = 0;
            double zwischenergebnis = 0;
            string final = "";
            List<double> result = new();
            List<string> listYear = new();
            Console.WriteLine();
            for (int i = 0; i <= _lines.Length - 1; i++)
            {
                string zählen = year.ToString();
                if (_lines[i].Contains(zählen))
                {
                    listYear.Add(_lines[i]);
                }
                else
                {
                    ergebnis = Durchschnittt(listYear);
                    if (ergebnis > zwischenergebnis)
                    {
                        zwischenergebnis = ergebnis;
                        final = year.ToString();
                    }
                    Console.WriteLine($"In {year} war der Hitze-Jahresdurchschnitt: {ergebnis:0.00}");
                    year++;
                    listYear.Clear();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Das heißeste Jahr ist somit: " + final);

        }
        static double Durchschnittt(List<string> list)
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


