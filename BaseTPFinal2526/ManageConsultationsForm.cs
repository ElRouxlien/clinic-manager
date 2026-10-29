using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseTPFinal2526.Models;
using BaseTPFinal2526.Models.Enums;
using BaseTPFinal2526.Repositories;

namespace BaseTPFinal2526
{
    public partial class ManageConsultationsForm : Form
    {

        private Consultation _consultation;
        private readonly ConsultationsRepository _consultationsRepository;
        private readonly DoctorsRepository _doctorsRepository;
        private readonly PatientsRepository _patientsRepository;
        public ManageConsultationsForm()
        {
            InitializeComponent();

            _doctorsRepository = new DoctorsRepository();
            _patientsRepository = new PatientsRepository();
            _consultationsRepository = new ConsultationsRepository(Database.ConnectionString);

            _consultation = new Consultation
            {
                Status = ConsultationStatus.Scheduled
            };

            LoadDoctors();
            LoadPatients();
            LoadTypes();
        }

        public ManageConsultationsForm(Consultation consultation)
            : this()
        {
            _consultation = consultation;
            FillForm();
        }

        private void LoadDoctors()
        {
            var doctors = _doctorsRepository.GetAll();
            cmbDoc.DataSource = doctors;
            cmbDoc.DisplayMember = "LastName";
        }

        private void LoadPatients()
        {
            var patients = _patientsRepository.GetAll();
            cmbPatient.DataSource = patients;
            cmbPatient.DisplayMember = "LastName";
        }

        private void LoadTypes()
        {
            cmbType.DataSource = Enum.GetValues(typeof(ConsultationType));

        }

        private void nudDuration_ValueChanged(object sender, EventArgs e)
        {
            if (cmbDoc.SelectedItem is Doctor doctor)
            {
                txtTotalFee.Text = (nudDuration.Value * doctor.ConsultationFee).ToString("0.00");
            }
        }

        private void RecalculateTotalFee(object sender, EventArgs e)
        {
            if (cmbDoc.SelectedItem is Doctor doctor)
            {
                var total = nudDuration.Value * doctor.ConsultationFee;
                txtTotalFee.Text = total.ToString("0.00");
            }
            else
            {
                txtTotalFee.Text = "0.00";
            }
        }

        private void FillForm()
        {
            cmbDoc.SelectedItem = _consultation.Doctor;
            cmbPatient.SelectedItem = _consultation.Patient;
            dtpDate.Value = _consultation.Date;
            nudDuration.Value = _consultation.Duration;
            cmbType.SelectedItem = _consultation.Type;
            txtTotalFee.Text = _consultation.TotalFee.ToString("0.00");
        }




        private void ManageConsultationsForm_Load(object sender, EventArgs e)
        {
            LoadDoctors();
            LoadPatients();
            LoadTypes();

            cmbDoc.SelectedIndexChanged += RecalculateTotalFee;
            nudDuration.ValueChanged += RecalculateTotalFee;

            RecalculateTotalFee(this, EventArgs.Empty);
        }

        private void btnSaveRes_Click(object sender, EventArgs e)
        {
            try
            {
                _consultation.Doctor = (Doctor)cmbDoc.SelectedItem;
                _consultation.Patient = (Patient)cmbPatient.SelectedItem;
                _consultation.Date = dtpDate.Value;
                _consultation.Duration = (int)nudDuration.Value;
                _consultation.Type = (ConsultationType)cmbType.SelectedItem;

                if (_consultation.Id == 0)
                    _consultationsRepository.Add(_consultation);
                else
                    _consultationsRepository.Update(_consultation);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
