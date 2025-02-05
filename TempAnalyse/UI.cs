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

    private void LB_Temp_SelectedIndexChanged(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}