namespace TempAnalyse;

partial class UI
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        CBB_time = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        B_auswerten = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // CBB_time
        // 
        CBB_time.FormattingEnabled = true;
        CBB_time.Location = new System.Drawing.Point(117, 11);
        CBB_time.Name = "CBB_time";
        CBB_time.Size = new System.Drawing.Size(121, 28);
        CBB_time.TabIndex = 2;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(11, 16);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 3;
        label1.Text = "Zeitraum";
        // 
        // B_auswerten
        // 
        B_auswerten.Location = new System.Drawing.Point(270, 11);
        B_auswerten.Name = "B_auswerten";
        B_auswerten.Size = new System.Drawing.Size(185, 28);
        B_auswerten.TabIndex = 4;
        B_auswerten.Text = "Auswerten";
        B_auswerten.UseVisualStyleBackColor = true;
        // 
        // UI
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(B_auswerten);
        Controls.Add(label1);
        Controls.Add(CBB_time);
        Text = "UI";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button B_auswerten;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.ComboBox CBB_time;

    private System.Windows.Forms.DataGridView dataGridView1;

    #endregion
}