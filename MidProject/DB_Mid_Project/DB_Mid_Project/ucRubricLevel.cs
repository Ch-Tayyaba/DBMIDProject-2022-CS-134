using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DB_Mid_Project
{
    public partial class ucRubricLevel : UserControl
    {
        int cloId;
        string cloName;
        bool check_update = false;
        string detail;
        int id, rubericID, Measurment;
        string RubericDetail;
        bool check_c = false;
        bool check_d = false;
        public ucRubricLevel()
        {
            InitializeComponent();
            view();
        }

        private void view()
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select c.Name as CloName, r.Details as RubericDetail, rl.Details, rl.MeasurementLevel from RubricLevel as rl join Rubric as r on rl.RubricId = r.Id join Clo as c on c.Id = r.CloId order by  CloName, RubericDetail, rl.Details, rl.MeasurementLevel", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvRubericLevel.DataSource = null;
            dgvRubericLevel.DataSource = dt;
            dgvRubericLevel.DefaultCellStyle.ForeColor = Color.Black;
           // con2.Close();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            view();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbxMeasurmentlevel.Text = String.Empty;
            txtbxdetail.Text = String.Empty;
            cbRubericDetail.Text = String.Empty;
            cbCloName.Text = String.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            detail = txtbxdetail.Text;
            cloName = cbCloName.Text;
            cloId = ucClo.getCloId(cloName);
            RubericDetail = cbRubericDetail.Text;
            rubericID = ucRubric.getRubericId(RubericDetail, cloId);
            string y = check_q(detail,RubericDetail ,rubericID,cloId);

            if (check_update == false && y != "1")
            {
                if (check_d && check_c && txtbxdetail.Text != String.Empty && txtbxMeasurmentlevel.Text != String.Empty)
                {

                    var con = Configuration.getInstance().getConnection();
                   // con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into RubricLevel values (@Id,@Detail,@measure)", con);
                    cmd.Parameters.AddWithValue("@Detail", txtbxdetail.Text);
                    cmd.Parameters.AddWithValue("@measure", txtbxMeasurmentlevel.Text);
                    cmd.Parameters.AddWithValue("@Id", rubericID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Added  SuccessFully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      

                }
                else { MessageBox.Show("Fill the data First"); }
            }
            else if (check_update == true && check_c)
            {

                //rubericID = ucRubric.getRubericId(RubericDetail, cloId);

                

                var con2 = Configuration.getInstance().getConnection();
               // con2.Open();
                SqlCommand cmd2 = new SqlCommand("Update RubricLevel Set Details=@Detail, MeasurementLevel=@measure where Id=@ID and RubricId = @RubricID", con2);
                cmd2.Parameters.AddWithValue("@Detail", txtbxdetail.Text);
                cmd2.Parameters.AddWithValue("@RubricID", rubericID);
                cmd2.Parameters.AddWithValue("@ID", id);
                cmd2.Parameters.AddWithValue("@measure", txtbxMeasurmentlevel.Text);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("UPDATED Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //con2.Close();
                check_update = false;
                txtbxdetail.Text = String.Empty;
                txtbxMeasurmentlevel.Text = String.Empty;
                MessageBox.Show("Updated Successfully");
            }
            else
            {
                MessageBox.Show("Enter Valid input");
            }
            view();
        }
        private string check_q(string d,string rd, int Rid, int cid)
        {
            var con14 = Configuration.getInstance().getConnection();
            //con14.Open();
            SqlCommand cmd14 = new SqlCommand($" IF(select max(1) from RubricLevel as rl join Rubric as r on rl.RubricId = r.Id  where rl.Details='{d}' and rl.RubricId ='{Rid}' and r.Details ='{rd}' and r.CloId ='{cid}' )>0 BEGIN SELECT '1' END ELSE BEGIN SELECT '2' END", con14);
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
        public static int getRubricLevelId(string x, int i, int m)
        {
            var con19 = Configuration.getInstance().getConnection();
            //con19.Open();
            SqlCommand cmd19 = new SqlCommand($"Select Top(1) id from RubricLevel where  Details = '{x}' and RubricId = '{i}' and MeasurementLevel = '{m}'", con19);
            int count = (int)cmd19.ExecuteScalar();
            //con19.Close();
            return int.Parse(count.ToString());
        }
        private void cbRubericId_SelectedIndexChanged(object sender, EventArgs e)
        {
            RubericDetail = cbRubericDetail.Items[cbRubericDetail.SelectedIndex].ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void txtbxMeasurmentlevel_TextChanged(object sender, EventArgs e)
        {
            if (txtbxMeasurmentlevel.Text == string.Empty)
            {// check is empty
                label3.Text = "Enter the name";
                check_c = false;
            }
            if (txtbxMeasurmentlevel.Text.Any(ch => !char.IsDigit(ch)))
            {//check isSpecialCharactor
                label3.Text = "Allowed characters: 1-9";
                check_c = false;
            }
            else
            {//ready for storage or action
                label3.Text = " ";
                check_c = true;
            }
        }

        private void load_combobox_assessment_data()
        {

            cbRubericDetail.Items.Clear();
            cbCloName.Items.Clear();
            loadCloNames();

        }

        private void loadRubericDetail()
        {
            cbRubericDetail.Items.Clear();
            if (cbCloName.Text == null)
            {
                MessageBox.Show("First Select CloName!!!");
            }
            else
            {
                cloName = cbCloName.Text;
                cloId = ucClo.getCloId(cloName);


                var con2 = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand($"Select Details FROM Rubric where cloId = '{cloId}'", con2);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    cbRubericDetail.Items.Add((reader2.GetString(0)));
                }
                reader2.Close();
                cmd2.ExecuteNonQuery();
            }

        }
        private void loadCloNames()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name FROM Clo", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbCloName.Items.Add(reader.GetString(0));
            }
            reader.Close();
            cmd.ExecuteNonQuery();
        }

        private void dgvRubericLevel_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cloName = (dgvRubericLevel.Rows[e.RowIndex].Cells[0].Value.ToString());
            RubericDetail = (dgvRubericLevel.Rows[e.RowIndex].Cells[1].Value.ToString());
            Measurment = Convert.ToInt16(dgvRubericLevel.Rows[e.RowIndex].Cells[3].Value.ToString());
            detail = dgvRubericLevel.Rows[e.RowIndex].Cells[2].Value.ToString();

            

            //cloId = ucClo.getCloId(cloName);
            //rubericID = ucRubric.getRubericId(RubericDetail,cloId);
            //id = getRubricLevelId(detail ,rubericID,Measurment);

            
            //cbCloName.Text = cloName;
            //cbRubericDetail.Text = RubericDetail;
        }

        private void cbCloName_TextUpdate(object sender, EventArgs e)
        {
            loadRubericDetail();
        }

        private void dgvRubericLevel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cloName = (dgvRubericLevel.Rows[dgvRubericLevel.CurrentCell.RowIndex].Cells[2].Value.ToString());
            RubericDetail = (dgvRubericLevel.Rows[dgvRubericLevel.CurrentCell.RowIndex].Cells[3].Value.ToString());
            Measurment = Convert.ToInt16(dgvRubericLevel.Rows[dgvRubericLevel.CurrentCell.RowIndex].Cells[5].Value.ToString());
            detail = dgvRubericLevel.Rows[dgvRubericLevel.CurrentCell.RowIndex].Cells[4].Value.ToString();



            cloId = ucClo.getCloId(cloName);
            rubericID = ucRubric.getRubericId(RubericDetail, cloId);
            id = getRubricLevelId(detail, rubericID, Measurment);


            cbCloName.Text = cloName;
            cbRubericDetail.Text = RubericDetail;
            int index = dgvRubericLevel.CurrentCell.ColumnIndex;
            {
                if (index == 0)
                {
                    txtbxdetail.Text = detail;
                    txtbxMeasurmentlevel.Text = Measurment.ToString();
                    check_update = true;
                }
                if (index == 1)
                {
                    cloName = cbCloName.Text;
                    cloId = ucClo.getCloId(cloName);
                    rubericID = ucRubric.getRubericId(RubericDetail, cloId);
                    id = getRubricLevelId(detail, rubericID, Measurment);

                    string c = checkForDel();

                    if (c != "1")
                    {
                        delRubricLevel();
                        MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("This will also delete Student Result", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        delStudentResult();
                        delRubricLevel();
                        MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }
        private void delRubricLevel()
        {
            var con19 = Configuration.getInstance().getConnection();
            SqlCommand cmd19 = new SqlCommand("Delete from RubricLevel where Id=@ID", con19);
            cmd19.Parameters.AddWithValue("@ID", id);
            cmd19.ExecuteNonQuery();
        }
        private string checkForDel()
        {
            var con14 = Configuration.getInstance().getConnection();
            SqlCommand cmd14 = new SqlCommand($" IF(select max(1) from RubricLevel as rl join StudentResult as sr on rl.Id = sr.RubricMeasurementId where rl.Id ='{id}' )>0 BEGIN SELECT '1' END ELSE BEGIN SELECT '2' END", con14);
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
        private void delStudentResult()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete FROM StudentResult  where RubricMeasurementId= @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private void txtbxdetail_TextChanged(object sender, EventArgs e)
        {
            detail = txtbxdetail.Text;
            cloName = cbCloName.Text;
            cloId = ucClo.getCloId(cloName);
            RubericDetail = cbRubericDetail.Text;
            if (cbRubericDetail.Text != null && cbCloName.Text != null)
            { rubericID = ucRubric.getRubericId(RubericDetail, cloId); }
            string y = check_q(detail, RubericDetail, rubericID, cloId);
            if(y == "1")
            {
                check_d = false;
                lblDetailSignal.Text = "This Detail has already been used.";
            }
            else
            {
                check_d = true;
                lblDetailSignal.Text = "";
            }
        }

        private void cbCloName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cloName = cbCloName.Items[cbCloName.SelectedIndex].ToString();
            loadRubericDetail();
        }

       
        private void ucRubricLevel_Load(object sender, EventArgs e)
        {
            load_combobox_assessment_data();
            DataGridViewButtonColumn Update = new DataGridViewButtonColumn();
            Update.HeaderText = "Update";
            Update.Text = "Update";
            Update.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn Delete = new DataGridViewButtonColumn();
            Delete.HeaderText = "Delete";
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            dgvRubericLevel.Columns.Add(Update);
            dgvRubericLevel.Columns.Add(Delete);
        }

    }
}
