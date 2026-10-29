using BaseTPFinal2526.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseTPFinal2526
{
    public partial class ManagePersonFormBase : Form
    {
        public ManagePersonFormBase()
        {
            InitializeComponent();
        }

        protected virtual void FillPersonInfos(Person person)
        {
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtEmail.Text = person.Email;
            mskPhone.Text = person.PhoneNumber;
            txtAddress.Text = person.Address;
        }

        protected virtual void UpdatePersonInfos(Person person)
        {
            person.FirstName = txtFirstName.Text;
            person.LastName = txtLastName.Text;
            person.Email = txtEmail.Text;
            person.PhoneNumber = mskPhone.MaskCompleted ? mskPhone.Text : "";
            person.Address = txtAddress.Text;
        }
    }
}
