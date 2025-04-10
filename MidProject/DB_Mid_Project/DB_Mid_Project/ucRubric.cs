using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;


namespace DB_Mid_Project
{

    public partial class ucRubric : UserControl
    {
        int uniqueKey;
        bool check_update = false;
        int id;
        string detail;
        int CloID;

        string cloName;
        public ucRubric()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void SetDataGridViewProperties()
        {
            // Assuming dataGridView1 is the name of your DataGridView control
            dgvRubric.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRubric.AllowUserToAddRows = false;
            dgvRubric.AllowUserToDeleteRows = false;
            dgvRubric.AllowUserToOrderColumns = true;
            dgvRubric.AllowUserToResizeColumns = true;
            dgvRubric.AllowUserToResizeRows = false;
            dgvRubric.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }
        private void view()
        {
            SetDataGridViewProperties();
            var con11 = Configuration.getInstance().getConnection();
            //con11.Open();
            SqlCommand cmd11 = new SqlCommand("Select c.name, r.Details from Rubric as r join Clo as c on r.cloId = c.Id order by c.name, r.Details ", con11);
            SqlDataAdapter da = new SqlDataAdapter(cmd11);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvRubric.DataSource = null;
            dgvRubric.DataSource = dt;
            dgvRubric.DefaultCellStyle.ForeColor = Color.Black;
            //con11.Close();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            view();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbxDetails.Text = String.Empty;
            cbCloName.Text = String.Empty;
        }

        //private void getCloId()
        //{
        //    var con17 = Configuration.getInstance().getConnection();
        //    //con4.Open();
        //    SqlCommand cmd17 = new SqlCommand($"Select Top(1) id from Clo where  Name = '{cloName}'", con17);
        //    int count = (int)cmd17.ExecuteScalar();
        //    //con4.Close();
        //    CloID = int.Parse(count.ToString());
        //}
        public static int getRubericId(string rd, int i)
        {
            var con18 = Configuration.getInstance().getConnection();
            //con4.Open();
            // Rubric as r join clo as c on r.cloId = c.Id where Details='{x}' and c.Id ='{CloID}'
            SqlCommand cmd18 = new SqlCommand($"Select Top(1) Id from Rubric  where  Details = '{rd}' and CloId ='{i}'", con18);
            int count = (int)cmd18.ExecuteScalar();
            //con4.Close();
            return int.Parse(count.ToString());
        }
        private int totalCountOfRubric()
        {
            var con19 = Configuration.getInstance().getConnection();
            
            SqlCommand cmd19 = new SqlCommand("Select count(Id) from Rubric", con19);
            int count = (int)cmd19.ExecuteScalar();
            
            return int.Parse(count.ToString());
        }
        public static int GenerateUniqueKey(int currentKey)
        {
            return ++currentKey;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string z = check_q(txtbxDetails.Text);
            


            if (check_update == false && z != "1")
            {
                if (txtbxDetails.Text != String.Empty)
                {
                    cloName = cbCloName.Text;
                    CloID = ucClo.getCloId(cloName);
                    uniqueKey = GenerateUniqueKey(totalCountOfRubric());


                    var con = Configuration.getInstance().getConnection();
                   // con12.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Rubric values  (@id, @Details, @CloId)", con);
                    cmd.Parameters.AddWithValue("@Details", txtbxDetails.Text);
                    cmd.Parameters.AddWithValue("@CloId", CloID);
                    cmd.Parameters.AddWithValue("@id", uniqueKey);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Added  SuccessFully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbxDetails.Text = String.Empty;
                }
                else { MessageBox.Show("Fill the data First"); }


            }
            else
            if (check_update == true)
            {
                

                var con13 = Configuration.getInstance().getConnection();
               // con13.Open();
                SqlCommand cmd13 = new SqlCommand("Update Rubric Set Details=@Detail where Id=@ID and CloId = @CloId" , con13);
                cmd13.Parameters.AddWithValue("@Detail", txtbxDetails.Text);
                cmd13.Parameters.AddWithValue("@CloID", CloID);
                cmd13.Parameters.AddWithValue("@ID", id);
                cmd13.ExecuteNonQuery();
                MessageBox.Show("UPDATED Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //con13.Close();
                check_update = false;
                txtbxDetails.Text = String.Empty;

            }
            else if (z == "1") { MessageBox.Show("Already Exist"); }

        }
        private string check_q(string x)
        {
            cloName = cbCloName.Text;
            CloID = ucClo.getCloId(cloName);
            var con14 = Configuration.getInstance().getConnection();
            //con14.Open();
            SqlCommand cmd14 = new SqlCommand($" IF(select max(1) from Rubric as r join clo as c on r.cloId = c.Id where Details='{x}' and c.Id ='{CloID}' )>0 BEGIN SELECT '1' END ELSE BEGIN SELECT '2' END", con14);
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
        private void blnAddLevel_Click(object sender, EventArgs e)
        {
            ucRubricLevel newUserControl = new ucRubricLevel();
            newUserControl.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(newUserControl);
            newUserControl.BringToFront();
            this.Hide();
        }
        private void load_combobox_assessment_data()
        {
            cbCloName.Items.Clear();
            cbCloName.Items.Clear();
            loadName();
        }
        //private void loadID()
        //{
        //    var con15 = Configuration.getInstance().getConnection();
        //    //con15.Open();
        //    SqlCommand cmd15 = new SqlCommand("Select  id FROM Clo", con15);
        //    SqlDataReader reader2 = cmd15.ExecuteReader();
        //    while (reader2.Read())
        //    {
        //        comboBox2.Items.Add(Convert.ToInt16(reader2.GetInt32(0)));
        //    }
        //    reader2.Close();

        //    cmd15.ExecuteNonQuery();
        //    //con15.Close();

        //}
        private void loadName()
        {
            var con16 = Configuration.getInstance().getConnection();

            SqlCommand cmd16 = new SqlCommand("Select Name FROM Clo", con16);
            //con16.Open();
            SqlDataReader reader = cmd16.ExecuteReader();
            while (reader.Read())
            {
                cbCloName.Items.Add(reader.GetString(0));
            }
            reader.Close();

            cmd16.ExecuteNonQuery();
            //con16.Close();
        }

        private void ucRubric_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn Update = new DataGridViewButtonColumn();
            Update.HeaderText = "Update";
            Update.Text = "Update";
            Update.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn Delete = new DataGridViewButtonColumn();
            Delete.HeaderText = "Delete";
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            dgvRubric.Columns.Add(Update);
            dgvRubric.Columns.Add(Delete);
            
            view();
            check_update = false;
            load_combobox_assessment_data();
        }

        private void dgvRubric_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cloName = dgvRubric.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail = dgvRubric.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbxDetails.Text = detail;
            cbCloName.Text = cloName;

            //cloName = cbCloName.Text;
            CloID = ucClo.getCloId(cloName);
            id = getRubericId(txtbxDetails.Text, CloID);
        }

        private void cbCloId_SelectedIndexChanged(object sender, EventArgs e)
        {
            cloName = cbCloName.Items[cbCloName.SelectedIndex].ToString();
        }

        private void dgvRubric_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cloName = dgvRubric.Rows[dgvRubric.CurrentCell.RowIndex].Cells[2].Value.ToString();
            detail = dgvRubric.Rows[dgvRubric.CurrentCell.RowIndex].Cells[3].Value.ToString();
            txtbxDetails.Text = detail;
            cbCloName.Text = cloName;

            CloID = ucClo.getCloId(cloName);
            id = getRubericId(txtbxDetails.Text, CloID);

            int index = dgvRubric.CurrentCell.ColumnIndex;
            {
                if (index == 0)
                {
                    txtbxDetails.Text = detail;
                    cbCloName.Text = cloName;
                    check_update = true;
                }
                else if (index == 1)
                {
                    cloName = cbCloName.Text;
                    CloID = ucClo.getCloId(cloName);
                    id = getRubericId(detail, CloID);

                    string c = checkForDel(id);

                    if (c != "1")
                    {
                        delAssessmentComponent();
                        DelRubric(id);
                        MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("This will also delete Rubric Levels", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        delStudentResult();
                        delAssessmentComponent();
                        DelRubricWithRubricLevel(id);
                        DelRubric(id);
                        MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    // also delete ruberic level
                }

            }
        }
        private string checkForDel(int rid)
        {
            var con14 = Configuration.getInstance().getConnection();
            SqlCommand cmd14 = new SqlCommand($" IF(select max(1) from Rubric as r join RubricLevel as rl on r.Id = rl.RubricId where rl.RubricId ='{rid}' )>0 BEGIN SELECT '1' END ELSE BEGIN SELECT '2' END", con14);
            string z = "";
            SqlDataReader reader = cmd14.ExecuteReader();
            while (reader.Read())
            {
                z = (reader.GetString(0));
            }
            reader.Close();
            cmd14.ExecuteNonQuery();
            return z;
        }
        public static void DelRubricWithRubricLevel(int id)
        {
            var con19 = Configuration.getInstance().getConnection();
            SqlCommand cmd19 = new SqlCommand("Delete from RubricLevel where RubricId=@ID", con19);
            cmd19.Parameters.AddWithValue("@ID", id);
            cmd19.ExecuteNonQuery();
        }
        private static void DelRubric(int id)
        {
            var con19 = Configuration.getInstance().getConnection();
            SqlCommand cmd19 = new SqlCommand("Delete from Rubric where Id=@ID", con19);
            cmd19.Parameters.AddWithValue("@ID", id);
            cmd19.ExecuteNonQuery();
        }
        private void delAssessmentComponent()
        {
            var con19 = Configuration.getInstance().getConnection();
            SqlCommand cmd19 = new SqlCommand("Delete from AssessmentComponent where RubricId=@ID", con19);
            cmd19.Parameters.AddWithValue("@ID", id);
            cmd19.ExecuteNonQuery();
        }
        private void delStudentResult()
        {
            var con19 = Configuration.getInstance().getConnection();
            SqlCommand cmd19 = new SqlCommand("Delete sr from StudentResult as sr join RubricLevel as rl on sr.RubricMeasurementId = rl.Id join rubric as r on r.Id = rl.RubricId  where r.Id= @ID", con19);
            cmd19.Parameters.AddWithValue("@ID", id);
            cmd19.ExecuteNonQuery();
        }
    }
}
