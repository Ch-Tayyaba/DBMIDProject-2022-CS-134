using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Mid_Project
{
    public partial class ucClo : UserControl
    {
        bool check_update = false;
        string name, dateC, dateU;
        int id;
        public ucClo()
        {
            InitializeComponent();
        }
        private void SetDataGridViewProperties()
        {
            // Assuming dataGridView1 is the name of your DataGridView control
            dgvClo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClo.AllowUserToAddRows = false;
            dgvClo.AllowUserToDeleteRows = false;
            dgvClo.AllowUserToOrderColumns = true;
            dgvClo.AllowUserToResizeColumns = true;
            dgvClo.AllowUserToResizeRows = false;
            dgvClo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            view();
        }
        private void view()
        {
            
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select Name,DateCreated,DateUpdated from Clo order by Name", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvClo.DataSource = null;
            dgvClo.DataSource = dt;
            SetDataGridViewProperties();
            dgvClo.DefaultCellStyle.ForeColor = Color.Black;
            //con2.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbxName.Text = String.Empty;
        }
        private String check()
        {

            var con1 = Configuration.getInstance().getConnection();
            //con1.Open();
            SqlCommand cmd1 = new SqlCommand($" IF ( select MAX(1) FROM Clo WHERE Name = '{txtbxName.Text}') > 0 BEGIN   SELECT '1' END ELSE BEGIN   SELECT '2' END", con1);
            string X = "";
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                X = (reader.GetString(0));
            }
            reader.Close();

            cmd1.ExecuteNonQuery();
            //con1.Close();
            return X;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //int index = dgvClo.CurrentCell.ColumnIndex;
            string y = check();
            if (check_update == false && y != "1")
            {
                dateC = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                dateU = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Clo (Name, DateCreated,DateUpdated) values (@title,@dateC,@dateU)", con);
                cmd.Parameters.AddWithValue("@title", (txtbxName.Text));
                cmd.Parameters.AddWithValue("@dateC", dateC);
                cmd.Parameters.AddWithValue("@dateU", dateU);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Added  SuccessFully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbxName.Text = String.Empty;

            }
            else if (check_update == true && y != "1")
            {
                id = getCloId(name);
                dateU = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                var con6 = Configuration.getInstance().getConnection();
                //con6.Open();
                SqlCommand cmd6 = new SqlCommand("Update Clo Set Name=@title,DateUpdated=@dateU where Id=@ID", con6);
                cmd6.Parameters.AddWithValue("@title", (txtbxName.Text));
                cmd6.Parameters.AddWithValue("@dateU", dateU);
                cmd6.Parameters.AddWithValue("@ID", id);
                cmd6.ExecuteNonQuery();
                MessageBox.Show("UPDATED Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //con6.Close();


                check_update = false;
                txtbxName.Text = String.Empty;
               // MessageBox.Show("Updated date must be greater than or equal to created date");
                
            }
            else
            {
                MessageBox.Show("Enter Valid Name", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
        public static int getCloId(string n)
        {
            var con19 = Configuration.getInstance().getConnection();
            //con19.Open();
            SqlCommand cmd19 = new SqlCommand($"Select Top(1) id from Clo where  Name = '{n}'", con19);
            int count = (int)cmd19.ExecuteScalar();
            //con19.Close();
            return int.Parse(count.ToString());
        }

        private void dgvClo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            name = dgvClo.Rows[dgvClo.CurrentCell.RowIndex].Cells[2].Value.ToString();
            txtbxName.Text = name;

            int index = dgvClo.CurrentCell.ColumnIndex;
            {
                if (index == 0)
                {
                    txtbxName.Text = name;
                    check_update = true;
                }
                else if (index == 1)
                {
                    id = getCloId(name);
                    string c = checkForDel(id);
                    if(c != "1")
                    {
                        DelClo(id);
                        MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("This will also delete Rubic and Rubric Level related to it.", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DelFromRubricLevel(id);
                        DelFromRubric(id);
                        DelClo(id);
                        MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private static void DelClo(int id)
        {
            var con3 = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Delete from Clo where Id=@ID", con3);
            cmd3.Parameters.AddWithValue("@ID", id);
            cmd3.ExecuteNonQuery();
        }
        private static void DelFromRubric(int id)
        {
            var con3 = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Delete ac from AssessmentComponent as ac join Rubric as r on r.Id = ac.RubricId where r.CloId=@ID", con3);
            cmd3.Parameters.AddWithValue("@ID", id);
            cmd3.ExecuteNonQuery();

            var con4 = Configuration.getInstance().getConnection();
            SqlCommand cmd4 = new SqlCommand("Delete from Rubric where CloId=@ID", con4);
            cmd4.Parameters.AddWithValue("@ID", id);
            cmd4.ExecuteNonQuery();
        }
        private static void DelFromRubricLevel(int id)
        {;
            var con3 = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("DELETE FROM RubricLevel WHERE RubricId IN(SELECT Id FROM Rubric WHERE CloId = @ID)", con3);
            cmd3.Parameters.AddWithValue("@ID", id);
            cmd3.ExecuteNonQuery();
        }
       
        private string checkForDel(int cid)
        {
            var con14 = Configuration.getInstance().getConnection();
            //con14.Open();
            SqlCommand cmd14 = new SqlCommand($" IF(select max(1) from Rubric as r join Clo as c on c.Id = r.CloId where r.CloId ='{cid}' )>0 BEGIN SELECT '1' END ELSE BEGIN SELECT '2' END", con14);
            string z = "";
            SqlDataReader reader = cmd14.ExecuteReader();
            while (reader.Read())
            {
                z = (reader.GetString(0));
            }
            reader.Close();
            cmd14.ExecuteNonQuery();
            //con14.Close();
            return z;
        }

        private void txtbxName_TextChanged(object sender, EventArgs e)
        {
            if (check() == "1")
            {
                lblNameSignal.Text = "This Name already Exists.";
            }
            else
            {
                lblNameSignal.Text = " ";
            }
        }
       

        private void dgvClo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            name = dgvClo.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtbxName.Text = name;
        }

        private void ucClo_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn Update = new DataGridViewButtonColumn();
            Update.HeaderText = "Update";
            Update.Text = "Update";
            Update.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn Delete = new DataGridViewButtonColumn();
            Delete.HeaderText = "Delete";
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            dgvClo.Columns.Add(Update);
            dgvClo.Columns.Add(Delete);

            view();

            check_update = false;

        }
    }
}

