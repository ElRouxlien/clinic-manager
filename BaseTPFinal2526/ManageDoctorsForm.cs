using BaseTPFinal2526.Models;
using BaseTPFinal2526.Models.Enums;
using BaseTPFinal2526.Repositories;
using BaseTPFinal2526.Validators;

namespace BaseTPFinal2526
{
    public partial class ManageDoctorsForm : ManagePersonFormBase
    {
        private readonly DoctorsRepository _doctorsRepository;
        private readonly DoctorsValidator _doctorsValidator;
        private Doctor _doctor;

        public ManageDoctorsForm(Doctor doctor = null)
        {
            InitializeComponent();

            _doctor = doctor ?? new Doctor();
            _doctorsRepository = new DoctorsRepository();
            _doctorsValidator = new DoctorsValidator(_doctorsRepository);

            FillPersonInfos(_doctor);
            
            cmbSpecialty.DataSource = Enum.GetValues(typeof(DoctorSpeciality));

            cmbSpecialty.SelectedItem = _doctor.Specialty;
            txtINAMINumber.Text = _doctor.INAMINumber;
            numConsultationFee.Value = _doctor.ConsultationFee;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var doctor = _doctor ?? new Doctor();
            doctor.Specialty = (DoctorSpeciality)cmbSpecialty.SelectedItem;
            doctor.INAMINumber = txtINAMINumber.Text;
            doctor.ConsultationFee = numConsultationFee.Value;

            UpdatePersonInfos(doctor);

            if (_doctorsValidator.IsValid(doctor))
            {
                if (_doctor?.Id != 0)
                {
                    _doctorsRepository.Update(doctor);
                }
                else
                {
                    _doctorsRepository.Add(doctor);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Invalid doctor informations");
            }
        }
    }
}
