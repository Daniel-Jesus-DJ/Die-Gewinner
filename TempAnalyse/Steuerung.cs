using System.Globalization;

namespace TempAnalyse
{
    internal class Steuerung
    {
        private UI dieUI; 
        string[] data = File.ReadAllLines("../../../CSV/Input.csv");
        string[] sensors = {"S1", "S2", "S3", "S4", "SB", "SD"};
        private int time = 0;

        public Steuerung(UI pUI)
        {
            dieUI = pUI;
        }

        public string[] getData()
        {
            return data;
        }

        private double durchschnitt(List<string> dLines)
        {
            Durchschnitt durchschnitt = new Durchschnitt(data);
            return durchschnitt.Durchschnittt(dLines);
        }

        public double getDurchschnitt()
        {
            return Math.Round(durchschnitt(InputHelper.toList(data)), 2);
        }

        public void setTime(int index)
        {
            time = index;
        }

        public void setData()
        {
            renewData();
            DateTime latestTimestamp = data.Select(line => DateTime.ParseExact(line.Split(',')[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)).Max();
            List<string> filteredData = new List<string>();
            foreach (var line in data)
            {
                var parts = line.Split(',');
                DateTime timestamp = DateTime.ParseExact(parts[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                switch (time)
                {
                    case 0: //Letzten Monat
                        if (timestamp.Date >= latestTimestamp.AddMonths(-1).Date)
                        {
                            filteredData.Add(line);
                        }
                        break;
                    case 1: // Letzten 3 Monate
                        if (timestamp.Date >= latestTimestamp.AddMonths(-3).Date)
                        {
                            filteredData.Add(line);
                        }
                        break;
                    case 2: // Letztes Jahr
                        if(timestamp.Date >= latestTimestamp.AddYears(-1).Date)
                        {
                            filteredData.Add(line);
                        }
                        break;
                    case 3: // Letzten 5 Jahre
                        if (timestamp.Date >= latestTimestamp.AddYears(-5).Date)
                        {
                            filteredData.Add(line);
                        }
                        break;
                    case 4: // Seit Beginn
                        filteredData.Add(line);
                        break;
                    default:
                        dieUI.printMessage("Ungültiger Zeitraum");
                        return;
                }
            }

            data = filteredData.ToArray();
            calculate();
        }

        private void renewData()
        {
            data = File.ReadAllLines("../../../CSV/Input.csv");
        }

        private void calculate()
        {
            foreach (var sensor in sensors)
            {
                List<double> temperatures = new List<double>();
                List<string> sensorData = new List<string>();
                foreach (var line in data)
                {
                    var sensorID = line.Split(",").First();
                    if (sensorID != sensor) continue;
                    double temperatur = Convert.ToDouble(line.Split(",").Last(), CultureInfo.InvariantCulture);
                    temperatures.Add(temperatur);
                    sensorData.Add(line);
                }
                
                double average = Math.Round(temperatures.Average(), 1);
                double max = Math.Round(temperatures.Max(),1);
                double min = Math.Round(temperatures.Min(), 1);
                string hottest = sensorData.Max().Split(",")[1];
                
                dieUI.printSensorAverage(sensor, average);
                dieUI.printSensorMax(sensor, max);
                dieUI.printSensorMin(sensor, min);
                dieUI.printSensorHottest(sensor, hottest);
            }
        }
    }
}