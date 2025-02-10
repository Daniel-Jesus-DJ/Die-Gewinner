using System.ComponentModel;

namespace TempAnalyse;

partial class Chart
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        chartVisual = new LiveCharts.WinForms.CartesianChart();
        B_showMin = new System.Windows.Forms.Button();
        B_showMax = new System.Windows.Forms.Button();
        CBB_sensor = new System.Windows.Forms.ComboBox();
        B_showSensor = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // chartVisual
        // 
        chartVisual.Location = new System.Drawing.Point(6, -1);
        chartVisual.Name = "chartVisual";
        chartVisual.Size = new System.Drawing.Size(729, 450);
        chartVisual.TabIndex = 0;
        chartVisual.Text = "MainChart";
        // 
        // B_showMin
        // 
        B_showMin.Location = new System.Drawing.Point(741, 24);
        B_showMin.Name = "B_showMin";
        B_showMin.Size = new System.Drawing.Size(121, 37);
        B_showMin.TabIndex = 1;
        B_showMin.Text = "Min";
        B_showMin.UseVisualStyleBackColor = true;
        B_showMin.Click += B_showMin_Click;
        // 
        // B_showMax
        // 
        B_showMax.Location = new System.Drawing.Point(741, 67);
        B_showMax.Name = "B_showMax";
        B_showMax.Size = new System.Drawing.Size(121, 37);
        B_showMax.TabIndex = 2;
        B_showMax.Text = "Max";
        B_showMax.UseVisualStyleBackColor = true;
        B_showMax.Click += B_showMax_Click;
        // 
        // CBB_sensor
        // 
        CBB_sensor.FormattingEnabled = true;
        CBB_sensor.Location = new System.Drawing.Point(741, 110);
        CBB_sensor.Name = "CBB_sensor";
        CBB_sensor.Size = new System.Drawing.Size(121, 28);
        CBB_sensor.TabIndex = 3;
        // 
        // B_showSensor
        // 
        B_showSensor.Location = new System.Drawing.Point(741, 144);
        B_showSensor.Name = "B_showSensor";
        B_showSensor.Size = new System.Drawing.Size(121, 37);
        B_showSensor.TabIndex = 4;
        B_showSensor.Text = "Auswerten";
        B_showSensor.UseVisualStyleBackColor = true;
        B_showSensor.Click += B_showSensor_Click;
        // 
        // Chart
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(876, 490);
        Controls.Add(B_showSensor);
        Controls.Add(CBB_sensor);
        Controls.Add(B_showMax);
        Controls.Add(B_showMin);
        Controls.Add(chartVisual);
        Text = "Chart";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox CBB_sensor;
    private System.Windows.Forms.Button B_showSensor;

    private System.Windows.Forms.Button B_showMin;
    private System.Windows.Forms.Button B_showMax;

    private LiveCharts.WinForms.CartesianChart chartVisual;

    #endregion
}