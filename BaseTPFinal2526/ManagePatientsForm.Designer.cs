namespace BaseTPFinal2526
{
    partial class ManagePatientsForm
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
            label7 = new Label();
            dtpBirthDate = new DateTimePicker();
            chkIsInsured = new CheckBox();
            label6 = new Label();
            txtMedicalRecord = new TextBox();
            btnSave = new Button();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(dtpBirthDate);
            groupBox2.Controls.Add(chkIsInsured);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtMedicalRecord);
            groupBox2.Location = new Point(18, 232);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(757, 130);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Patient Infos";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(414, 27);
            label7.Name = "label7";
            label7.Size = new Size(90, 25);
            label7.TabIndex = 3;
            label7.Text = "Birth Date";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(414, 56);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(300, 31);
            dtpBirthDate.TabIndex = 2;
            // 
            // chkIsInsured
            // 
            chkIsInsured.AutoSize = true;
            chkIsInsured.Location = new Point(414, 93);
            chkIsInsured.Name = "chkIsInsured";
            chkIsInsured.Size = new Size(128, 29);
            chkIsInsured.TabIndex = 1;
            chkIsInsured.Text = "Is Insured ?";
            chkIsInsured.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 65);
            label6.Name = "label6";
            label6.Size = new Size(301, 25);
            label6.TabIndex = 1;
            label6.Text = "Medical Record Number (min 4 char)";
            // 
            // txtMedicalRecord
            // 
            txtMedicalRecord.Location = new Point(6, 93);
            txtMedicalRecord.Name = "txtMedicalRecord";
            txtMedicalRecord.Size = new Size(203, 31);
            txtMedicalRecord.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Location = new Point(0, 393);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(800, 57);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ManagePatientsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(groupBox2);
            Name = "ManagePatientsForm";
            Text = "ManagePatientsForm";
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(btnSave, 0);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private TextBox txtMedicalRecord;
        private CheckBox chkIsInsured;
        private Label label6;
        private Button btnSave;
        private Label label7;
        private DateTimePicker dtpBirthDate;
    }
}