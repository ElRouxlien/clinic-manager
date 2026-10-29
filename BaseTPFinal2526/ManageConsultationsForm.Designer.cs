namespace BaseTPFinal2526
{
    public partial class ManageConsultationsForm :Form
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
            cmbDoc = new ComboBox();
            cmbPatient = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            dtpDate = new DateTimePicker();
            label3 = new Label();
            nudDuration = new NumericUpDown();
            label4 = new Label();
            cmbType = new ComboBox();
            label5 = new Label();
            txtTotalFee = new TextBox();
            label6 = new Label();
            btnSaveRes = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            SuspendLayout();
            // 
            // cmbDoc
            // 
            cmbDoc.FormattingEnabled = true;
            cmbDoc.Location = new Point(46, 43);
            cmbDoc.Name = "cmbDoc";
            cmbDoc.Size = new Size(151, 28);
            cmbDoc.TabIndex = 0;
            // 
            // cmbPatient
            // 
            cmbPatient.FormattingEnabled = true;
            cmbPatient.Location = new Point(46, 129);
            cmbPatient.Name = "cmbPatient";
            cmbPatient.Size = new Size(151, 28);
            cmbPatient.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 20);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 2;
            label1.Text = "Docteur";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 106);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 3;
            label2.Text = "Patient";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(46, 215);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 192);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 5;
            label3.Text = "Date";
            // 
            // nudDuration
            // 
            nudDuration.Location = new Point(47, 304);
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(150, 27);
            nudDuration.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 281);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 7;
            label4.Text = "Duration";
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(420, 43);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(151, 28);
            cmbType.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(420, 20);
            label5.Name = "label5";
            label5.Size = new Size(40, 20);
            label5.TabIndex = 9;
            label5.Text = "Type";
            // 
            // txtTotalFee
            // 
            txtTotalFee.Location = new Point(420, 130);
            txtTotalFee.Name = "txtTotalFee";
            txtTotalFee.Size = new Size(125, 27);
            txtTotalFee.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(420, 106);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 11;
            label6.Text = "Total Fee";
            // 
            // btnSaveRes
            // 
            btnSaveRes.Location = new Point(580, 275);
            btnSaveRes.Name = "btnSaveRes";
            btnSaveRes.Size = new Size(160, 56);
            btnSaveRes.TabIndex = 12;
            btnSaveRes.Text = "Save";
            btnSaveRes.UseVisualStyleBackColor = true;
            btnSaveRes.Click += btnSaveRes_Click;
            // 
            // ManageConsultationsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSaveRes);
            Controls.Add(label6);
            Controls.Add(txtTotalFee);
            Controls.Add(label5);
            Controls.Add(cmbType);
            Controls.Add(label4);
            Controls.Add(nudDuration);
            Controls.Add(label3);
            Controls.Add(dtpDate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbPatient);
            Controls.Add(cmbDoc);
            Name = "ManageConsultationsForm";
            Text = "ManageConsultationsForm";
            Load += ManageConsultationsForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDoc;
        private ComboBox cmbPatient;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpDate;
        private Label label3;
        private NumericUpDown nudDuration;
        private Label label4;
        private ComboBox cmbType;
        private Label label5;
        private TextBox txtTotalFee;
        private Label label6;
        private Button btnSaveRes;
    }
}