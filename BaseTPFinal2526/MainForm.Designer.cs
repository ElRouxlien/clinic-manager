namespace BaseTPFinal2526
{
    partial class MainForm
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnManagePatients = new Button();
            btnManageDoctors = new Button();
            btnManageConsultations = new Button();
            SuspendLayout();
            // 
            // btnManagePatients
            // 
            btnManagePatients.Location = new Point(12, 12);
            btnManagePatients.Name = "btnManagePatients";
            btnManagePatients.Size = new Size(567, 398);
            btnManagePatients.TabIndex = 0;
            btnManagePatients.Text = "Patients";
            btnManagePatients.UseVisualStyleBackColor = true;
            btnManagePatients.Click += btnManagePatients_Click;
            // 
            // btnManageDoctors
            // 
            btnManageDoctors.Location = new Point(648, 12);
            btnManageDoctors.Name = "btnManageDoctors";
            btnManageDoctors.Size = new Size(567, 398);
            btnManageDoctors.TabIndex = 1;
            btnManageDoctors.Text = "Doctors";
            btnManageDoctors.UseVisualStyleBackColor = true;
            btnManageDoctors.Click += btnManageDoctors_Click;
            // 
            // btnManageConsultations
            // 
            btnManageConsultations.Location = new Point(12, 441);
            btnManageConsultations.Name = "btnManageConsultations";
            btnManageConsultations.Size = new Size(1203, 378);
            btnManageConsultations.TabIndex = 2;
            btnManageConsultations.Text = "Consultations";
            btnManageConsultations.UseVisualStyleBackColor = true;
            btnManageConsultations.Click += btnManageConsultations_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1227, 831);
            Controls.Add(btnManageConsultations);
            Controls.Add(btnManageDoctors);
            Controls.Add(btnManagePatients);
            Name = "MainForm";
            Text = "Main Form";
            ResumeLayout(false);
        }

        #endregion

        private Button btnManagePatients;
        private Button btnManageDoctors;
        private Button btnManageConsultations;
    }
}
