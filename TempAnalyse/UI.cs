namespace TempAnalyse;

public partial class UI : Form
{
    private Steuerung dieSteuerung;
    private int selectedYear = 0; 
    public UI()
    {
        InitializeComponent();
        dieSteuerung = new Steuerung(this);
        CBB_time.Items.AddRange(new object[] {"Letzen Monat",
            "Letzen 3 Monate",
            "Letzes Jahr",
            "Letzten 5 Jahre",
            "Seit beginn",
            "Jahr auswählen"
        });
        CBB_time.SelectedIndex = 0;
    }

    private void UI_Load(object sender, EventArgs e)
    {
        
    }

    private void B_auswerten_Click(object sender, EventArgs e)
    {
        if(TB_year.Visible && TB_year.Text != "")
        {
            selectedYear = Convert.ToInt32(TB_year.Text);
        }
        dieSteuerung.setTime(CBB_time.SelectedIndex);
        dieSteuerung.setData();
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
            if (temperature <= 40)
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

    public void printMonth(string str)
    {
        L_hottest_month.Text = str;
    }
    
    public void printYear(string str)
    {
        L_hottest_year.Text = str;
    }

    public void printMessage(string message)
    {
        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void CBB_time_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(CBB_time.SelectedIndex == 5) TB_year.Visible = true;
        else TB_year.Visible = false;
    }
    
    public int getSelectedYear()
    {
        return selectedYear;
    }

    private void B_chart_Click(object sender, EventArgs e)
    {
        dieSteuerung.setChartMode(0);
        dieSteuerung.setTime(CBB_time.SelectedIndex);
        dieSteuerung.setData();
        Chart chartForm = new Chart(dieSteuerung);
        chartForm.Show();
    }

    private void B_chartDays_Click(object sender, EventArgs e)
    {
        dieSteuerung.setChartMode(1);
        dieSteuerung.setTime(CBB_time.SelectedIndex);
        dieSteuerung.setData();
        Chart chartForm = new Chart(dieSteuerung);
        chartForm.Show();
    }

    private void B_heat_Click(object sender, EventArgs e)
    {
        if(TB_year.Visible && TB_year.Text != "")
        {
            selectedYear = Convert.ToInt32(TB_year.Text);
        }
        dieSteuerung.setTime(CBB_time.SelectedIndex);
        dieSteuerung.setData();
        Heat heatForm = new Heat(dieSteuerung);
        heatForm.Show();
    }
}