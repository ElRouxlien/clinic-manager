namespace BaseTPFinal2526
{
    partial class DisplayConsultationsForm
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
            dgvConsultations = new DataGridView();
            btnAddRes = new Button();
            btnEditRes = new Button();
            btnDelRes = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvConsultations).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultations
            // 
            dgvConsultations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultations.Location = new Point(5, 7);
            dgvConsultations.Name = "dgvConsultations";
            dgvConsultations.RowHeadersWidth = 51;
            dgvConsultations.Size = new Size(623, 242);
            dgvConsultations.TabIndex = 0;
            // 
            // btnAddRes
            // 
            btnAddRes.Location = new Point(28, 277);
            btnAddRes.Name = "btnAddRes";
            btnAddRes.Size = new Size(159, 60);
            btnAddRes.TabIndex = 1;
            btnAddRes.Text = "Add";
            btnAddRes.UseVisualStyleBackColor = true;
            btnAddRes.Click += btnAddRes_Click;
            // 
            // btnEditRes
            // 
            btnEditRes.Location = new Point(256, 277);
            btnEditRes.Name = "btnEditRes";
            btnEditRes.Size = new Size(143, 60);
            btnEditRes.TabIndex = 2;
            btnEditRes.Text = "Edit";
            btnEditRes.UseVisualStyleBackColor = true;
            btnEditRes.Click += btnEditRes_Click;
            // 
            // btnDelRes
            // 
            btnDelRes.Location = new Point(474, 277);
            btnDelRes.Name = "btnDelRes";
            btnDelRes.Size = new Size(140, 60);
            btnDelRes.TabIndex = 3;
            btnDelRes.Text = "Delete";
            btnDelRes.UseVisualStyleBackColor = true;
            btnDelRes.Click += btnDelRes_Click;
            // 
            // DisplayConsultationsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(btnDelRes);
            Controls.Add(btnEditRes);
            Controls.Add(btnAddRes);
            Controls.Add(dgvConsultations);
            Margin = new Padding(2);
            Name = "DisplayConsultationsForm";
            Text = "Consultations";
            ((System.ComponentModel.ISupportInitialize)dgvConsultations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultations;
        private Button btnAddRes;
        private Button btnEditRes;
        private Button btnDelRes;
    }
}