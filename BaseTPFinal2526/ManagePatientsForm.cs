using BaseTPFinal2526.Models;
using BaseTPFinal2526.Repositories;
using BaseTPFinal2526.Validators;

namespace BaseTPFinal2526
{
    public partial class ManagePatientsForm : ManagePersonFormBase
    {
        private PatientsValidator _patientsValidator = new PatientsValidator();
        private PatientsRepository _patientsRepository = new PatientsRepository();
        private Patient _patient;
        public ManagePatientsForm(Patient patient = null)
        {
            InitializeComponent();

            _patient = patient ?? new Patient();

            FillPersonInfos(_patient);

            txtMedicalRecord.Text = _patient.MedicalRecordNumber;
            chkIsInsured.Checked = _patient.IsInsured;
        }
        public ManagePatientsForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var patient = _patient ?? new Patient();
            patient.BirthDate = dtpBirthDate.Value;
            patient.MedicalRecordNumber = txtMedicalRecord.Text;
            patient.IsInsured = chkIsInsured.Checked;
            UpdatePersonInfos(patient);

            if (_patientsValidator.IsValid(patient))
            {
                if (patient?.Id != 0 && patient?.Id != null)
                {
                    _patientsRepository.Update(patient);
                }
                else
                {
                    _patientsRepository.Add(patient);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Invalid patient informations");
            }
        }
    }
}
