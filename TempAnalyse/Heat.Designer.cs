using System.ComponentModel;

namespace TempAnalyse;

partial class Heat
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
        LB_heat = new System.Windows.Forms.ListBox();
        LB_count = new System.Windows.Forms.ListBox();
        SuspendLayout();
        // 
        // LB_heat
        // 
        LB_heat.FormattingEnabled = true;
        LB_heat.Location = new System.Drawing.Point(7, 7);
        LB_heat.Name = "LB_heat";
        LB_heat.Size = new System.Drawing.Size(303, 564);
        LB_heat.TabIndex = 0;
        // 
        // LB_count
        // 
        LB_count.FormattingEnabled = true;
        LB_count.Location = new System.Drawing.Point(316, 7);
        LB_count.Name = "LB_count";
        LB_count.Size = new System.Drawing.Size(120, 154);
        LB_count.TabIndex = 1;
        // 
        // Heat
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(454, 598);
        Controls.Add(LB_count);
        Controls.Add(LB_heat);
        Text = "Heat";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox LB_count;

    private System.Windows.Forms.ListBox LB_heat;

    #endregion
}