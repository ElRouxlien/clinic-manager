namespace BaseTPFinal2526
{
    partial class ManageDoctorsForm
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
            groupBox2 = new GroupBox();
            cmbSpecialty = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            txtINAMINumber = new TextBox();
            label6 = new Label();
            numConsultationFee = new NumericUpDown();
            btnSave = new Button();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numConsultationFee).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbSpecialty);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtINAMINumber);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numConsultationFee);
            groupBox2.Location = new Point(18, 232);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(757, 155);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Doctor Info";
            // 
            // cmbSpecialty
            // 
            cmbSpecialty.FormattingEnabled = true;
            cmbSpecialty.Location = new Point(6, 117);
            cmbSpecialty.Name = "cmbSpecialty";
            cmbSpecialty.Size = new Size(182, 33);
            cmbSpecialty.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 89);
            label8.Name = "label8";
            label8.Size = new Size(82, 25);
            label8.TabIndex = 4;
            label8.Text = "Specialty";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(282, 27);
            label7.Name = "label7";
            label7.Size = new Size(144, 25);
            label7.TabIndex = 3;
            label7.Text = "Consultation Fee";
            // 
            // txtINAMINumber
            // 
            txtINAMINumber.Location = new Point(6, 55);
            txtINAMINumber.Name = "txtINAMINumber";
            txtINAMINumber.Size = new Size(182, 31);
            txtINAMINumber.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 27);
            label6.Name = "label6";
            label6.Size = new Size(173, 25);
            label6.TabIndex = 1;
            label6.Text = "INAMI (11 numbers)";
            // 
            // numConsultationFee
            // 
            numConsultationFee.DecimalPlaces = 2;
            numConsultationFee.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numConsultationFee.Location = new Point(282, 55);
            numConsultationFee.Name = "numConsultationFee";
            numConsultationFee.Size = new Size(180, 31);
            numConsultationFee.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Location = new Point(0, 393);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(800, 57);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ManageDoctorsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(groupBox2);
            Name = "ManageDoctorsForm";
            Text = "ManageDoctorsForm";
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(btnSave, 0);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numConsultationFee).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private NumericUpDown numConsultationFee;
        private Button btnSave;
        private ComboBox cmbSpecialty;
        private Label label8;
        private Label label7;
        private TextBox txtINAMINumber;
        private Label label6;
    }
}