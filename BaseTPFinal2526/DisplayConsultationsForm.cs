using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseTPFinal2526.Repositories;
using BaseTPFinal2526.Models;
using BaseTPFinal2526.Models.Enums;

namespace BaseTPFinal2526
{
    public partial class DisplayConsultationsForm : Form
    {

        private ConsultationsRepository _consultationsRepository;
        private DoctorsRepository _doctorsRepository;
        private PatientsRepository _patientsRepository;

        public DisplayConsultationsForm()
        {
            InitializeComponent();

            _consultationsRepository = new ConsultationsRepository(Database.ConnectionString);
            _doctorsRepository = new DoctorsRepository();
            _patientsRepository = new PatientsRepository();

            LoadConsultations();
        }

        private void LoadConsultations()
        {
            var consultations = _consultationsRepository
                .GetAll(_doctorsRepository, _patientsRepository);

            dgvConsultations.DataSource = consultations;

            dgvConsultations.AutoGenerateColumns = true;
            foreach (DataGridViewRow row in dgvConsultations.Rows)
            {
                var consultation = (Consultation)row.DataBoundItem;
                if (consultation.Status == ConsultationStatus.Cancelled)
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }
            }

        }

        private void btnAddRes_Click(object sender, EventArgs e)
        {
            var form = new ManageConsultationsForm();
            form.ShowDialog();

            LoadConsultations();
        }

        private void btnEditRes_Click(object sender, EventArgs e)
        {
            if (dgvConsultations.CurrentRow == null)
            {
                MessageBox.Show("Please select a consultation first.");
                return;
            }

            var consultation = (Consultation)dgvConsultations.CurrentRow.DataBoundItem;

            if (consultation.Status == ConsultationStatus.Cancelled)
            {
                MessageBox.Show("A cancelled consultation cannot be edited.");
                return;
            }

            var manageConsultationForm = new ManageConsultationsForm(consultation);
            manageConsultationForm.ShowDialog();

            LoadConsultations();
        }

        private void btnDelRes_Click(object sender, EventArgs e)
        {
            if (dgvConsultations.CurrentRow == null)
            {
                MessageBox.Show("Please select a consultation first.");
                return;
            }

            var consultation = (Consultation)dgvConsultations.CurrentRow.DataBoundItem;

            if (consultation.Status == ConsultationStatus.Cancelled)
            {
                MessageBox.Show("This consultation is already cancelled.");
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to cancel this consultation?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.No)
                return;

            _consultationsRepository.Cancel(consultation.Id);

            LoadConsultations();
        }

       
    }
}
