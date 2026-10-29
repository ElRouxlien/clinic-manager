using BaseTPFinal2526.Models.Enums;
using BaseTPFinal2526.Repositories;

namespace BaseTPFinal2526
{
    public partial class MainForm : Form
    {
        private Database _db = new Database();

        public MainForm()
        {
            _db.InitializeDatabase();
            InitializeComponent();
        }

        private void btnManagePatients_Click(object sender, EventArgs e)
        {
            var managePatientsForm = new DisplayPersonsForm(ListMode.Patient);
            managePatientsForm.ShowDialog();
        }

        private void btnManageDoctors_Click(object sender, EventArgs e)
        {
            var manageDoctorsForm = new DisplayPersonsForm(ListMode.Doctor);
            manageDoctorsForm.ShowDialog();
        }

        private void btnManageConsultations_Click(object sender, EventArgs e)
        {
            var manageConsultationsForm = new DisplayConsultationsForm();
            manageConsultationsForm.ShowDialog();
        }
    }
}
