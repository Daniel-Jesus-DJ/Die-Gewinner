using System.Collections.ObjectModel;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Windows.Forms;
using System.Globalization;

namespace TempAnalyse
{
    public partial class Chart : Form
    {
        private Steuerung dieSteuerung;
        private IEnumerable<double> average;
        private IEnumerable<double> min;        
        private IEnumerable<double> max;
        private int chartMode = 0;
        private List<string> timestamps;

        public Chart(Steuerung pSteuerung)
        {
            InitializeComponent();
            dieSteuerung = pSteuerung;
            chartMode = dieSteuerung.getChartMode();
            if(chartMode == 0) InitializeChart(dieSteuerung.CalculateHourlyAverages());
            else if(chartMode == 1) {
                timestamps = dieSteuerung.CalculateDailyAverages().Item2; 
                InitializeChart(dieSteuerung.CalculateDailyAverages().Item1);
            }
            CBB_sensor.Items.AddRange(new object[] {"Alle", "S1", "S2", "S3", "S4", "SB", "SD"});
            CBB_sensor.SelectedIndex = 0;
        }

        private void InitializeChart(Dictionary<int, (double average, double min, double max)> tempData)
        {
            clearChart();
            average = tempData.Values.Select(v => v.average);
            min = tempData.Values.Select(v => v.min);
            max = tempData.Values.Select(v => v.max);
            string axisXName = chartMode == 0 ? "Uhrzeit" : "Datum";
            var cultureInfo = new CultureInfo("de-DE");

            chartVisual.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Durchschnittliche Temperatur",
                    Values = new ChartValues<double>(average),
                    Stroke = System.Windows.Media.Brushes.Blue,
                }
            };

            chartVisual.AxisX.Add(new Axis
            {
                
                Title = axisXName,
                Labels = chartMode == 0 ? tempData.Keys.Select(k => k.ToString()).ToArray() : timestamps.Select(ts => DateTime.Parse(ts).ToString("d", cultureInfo)).ToArray(),
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false
                },
                MinValue = 0,
                MaxValue = 30,
            });

            chartVisual.AxisY.Add(new Axis
            {
                Title = "Temperatur (°C)",
                LabelFormatter = val => val.ToString("F1") + " °C",
            });
            
            if (chartMode == 1) {
                //chartVisual.Zoom = ZoomingOptions.X;
                chartVisual.Hoverable = false;   
                chartVisual.AxisX[0].LabelsRotation = 45;
                if(tempData.Count > 30) chartVisual.Pan = PanningOptions.X;
            }
            else
            {
                //chartVisual.Zoom = ZoomingOptions.None;
                chartVisual.Pan = PanningOptions.None;
                chartVisual.Hoverable = true;
                chartVisual.AxisX[0].LabelsRotation = 0;
            }
        }

        private void clearChart()
        {
            chartVisual.Series.Clear();
            chartVisual.AxisX.Clear();
            chartVisual.AxisY.Clear();
        }

        private void B_showMin_Click(object sender, EventArgs e)
        {
            chartVisual.Series.Add(new LineSeries
            {
                Title = "Minimale Temperatur",
                Values = new ChartValues<double>(min),
                Stroke = System.Windows.Media.Brushes.Green
            });
        }

        private void B_showMax_Click(object sender, EventArgs e)
        {
            chartVisual.Series.Add(new LineSeries
            {
                Title = "Maximale Temperatur",
                Values = new ChartValues<double>(max),
                Stroke = System.Windows.Media.Brushes.Red
            });
        }

        private void B_showSensor_Click(object sender, EventArgs e)
        {
            if (CBB_sensor.SelectedIndex == 0)
            {
                return;
            }

            if (chartMode == 0)
            {
                var newData = dieSteuerung.CalculateHourlyAverages(CBB_sensor.SelectedItem.ToString());
                InitializeChart(newData);
            } else if (chartMode == 1)
            {
                var newData = dieSteuerung.CalculateDailyAverages(CBB_sensor.SelectedItem.ToString());
                timestamps = newData.Item2;
                InitializeChart(newData.Item1);
            }

        }
    }
}