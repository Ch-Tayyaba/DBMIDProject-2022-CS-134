using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Mid_Project
{



    public partial class ucStudent : UserControl
    {
        string first, last, registeration, email, contact;
        int id, status;
        bool update = false;
        bool check_f = false, check_l = false, check_r = false, check_e = false, check_c = false;

        public ucStudent()
        {
            InitializeComponent();
        }
        public ucStudent(int id, String first, String last, String registeration, String email, string contact, int status, bool update)
        {
            InitializeComponent();
            this.id = id;
            this.first = first;
            this.last = last;
            this.registeration = registeration;
            this.email = email;
            this.contact = contact;
            this.update = update;
            this.status = status;
            if (update == true)
            {
                txtbxFirstName.Text = first;
                txtbxLastName.Text = last;
                txtbxRedNo.Text = registeration;
                txtbxEmail.Text = email;
                txtbxPhoneNo.Text = contact;
                if (status == 5)
                { cmbxStatus.Text = "Active"; }
                else if (status == 6)
                { cmbxStatus.Text = "InActive"; }
                btnCreate.Text = "Update Student";
            }
        }

        private void tlpHeading_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbxFirstName.Text = string.Empty;
            txtbxLastName.Text = string.Empty;
            txtbxRedNo.Text = string.Empty;
            txtbxEmail.Text = string.Empty;
            txtbxPhoneNo.Text = string.Empty;
            cmbxStatus.Text = string.Empty;
        }

        private String check()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand($" IF ( select MAX(1) FROM STUDENT WHERE RegistrationNumber = '{txtbxRedNo.Text}') > 0 BEGIN   SELECT '1' END ELSE BEGIN   SELECT '2' END", con);
            string X = "";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                X = (reader.GetString(0));
            }
            reader.Close();

            // X=cmd.ExecuteReader().GetString(0);
            cmd.ExecuteNonQuery();
            return X;


        }

        private void ucStudent_Load(object sender, EventArgs e)
        {

            cmbxStatus.Items.Add("Active");
            cmbxStatus.Items.Add("InActive");

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string y = check();
            if (check_c && check_e && check_f && check_l && check_r)
            {


                if (update == false && y != "1")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Student values (@FirstName,@LastName,@Contact,@Email, @RegisterationNo,@Status)", con);
                    cmd.Parameters.AddWithValue("@FirstName", (txtbxFirstName.Text));
                    cmd.Parameters.AddWithValue("@LastName", txtbxLastName.Text);
                    cmd.Parameters.AddWithValue("@RegisterationNo", txtbxRedNo.Text);
                    cmd.Parameters.AddWithValue("@Email", txtbxEmail.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtbxPhoneNo.Text);
                    int id_check = 0;
                    if (cmbxStatus.Text == "Active")
                    {
                        id_check = 5;
                    }
                    else
                    {
                        id_check = 6;
                    }

                    cmd.Parameters.AddWithValue("@Status", id_check);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Added");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update Student Set RegistrationNumber = @RegisterationNo, FirstName = @First, LastName = @Last, Contact = @Contact, Email= @Email,Status = @Status WHERE Id = @ID", con);
                    cmd.Parameters.AddWithValue("@First", (txtbxFirstName.Text));
                    cmd.Parameters.AddWithValue("@Last", txtbxLastName.Text);
                    cmd.Parameters.AddWithValue("@RegisterationNo", txtbxRedNo.Text);
                    cmd.Parameters.AddWithValue("@Email", txtbxEmail.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtbxPhoneNo.Text);

                    int id_check = 0;
                    if (cmbxStatus.Text == "Active")
                    {
                        id_check = 5;
                    }
                    else
                    {
                        id_check = 6;
                    }
                    cmd.Parameters.AddWithValue("@Status", id_check);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated");

                }
                //if (y == "1") { MessageBox.Show("Already exist"); }
            }
            else
            {
                if (y == "1") { MessageBox.Show("Already exist"); }

                MessageBox.Show("Fill the correct data first");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ucStudenList newUserControl = new ucStudenList();
            newUserControl.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(newUserControl);
            newUserControl.BringToFront();
            this.Hide();
        }

        private void txtbxRedNo_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^\d{4}-[A-Za-z]+-\d+$";

            // Check if the text matches the pattern
            if (Regex.IsMatch(txtbxRedNo.Text, pattern))
            {
                lblRegSignal.Text = "The text is valid.";
                check_r = true;

            }
            else
            {
                lblRegSignal.Text = "The text is not valid.";
                check_r = false;
            }
            if (txtbxRedNo.Text == string.Empty) { check_r = false; }

        }

        private void txtbxFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtbxFirstName.Text == string.Empty)
            {// check is empty
                lblFirstNameSignal.Text = "Enter the name";
                check_f = false;
            }
            else if (txtbxFirstName.Text.Any(ch => !char.IsLetter(ch)))
            {//check isSpecialCharactor
                lblFirstNameSignal.Text = "Allowed characters: a-z, A-Z";
                check_f = false;
            }
            else
            {//ready for storage or action
                lblFirstNameSignal.Text = " ";
                check_f = true;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // regular expression pattern for a valid phone number
            string pattern = @"^\d{11}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(phoneNumber);
        }
        private void txtbxPhoneNo_TextChanged(object sender, EventArgs e)
        {
            if (txtbxPhoneNo.Text.Length == 11 && txtbxPhoneNo.Text.All(char.IsDigit))
            {
                lblPhNoSignal.Text = "Phone number is valid.";
                check_c = true;
            }
            else if (txtbxPhoneNo.Text == string.Empty)
            {
                lblPhNoSignal.Text = "Enter the phone no.";
                check_c = false;
            }
            else
            {
                lblPhNoSignal.Text = "Allowed characters: 0-9, and length should be 11.";
                check_c = false;
            }
            
        }

        bool IsValidEmail(string eMail)
        {
            bool Result = true;

            try
            {
                Regex emailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");

                // Check if the email matches the regular expression
                Result = emailRegex.IsMatch(eMail);

            }
            catch
            {
                Result = false;
            };

            return Result;
        }
        private void txtbxEmail_TextChanged(object sender, EventArgs e)
        {
            check_e = IsValidEmail(txtbxEmail.Text);

            if (check_e == false) { lblEmailSignal.Text = "enter valid email !!!"; }
            else { lblEmailSignal.Text = ""; }
            if (txtbxEmail.Text == string.Empty) { check_e = false; }
        }

        private void txtbxLastName_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (txtbxLastName.Text == string.Empty)
            {// check is empty
                lblLastNameSignal.Text = "Enter the name";
                check_l = false;
            }
            else if (int.TryParse(txtbxLastName.Text, out i))
            {//Check isnumberic
                lblLastNameSignal.Text = "Allowed characters: a-z, A-Z";
                check_l = false;
            }
            else if (txtbxLastName.Text.Any(ch => !char.IsLetter(ch)))
            {//check isSpecialCharactor
                lblLastNameSignal.Text = "Allowed characters: a-z, A-Z";
                check_l = false;
            }
            else
            {//ready for storage or action
                lblLastNameSignal.Text = " ";
                check_l = true;
            }
        }
    }
}
