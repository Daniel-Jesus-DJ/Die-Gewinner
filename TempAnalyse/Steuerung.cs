namespace TempAnalyse
{
    internal class Steuerung
    {
        private UI dieUI; 
        string[] data = File.ReadAllLines("../../../CSV/Input.csv");

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
    }
}