namespace TempAnalyse;
using System.Globalization;

public partial class Heat : Form
{
    private Steuerung dieSteuerung;
    public Heat(Steuerung pSteuerung)
    {
        InitializeComponent();
        dieSteuerung = pSteuerung;
        heatPeaks(dieSteuerung.getData());
    }

    private void heatPeaks(string[] data)
    {
        var cultureInfo = new CultureInfo("de-DE");
        int[] sensorCount = new int[6];
        foreach (var line in data)
        {
            var values = line.Split(',');
            var temp = Math.Round(Convert.ToDouble(values[2], CultureInfo.InvariantCulture), 2);
            if (temp >= 60.00)
            {
                LB_heat.Items.Add((DateTime.Parse(values[1]).ToString("d", cultureInfo)) + "    " + values[0] + "       " + values[2] + " °C");
                switch (values[0])
                {
                    case "S1":
                        sensorCount[0]++;
                        break;
                    case "S2":
                        sensorCount[1]++;
                        break;
                    case "S3":
                        sensorCount[2]++;
                        break;
                    case "S4":
                        sensorCount[3]++;
                        break;
                    case "SB":
                        sensorCount[4]++;
                        break;
                    case "SD":
                        sensorCount[5]++;
                        break;
                }
            }
        }
        LB_count.Items.Add($"S1: {sensorCount[0]}x");
        LB_count.Items.Add($"S2: {sensorCount[1]}x");
        LB_count.Items.Add($"S3: {sensorCount[2]}x");
        LB_count.Items.Add($"S4: {sensorCount[3]}x");
        LB_count.Items.Add($"SB: {sensorCount[4]}x");
        LB_count.Items.Add($"SD: {sensorCount[5]}x");
    }
}