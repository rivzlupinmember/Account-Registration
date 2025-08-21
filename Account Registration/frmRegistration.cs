using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Account_Registration
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
            // Assign delegates to methods
            StudentInfoClass.DelStudNo = new DelegateNumber(SetStudentNo);
            StudentInfoClass.DelNumAge = new DelegateNumber(SetAge);
            StudentInfoClass.DelNumContactNo = new DelegateNumber(SetContactNo);

            StudentInfoClass.DelFirstName = new DelegateText(SetFirstName);
            StudentInfoClass.DelLastName = new DelegateText(SetLastName);
            StudentInfoClass.DelMiddleName = new DelegateText(SetMiddleName);
            StudentInfoClass.DelProgram = new DelegateText(SetProgram);
            StudentInfoClass.DelAddress = new DelegateText(SetAddress);

            cbProgram.Items.Add("Programs:");
            cbProgram.Items.Add("Bachelor of Science in Computer Science");
            cbProgram.Items.Add("Bachelor of Science in Information Technology");
            cbProgram.Items.Add("Bachelor of Science in Information Systems");
            cbProgram.Items.Add("Bachelor of Science in Computer Engineering");
            cbProgram.SelectedIndex = 0; // Set default selection
        }
        private long SetStudentNo(long studNo)
        {
            return StudentInfoClass.StudentNo = studNo;
        }
        private long SetAge(long age)
        {
            return StudentInfoClass.Age = age;
        }
        private long SetContactNo(long contact)
        {
            return StudentInfoClass.ContactNo = contact;
        }
        private string SetFirstName(string fname)
        {
            return StudentInfoClass.FirstName = fname;
        }
        private string SetLastName(string lname)
        {
            return StudentInfoClass.LastName = lname;
        }
        private string SetMiddleName(string mname)
        {
            return StudentInfoClass.MiddleName = mname;
        }
        private string SetProgram(string program)
        {
            return StudentInfoClass.Program = program;
        }
        private string SetAddress(string address)
        {
            return StudentInfoClass.Address = address;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Parse and store using delegates
            StudentInfoClass.DelStudNo(long.Parse(txtStudentNo.Text));
            StudentInfoClass.DelFirstName(txtFirstName.Text);
            StudentInfoClass.DelLastName(txtLastName.Text);
            StudentInfoClass.DelMiddleName(txtMiddleName.Text);
            StudentInfoClass.DelProgram(cbProgram.Text);
            StudentInfoClass.DelAddress(txtAddress.Text);
            StudentInfoClass.DelNumAge(long.Parse(txtAge.Text));
            StudentInfoClass.DelNumContactNo(long.Parse(txtContactNo.Text));

            // Show confirmation form
            frmConfirm confirmForm = new frmConfirm();
            confirmForm.ShowDialog();
        }

        private void cbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ArrayList program = new ArrayList
                {
                  "Bachelor of Science in Computer Science",
                  "Bachelor of Science in Information Technology",
                  "Bachelor of Science in Information Systems",
                  "Bachelor of Science in Computer Engineering"
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
