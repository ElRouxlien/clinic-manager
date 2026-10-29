namespace BaseTPFinal2526
{
    partial class DisplayPersonsForm
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
            dgvPersons = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Firstname = new DataGridViewTextBoxColumn();
            Lastname = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            BirthDate = new DataGridViewTextBoxColumn();
            MedicalRecordNumber = new DataGridViewTextBoxColumn();
            IsInsured = new DataGridViewTextBoxColumn();
            INAMINumber = new DataGridViewTextBoxColumn();
            ConsultationFee = new DataGridViewTextBoxColumn();
            btnAddPerson = new Button();
            btnDeletePerson = new Button();
            btnEditPerson = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPersons).BeginInit();
            SuspendLayout();
            // 
            // dgvPersons
            // 
            dgvPersons.AllowUserToAddRows = false;
            dgvPersons.AllowUserToDeleteRows = false;
            dgvPersons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersons.Columns.AddRange(new DataGridViewColumn[] { Id, Firstname, Lastname, Email, Phone, BirthDate, MedicalRecordNumber, IsInsured, INAMINumber, ConsultationFee });
            dgvPersons.Location = new Point(12, 12);
            dgvPersons.Name = "dgvPersons";
            dgvPersons.ReadOnly = true;
            dgvPersons.RowHeadersWidth = 62;
            dgvPersons.Size = new Size(1505, 756);
            dgvPersons.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 8;
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Firstname
            // 
            Firstname.HeaderText = "Firstname";
            Firstname.MinimumWidth = 8;
            Firstname.Name = "Firstname";
            Firstname.ReadOnly = true;
            // 
            // Lastname
            // 
            Lastname.HeaderText = "Lastname";
            Lastname.MinimumWidth = 8;
            Lastname.Name = "Lastname";
            Lastname.ReadOnly = true;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 8;
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // Phone
            // 
            Phone.HeaderText = "Phone";
            Phone.MinimumWidth = 8;
            Phone.Name = "Phone";
            Phone.ReadOnly = true;
            // 
            // BirthDate
            // 
            BirthDate.HeaderText = "Birth Date";
            BirthDate.MinimumWidth = 8;
            BirthDate.Name = "BirthDate";
            BirthDate.ReadOnly = true;
            // 
            // MedicalRecordNumber
            // 
            MedicalRecordNumber.HeaderText = "Medical Record Number";
            MedicalRecordNumber.MinimumWidth = 8;
            MedicalRecordNumber.Name = "MedicalRecordNumber";
            MedicalRecordNumber.ReadOnly = true;
            // 
            // IsInsured
            // 
            IsInsured.HeaderText = "Is Insured ?";
            IsInsured.MinimumWidth = 8;
            IsInsured.Name = "IsInsured";
            IsInsured.ReadOnly = true;
            // 
            // INAMINumber
            // 
            INAMINumber.HeaderText = "INAMI Number";
            INAMINumber.MinimumWidth = 8;
            INAMINumber.Name = "INAMINumber";
            INAMINumber.ReadOnly = true;
            // 
            // ConsultationFee
            // 
            ConsultationFee.HeaderText = "Consultation Fee";
            ConsultationFee.MinimumWidth = 8;
            ConsultationFee.Name = "ConsultationFee";
            ConsultationFee.ReadOnly = true;
            // 
            // btnAddPerson
            // 
            btnAddPerson.Location = new Point(12, 774);
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.Size = new Size(491, 152);
            btnAddPerson.TabIndex = 1;
            btnAddPerson.Text = "Add Person";
            btnAddPerson.UseVisualStyleBackColor = true;
            btnAddPerson.Click += btnAddPerson_Click;
            // 
            // btnDeletePerson
            // 
            btnDeletePerson.Location = new Point(1026, 774);
            btnDeletePerson.Name = "btnDeletePerson";
            btnDeletePerson.Size = new Size(491, 152);
            btnDeletePerson.TabIndex = 2;
            btnDeletePerson.Text = "Delete Person";
            btnDeletePerson.UseVisualStyleBackColor = true;
            btnDeletePerson.Click += btnDeletePerson_Click;
            // 
            // btnEditPerson
            // 
            btnEditPerson.Location = new Point(518, 774);
            btnEditPerson.Name = "btnEditPerson";
            btnEditPerson.Size = new Size(491, 152);
            btnEditPerson.TabIndex = 3;
            btnEditPerson.Text = "Edit Person";
            btnEditPerson.UseVisualStyleBackColor = true;
            btnEditPerson.Click += btnEditPerson_Click;
            // 
            // DisplayPersonsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1529, 932);
            Controls.Add(btnEditPerson);
            Controls.Add(btnDeletePerson);
            Controls.Add(btnAddPerson);
            Controls.Add(dgvPersons);
            Name = "DisplayPersonsForm";
            Text = "ManagaPersonsForm";
            Load += DisplayPersonsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPersons).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPersons;
        private Button btnAddPerson;
        private Button btnDeletePerson;
        private Button btnEditPerson;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Firstname;
        private DataGridViewTextBoxColumn Lastname;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn BirthDate;
        private DataGridViewTextBoxColumn MedicalRecordNumber;
        private DataGridViewTextBoxColumn IsInsured;
        private DataGridViewTextBoxColumn INAMINumber;
        private DataGridViewTextBoxColumn ConsultationFee;
    }
}