using System.Globalization;
using System.IO;
namespace TempAnalyse
{
    public class Steuerung
    {
        private UI dieUI; 
        string[] data = File.ReadAllLines("../../../CSV/Input.csv");
        string[] sensors = {"S1", "S2", "S3", "S4", "SB", "SD"};
        private int time = 0;
        private int chartMode = 0; // 0 = hourly, 1 = daily

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
            bool showMonth = true;
            bool showYear = true;
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
                            showMonth = false;
                            showYear = false;
                        }
                        break;
                    case 1: // Letzten 3 Monate
                        if (timestamp.Date >= latestTimestamp.AddMonths(-3).Date)
                        {
                            filteredData.Add(line);
                            showYear = false;
                        }
                        break;
                    case 2: // Letztes Jahr
                        if(timestamp.Date >= latestTimestamp.AddYears(-1).Date)
                        {
                            filteredData.Add(line);
                            showYear = false;
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
                    case 5: // Eingabe Jahr
                        int year = dieUI.getSelectedYear();
                        if (timestamp.Year == year)
                        {
                            filteredData.Add(line);
                            showYear = false;
                        }
                        break;
                    default:
                        dieUI.printMessage("Ungültiger Zeitraum");
                        return;
                }
            }

            if (filteredData.Count == 0)
            {
                dieUI.printMessage("Keine Daten gefunden");
                return;
            }

            data = filteredData.ToArray();
            calculate();
            if(showMonth) calculateMonth();
            else dieUI.printMonth("N/A");
            if(showYear) calculateYear();
            else dieUI.printYear("N/A");
        }

        private void renewData()
        {
            data = File.ReadAllLines("../../../CSV/Input.csv");
        }

        private void calculate()
        {
            foreach (var sensor in sensors)
            {
                string hottest = "N/A";
                double hottestTemp = 0;
                List<double> temperatures = new List<double>();
                List<string> sensorData = new List<string>();
                foreach (var line in data)
                {
                    var sensorID = line.Split(",").First();
                    if (sensorID != sensor) continue;
                    double temperatur = Convert.ToDouble(line.Split(",").Last(), CultureInfo.InvariantCulture);
                    temperatures.Add(temperatur);
                    sensorData.Add(line);
                    if (temperatur > hottestTemp)
                    {
                        hottestTemp = temperatur;
                        hottest = line.Split(",")[1];
                    }
                }
                
                double average = Math.Round(temperatures.Average(), 1);
                double max = Math.Round(temperatures.Max(),1);
                double min = Math.Round(temperatures.Min(), 1);
                dieUI.printSensorAverage(sensor, average);
                dieUI.printSensorMax(sensor, max);
                dieUI.printSensorMin(sensor, min);
                dieUI.printSensorHottest(sensor, DateTime.Parse(hottest).ToString("dd.MM.yyyy"));
            }
        }

        private void calculateMonth()
        {
            var monthlyTemperatures = new Dictionary<int, List<(DateTime timestamp, double temperature)>>();

            foreach (var line in data)
            {
                var parts = line.Split(',');
                DateTime timestamp = DateTime.ParseExact(parts[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                double temperature = Convert.ToDouble(parts.Last(), CultureInfo.InvariantCulture);

                int month = timestamp.Month;
                if (!monthlyTemperatures.ContainsKey(month))
                {
                    monthlyTemperatures[month] = new List<(DateTime, double)>();
                }
                monthlyTemperatures[month].Add((timestamp, temperature));
            }

            int highestAvgMonth = 0;
            double highestAvgTemp = double.MinValue;
            DateTime highestAvgTimestamp = DateTime.MinValue;

            foreach (var month in monthlyTemperatures.Keys)
            {
                double avgTemp = monthlyTemperatures[month].Average(x => x.temperature);
                if (avgTemp > highestAvgTemp)
                {
                    highestAvgTemp = avgTemp;
                    highestAvgMonth = month;
                    highestAvgTimestamp = monthlyTemperatures[month].First().timestamp;
                }
            }

            dieUI.printMonth(highestAvgTimestamp.ToString("MMMM yyyy"));
        }
        
        private void calculateYear()
        {
            var yearlyTemperatures = new Dictionary<int, List<double>>();

            foreach (var line in data)
            {
                var parts = line.Split(',');
                DateTime timestamp = DateTime.ParseExact(parts[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                double temperature = Convert.ToDouble(parts.Last(), CultureInfo.InvariantCulture);

                int year = timestamp.Year;
                if (!yearlyTemperatures.ContainsKey(year))
                {
                    yearlyTemperatures[year] = new List<double>();
                }
                yearlyTemperatures[year].Add(temperature);
            }

            int highestAvgYear = 0;
            double highestAvgTemp = double.MinValue;

            foreach (var year in yearlyTemperatures.Keys)
            {
                double avgTemp = yearlyTemperatures[year].Average();
                if (avgTemp > highestAvgTemp)
                {
                    highestAvgTemp = avgTemp;
                    highestAvgYear = year;
                }
            }

            dieUI.printYear(highestAvgYear.ToString());
        }

        private string[] sortByDaytime()
        {
            return data.OrderBy(line => DateTime.ParseExact(line.Split(',')[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).TimeOfDay).ToArray();
        }
        
        public Dictionary<int, (double average, double min, double max)> CalculateHourlyAverages(string sensorID = "")
        {
            var sortedData = sortByDaytime();
            var hourlyTemperatures = new Dictionary<int, List<double>>();

            foreach (var line in sortedData)
            {
                var parts = line.Split(',');
                if (!string.IsNullOrEmpty(sensorID) && parts[0] != sensorID) continue;

                DateTime timestamp = DateTime.ParseExact(parts[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                double temperature = Convert.ToDouble(parts.Last(), CultureInfo.InvariantCulture);

                int hour = timestamp.Hour;
                if (!hourlyTemperatures.ContainsKey(hour))
                {
                    hourlyTemperatures[hour] = new List<double>();
                }
                hourlyTemperatures[hour].Add(temperature);
            }

            var hourlyStats = new Dictionary<int, (double average, double min, double max)>();
            foreach (var hour in hourlyTemperatures.Keys)
            {
                var temperatures = hourlyTemperatures[hour];
                hourlyStats[hour] = (
                    average: Math.Round(temperatures.Average(), 2),
                    min: Math.Round(temperatures.Min(), 2),
                    max: Math.Round(temperatures.Max(), 2)
                );
            }

            return hourlyStats;
        }
        
        public (Dictionary<int, (double average, double min, double max)>, List<string>) CalculateDailyAverages(string sensorID = "")
        {
            var sortedData = data.OrderBy(line => DateTime.ParseExact(line.Split(',')[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).Date).ToArray();
            var dailyTemperatures = new Dictionary<int, List<double>>();
            var timestamps = new List<string>();

            int dayIndex = 0;
            DateTime? previousDay = null;

            foreach (var line in sortedData)
            {
                var parts = line.Split(',');
                if (!string.IsNullOrEmpty(sensorID) && parts[0] != sensorID) continue;

                DateTime timestamp = DateTime.ParseExact(parts[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                double temperature = Convert.ToDouble(parts.Last(), CultureInfo.InvariantCulture);

                DateTime day = timestamp.Date;
                if (previousDay == null || day != previousDay)
                {
                    previousDay = day;
                    timestamps.Add(day.ToString("yyyy-MM-dd"));
                    dayIndex++;
                }

                if (!dailyTemperatures.ContainsKey(dayIndex))
                {
                    dailyTemperatures[dayIndex] = new List<double>();
                }
                dailyTemperatures[dayIndex].Add(temperature);
            }

            var dailyStats = new Dictionary<int, (double average, double min, double max)>();
            foreach (var day in dailyTemperatures.Keys)
            {
                var temperatures = dailyTemperatures[day];
                dailyStats[day] = (
                    average: Math.Round(temperatures.Average(), 2),
                    min: Math.Round(temperatures.Min(), 2),
                    max: Math.Round(temperatures.Max(), 2)
                );
            }

            return (dailyStats, timestamps);
        }
        
        public void setChartMode(int index)
        {
            chartMode = index;
        }
        
        public int getChartMode()
        {
            return chartMode;
        }
    }
}