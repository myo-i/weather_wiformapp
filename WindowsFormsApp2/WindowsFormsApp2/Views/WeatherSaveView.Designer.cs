namespace WindowsFormsApp2.Views
{
    partial class WeatherSaveView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.SaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AreaIdcomboBox = new System.Windows.Forms.ComboBox();
            this.ConditionComboBox = new System.Windows.Forms.ComboBox();
            this.DateTimeTextBox = new System.Windows.Forms.DateTimePicker();
            this.TemperatureTextBox = new System.Windows.Forms.TextBox();
            this.UnitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(44, 26);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "地域";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "日時";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "状態";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "温度";
            // 
            // AreaIdcomboBox
            // 
            this.AreaIdcomboBox.FormattingEnabled = true;
            this.AreaIdcomboBox.Location = new System.Drawing.Point(113, 110);
            this.AreaIdcomboBox.Name = "AreaIdcomboBox";
            this.AreaIdcomboBox.Size = new System.Drawing.Size(121, 20);
            this.AreaIdcomboBox.TabIndex = 6;
            // 
            // ConditionComboBox
            // 
            this.ConditionComboBox.FormattingEnabled = true;
            this.ConditionComboBox.Location = new System.Drawing.Point(113, 226);
            this.ConditionComboBox.Name = "ConditionComboBox";
            this.ConditionComboBox.Size = new System.Drawing.Size(121, 20);
            this.ConditionComboBox.TabIndex = 8;
            // 
            // DateTimeTextBox
            // 
            this.DateTimeTextBox.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.DateTimeTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeTextBox.Location = new System.Drawing.Point(113, 170);
            this.DateTimeTextBox.Name = "DateTimeTextBox";
            this.DateTimeTextBox.Size = new System.Drawing.Size(200, 19);
            this.DateTimeTextBox.TabIndex = 9;
            // 
            // TemperatureTextBox
            // 
            this.TemperatureTextBox.Location = new System.Drawing.Point(113, 284);
            this.TemperatureTextBox.Name = "TemperatureTextBox";
            this.TemperatureTextBox.Size = new System.Drawing.Size(100, 19);
            this.TemperatureTextBox.TabIndex = 10;
            // 
            // UnitLabel
            // 
            this.UnitLabel.AutoSize = true;
            this.UnitLabel.Location = new System.Drawing.Point(232, 291);
            this.UnitLabel.Name = "UnitLabel";
            this.UnitLabel.Size = new System.Drawing.Size(19, 12);
            this.UnitLabel.TabIndex = 12;
            this.UnitLabel.Text = "XX";
            // 
            // WeatherSaveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 370);
            this.Controls.Add(this.UnitLabel);
            this.Controls.Add(this.TemperatureTextBox);
            this.Controls.Add(this.DateTimeTextBox);
            this.Controls.Add(this.ConditionComboBox);
            this.Controls.Add(this.AreaIdcomboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveButton);
            this.Name = "WeatherSaveView";
            this.Text = "WeatherSaveView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AreaIdcomboBox;
        private System.Windows.Forms.ComboBox ConditionComboBox;
        private System.Windows.Forms.DateTimePicker DateTimeTextBox;
        private System.Windows.Forms.TextBox TemperatureTextBox;
        private System.Windows.Forms.Label UnitLabel;
    }
}