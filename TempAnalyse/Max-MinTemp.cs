using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempAnalyse
{
    internal class MaxTemp
    {
        public string[] Lines;

        public MaxTemp()
        {
        }

        public void Main()
        {

            List<string> listS1 = InputHelper.ReadData(Lines, "S1");
            List<string> listS2 = InputHelper.ReadData(Lines, "S2");
            List<string> listS3 = InputHelper.ReadData(Lines, "S3");
            List<string> listS4 = InputHelper.ReadData(Lines, "S4");
            List<string> listSB = InputHelper.ReadData(Lines, "SB");
            List<string> listSD = InputHelper.ReadData(Lines, "SD");

            PrintMaxValue(listS1, "S1",true);
            PrintMaxValue(listS2, "S2",true);
            PrintMaxValue(listS3, "S3",true);
            PrintMaxValue(listS4, "S4",true);
            PrintMaxValue(listSB, "SB",true);
            PrintMaxValue(listSD, "SD",true);

            Console.WriteLine("------------------------------------");

            PrintMaxValue(listS1, "S1",false);
            PrintMaxValue(listS2, "S2",false);
            PrintMaxValue(listS3, "S3",false);
            PrintMaxValue(listS4, "S4",false);
            PrintMaxValue(listSB, "SB",false);
            PrintMaxValue(listSD, "SD",false);

            return;
        }

        private void PrintMaxValue(List<string> list, string listName, bool isMaxValue)
        {
            List<string> dates = Datum(list);

            if (isMaxValue)
            {
                Console.WriteLine($"Messfühler {listName} hat eine MaxTemp von: " + MaxMinTemp(list));
                Console.WriteLine("Die MaxTemp  wurde an folgenden Daten erreicht: ");

            } else
            {
                Console.WriteLine($"Messfühler {listName} hat eine MinTemp von: " + MinMaxTemp(list));
                Console.WriteLine("Die MinTemp wurde an folgenden Daten erreicht: ");
            }

            for (int i = 0; i < dates.Count; i++)
            {
                Console.Write(dates[i] + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static double MaxMinTemp(List<string> list)
        {
            double result = 0;
            double list2 = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int index = list[i].LastIndexOf(",");
                string list1 = list[i].Substring(index + 1);
                double zwischenergebnis = double.Parse(list1, CultureInfo.InvariantCulture.NumberFormat);
                if (zwischenergebnis > result)
                {
                    result = zwischenergebnis;
                }
            }
            return result;
        }

        static double MinMaxTemp(List<string> list)
        {
            double result = 0;
            double list2 = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int index = list[i].LastIndexOf(",");
                string list1 = list[i].Substring(index + 1);
                double zwischenergebnis = double.Parse(list1, CultureInfo.InvariantCulture.NumberFormat);
                if (i == 0)
                {
                    result = zwischenergebnis;
                }
                if (zwischenergebnis < result)
                {
                    result = zwischenergebnis;
                }
            }
            return result;
        }

        static List<string> Datum(List<string> list)
        {

            List<string> result = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                int index = list[i].LastIndexOf(",");
                string list1 = list[i].Substring(index + 1);
                double zwischenergebnis = double.Parse(list1, CultureInfo.InvariantCulture.NumberFormat);

                if (zwischenergebnis == 30)
                {
                    int indexWhite = list[i].IndexOf(" ");
                    string delete = list[i].Remove(indexWhite);
                    int indexDelimiter = delete.IndexOf(",");
                    string sub = delete.Substring(indexDelimiter + 1);
                    result.Add(sub);
                }

                if (zwischenergebnis == 65)
                {
                    int indexWhite = list[i].IndexOf(" ");
                    string delete = list[i].Remove(indexWhite);
                    int indexDelimiter = delete.IndexOf(",");
                    string sub = delete.Substring(indexDelimiter + 1);
                    result.Add(sub);
                }
            }
            return result;
        }
    }
}
