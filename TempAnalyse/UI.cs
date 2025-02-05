namespace TempAnalyse;

public partial class UI : Form
{
    private Steuerung dieSteuerung;
    public UI()
    {
        InitializeComponent();
        dieSteuerung = new Steuerung(this);
        CBB_time.Items.AddRange(new object[] {"Letzen Monat",
            "Letzen 3 Monate",
            "Letzes Jahr",
            "Letzten 5 Jahre",
            "Seit beginn"});
        CBB_time.TabIndex = 3;
        //LB_Temp.Items.Add(dieSteuerung.getDurchschnitt() + " °C");
    }

    private void UI_Load(object sender, EventArgs e)
    {
        
    }

    private void B_auswerten_Click(object sender, EventArgs e)
    {
        dieSteuerung.setTime(CBB_time.SelectedIndex);
        dieSteuerung.setData();
    }

    public void printDebug(string debug)
    {
        L_Debug.Text = debug;
    }

    public void printSensorAverage(string sensor, double temperature)
    {
        Label label = null;
        switch (sensor)
        {
            case "S1":
                label = L_S1_durchschnitt;
                break;
            case "S2":
                label = L_S2_durchschnitt;
                break;
            case "S3":
                label = L_S3_durchschnitt;
                break;
            case "S4":
                label = L_S4_durchschnitt;
                break;
            case "SB":
                label = L_SB_durchschnitt;
                break;
            case "SD":
                label = L_SD_durchschnitt;
                break;
        }

        if (label != null)
        {
            label.Text = temperature + " °C";
            if (temperature <= 30)
            {
                label.ForeColor = Color.Green;
            }
            else if (temperature <= 50)
            {
                label.ForeColor = Color.Orange;
            }
            else
            {
                label.ForeColor = Color.Red;
            }
        }
    }
    public void printSensorMax(string sensor, double temperature)
    {
        Label label = null;
        switch (sensor)
        {
            case "S1":
                label = L_S1_max;
                break;
            case "S2":
                label = L_S2_max;
                break;
            case "S3":
                label = L_S3_max;
                break;
            case "S4":
                label = L_S4_max;
                break;
            case "SB":
                label = L_SB_max;
                break;
            case "SD":
                label = L_SD_max;
                break;
        }

        if (label != null)
        {
            label.Text = temperature + " °C";
            if (temperature <= 30)
            {
                label.ForeColor = Color.Green;
            }
            else if (temperature <= 50)
            {
                label.ForeColor = Color.Orange;
            }
            else
            {
                label.ForeColor = Color.Red;
            }
        }
    }
    public void printSensorMin(string sensor, double temperature)
    {
        Label label = null;
        switch (sensor)
        {
            case "S1":
                label = L_S1_min;
                break;
            case "S2":
                label = L_S2_min;
                break;
            case "S3":
                label = L_S3_min;
                break;
            case "S4":
                label = L_S4_min;
                break;
            case "SB":
                label = L_SB_min;
                break;
            case "SD":
                label = L_SD_min;
                break;
        }

        if (label != null)
        {
            label.Text = temperature + " °C";
            if (temperature <= 30)
            {
                label.ForeColor = Color.Green;
            }
            else if (temperature <= 50)
            {
                label.ForeColor = Color.Orange;
            }
            else
            {
                label.ForeColor = Color.Red;
            }
        }
    }
    public void printSensorHottest(string sensor, string timestamp)
    {
        Label label = null;
        switch (sensor)
        {
            case "S1":
                label = L_S1_hottest;
                break;
            case "S2":
                label = L_S2_hottest;
                break;
            case "S3":
                label = L_S3_hottest;
                break;
            case "S4":
                label = L_S4_hottest;
                break;
            case "SB":
                label = L_SB_hottest;
                break;
            case "SD":
                label = L_SD_hottest;
                break;
        }

        if (label != null)
        {
            label.Text = timestamp;
        }
    }

    public void printMessage(string message)
    {
        MessageBox.Show(message);
    }
}