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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Mid_Project
{
    public partial class ucAssessmentComponent : UserControl
    {
        string rubricDetail;
        string cloName;
        int cloId;
        int RubericID;
        string AssessDetail;
        bool check_date = false;
        string dateC, dateU;
        bool check_M = false;
        bool check_a = false;
        bool check_update = false;
        int id, AssessId;
        string name;
        int marks;


        public ucAssessmentComponent()
        {
            InitializeComponent();
        }
        private void view()
        {
            
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($"select a.Title,ac.Name as ComponentName,c.Name as CLO,r.Details as Rubric ,ac.TotalMarks,ac.DateCreated, ac.DateUpdated from AssessmentComponent as ac JOIN Rubric as r ON r.Id = ac.RubricId join Assessment as a on a.Id = ac.AssessmentId join Clo as c on c.Id = r.CloId order by a.Title,ComponentName,CLO,Rubric ,ac.TotalMarks ", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvAssessmentComponent.DataSource = null;
            dgvAssessmentComponent.DataSource = dt;
            dgvAssessmentComponent.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            view();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMarks.Text = String.Empty;
            txtName.Text = String.Empty;
        }
        private string check_q(string x)
        {
            AssessId = ucAssessment.getAssessmentId(AssessDetail);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand($"        IF(select max(1) from AssessmentComponent where AssessmentId = {AssessId} and AssessmentComponent.Name='{x}' )>0 BEGIN SELECT '1' END ELSE BEGIN SELECT '2' END", con);
            string z = "";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                z = (reader.GetString(0));
            }
            reader.Close();

            // X=cmd.ExecuteReader().GetString(0);
            cmd.ExecuteNonQuery();
            return z;
        }
        private string check_marks(int z)
        {
            AssessId = ucAssessment.getAssessmentId(AssessDetail);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand($"\tdeclare @x as int=(select  sum(AssessmentComponent.TotalMarks) FROM Assessment join AssessmentComponent on AssessmentId=Assessment.Id where AssessmentId={AssessId})\r\n\tdeclare @y as int=(select distinct (Assessment.TotalMarks) FROM Assessment join AssessmentComponent on AssessmentId=Assessment.Id where AssessmentId={AssessId})\r\n\t   IF @x+{z}>@y   BEGIN   SELECT '1' END ELSE BEGIN   SELECT '2' END", con);
            string X = "";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                X = (reader.GetString(0));
            }
            reader.Close();
            cmd.ExecuteNonQuery();
            return X;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMarks.Text != String.Empty && txtName.Text != String.Empty)
            {
                //string y = check_marks(Convert.ToInt32(txtMarks.Text));
                string z = check_q(txtName.Text);
              
               

                    if (check_update == false && z != "1")
                    {

                        if (txtMarks.Text != String.Empty && txtName.Text != String.Empty)
                        {
                            AssessId = ucAssessment.getAssessmentId(cmbxAssessmentID.Text);
                            dateC = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            dateU = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            var con = Configuration.getInstance().getConnection();

                            AssessId = ucAssessment.getAssessmentId(cmbxAssessmentID.Text);
                            cloId = ucClo.getCloId(cbCloName.Text);
                            RubericID = ucRubric.getRubericId(rubricDetail, cloId);
                            SqlCommand cmd = new SqlCommand("Insert into AssessmentComponent values (@name,@RId,@marks,@dateC,@dateU,@AssID)", con);
                            cmd.Parameters.AddWithValue("@marks", txtMarks.Text);
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@AssID", AssessId.ToString());
                            cmd.Parameters.AddWithValue("@RId", RubericID.ToString());
                            cmd.Parameters.AddWithValue("@dateC", dateC);
                            cmd.Parameters.AddWithValue("@dateU", dateU);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show(" Added  SuccessFully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMarks.Text = String.Empty;
                            txtName.Text = String.Empty;
                        }
                        else { MessageBox.Show("Fill the data First"); }

                    }
                    else if (check_update == true )
                    {

                        AssessId = ucAssessment.getAssessmentId(cmbxAssessmentID.Text);
                        cloId = ucClo.getCloId(cbCloName.Text);
                        RubericID = ucRubric.getRubericId(cmbxRubericID.Text, cloId);

                        dateU = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        var con2 = Configuration.getInstance().getConnection();

                        SqlCommand cmd2 = new SqlCommand($"Update AssessmentComponent Set Name= @name,RubricId=@RId,TotalMarks= @marks,DateUpdated = @dateU,AssessmentId=@AssID where Id={id}", con2);
                        cmd2.Parameters.AddWithValue("@marks", txtMarks.Text);
                        cmd2.Parameters.AddWithValue("@name", txtName.Text);
                        cmd2.Parameters.AddWithValue("@AssID", AssessId);
                        cmd2.Parameters.AddWithValue("@RId", RubericID);
                        cmd2.Parameters.AddWithValue("@dateU", dateU);
                        cmd2.Parameters.AddWithValue("@ID", id);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("UPDATED Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMarks.Text = String.Empty;
                        txtName.Text = String.Empty;
                        check_update = false;

                    }
            }

           

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
       
        private void loadCloName()
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
        private void loadRubericDetail()
        {
            cmbxRubericID.Items.Clear();
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
                    cmbxRubericID.Items.Add((reader2.GetString(0)));
                }
                reader2.Close();
                cmd2.ExecuteNonQuery();
            }

        }
        private void load_combobox_rubric_data()
        {
            cmbxRubericID.Items.Clear();
            cbCloName.Items.Clear();
            loadRubericDetail();
        }
        private void loadAssessmentTitle()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select  Title FROM Assessment", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbxAssessmentID.Items.Add(reader.GetString(0));
            }
            reader.Close();
            cmd.ExecuteNonQuery();
        }
        private void load_combobox_assessment_data()
        {
            cmbxAssessmentID.Items.Clear();
            cbCloName.Items.Clear();
            loadAssessmentTitle();
        }
        private void cmbxAssessmentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssessDetail = cmbxAssessmentID.Items[cmbxAssessmentID.SelectedIndex].ToString();
        }
        private void cmbxRubericID_SelectedIndexChanged(object sender, EventArgs e)
        {
            rubricDetail = cmbxRubericID.Items[cmbxRubericID.SelectedIndex].ToString();
        }

        private void txtMarks_TextChanged(object sender, EventArgs e)
        {
            if (txtMarks.Text == string.Empty)
            {// check is empty
                lblTSignal.Text = "Enter the name";
                check_M = false;
            }
            if (txtMarks.Text.Any(ch => !char.IsDigit(ch)))
            {//check isSpecialCharactor
                lblTSignal.Text = "Allowed characters: 1-9";
                check_M = false;
            }
        }

        private void dgvAssessmentComponent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            AssessDetail = dgvAssessmentComponent.Rows[dgvAssessmentComponent.CurrentCell.RowIndex].Cells[2].Value.ToString();
            name = dgvAssessmentComponent.Rows[dgvAssessmentComponent.CurrentCell.RowIndex].Cells[3].Value.ToString();
            cloName = dgvAssessmentComponent.Rows[dgvAssessmentComponent.CurrentCell.RowIndex].Cells[4].Value.ToString();
            rubricDetail = dgvAssessmentComponent.Rows[dgvAssessmentComponent.CurrentCell.RowIndex].Cells[5].Value.ToString();
            marks = Convert.ToInt32(dgvAssessmentComponent.Rows[dgvAssessmentComponent.CurrentCell.RowIndex].Cells[6].Value.ToString());
            //a.Title,ac.Name,ac.TotalMarks,c.Name,r.Details,ac.DateCreated

            AssessId = ucAssessment.getAssessmentId(AssessDetail);
            cloId = ucClo.getCloId(cloName);
            RubericID = ucRubric.getRubericId(rubricDetail, cloId);
            id = getAssessCompId(RubericID, AssessId);

            int index = dgvAssessmentComponent.CurrentCell.ColumnIndex;
            {

                if (index == 0)
                {
                    txtName.Text = name;
                    txtMarks.Text = marks.ToString();
                     cbCloName.Text = cloName;
                    cmbxAssessmentID.Text = AssessDetail; 
                    cmbxRubericID.Text = rubricDetail;
                    check_update = true;
                }
                else if(index == 1)
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete FROM StudentResult  where AssessmentComponentId= @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    var con1 = Configuration.getInstance().getConnection();
                    SqlCommand cmd1 = new SqlCommand("Delete FROM AssessmentComponent  where Id= @id", con1);
                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }


        private void dgvAssessmentComponent_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AssessDetail = dgvAssessmentComponent.Rows[e.RowIndex].Cells[2].Value.ToString();
            name = dgvAssessmentComponent.Rows[e.RowIndex].Cells[3].Value.ToString();
            cloName = dgvAssessmentComponent.Rows[e.RowIndex].Cells[4].Value.ToString();
            rubricDetail = dgvAssessmentComponent.Rows[e.RowIndex].Cells[5].Value.ToString();
            marks = Convert.ToInt32(dgvAssessmentComponent.Rows[e.RowIndex].Cells[6].Value.ToString());
            //a.Title,ac.Name,ac.TotalMarks,c.Name,r.Details,ac.DateCreated

            AssessId = ucAssessment.getAssessmentId(AssessDetail);
            cloId = ucClo.getCloId(cloName);
            RubericID = ucRubric.getRubericId(rubricDetail, cloId);
            id = getAssessCompId(RubericID,AssessId);

        }
        private static int getAssessCompId(int rid, int assid)
        {
            var con19 = Configuration.getInstance().getConnection();
            SqlCommand cmd19 = new SqlCommand($"Select Top(1) id from AssessmentComponent where  RubricId  = '{rid}' and AssessmentId  = '{assid}'", con19);
            int count = (int)cmd19.ExecuteScalar();
            return int.Parse(count.ToString());
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {// check is empty
                lblNameSingal.Text = "Enter the name";
                check_a = false;
            }
            if (txtName.Text.Any(ch => !char.IsLetter(ch)))
            {//check isSpecialCharactor
                //lblNameSingal.Text = "Allowed characters: a-Z";
                check_a = true;
            }
            else { check_M = true; }
        }

        private void cbCloName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRubericDetail();
        }

        private void ucAssessmentComponent_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn Update = new DataGridViewButtonColumn();
            Update.HeaderText = "Update";
            Update.Text = "Update";
            Update.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn Delete = new DataGridViewButtonColumn();
            Delete.HeaderText = "Delete";
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            dgvAssessmentComponent.Columns.Add(Update);
            dgvAssessmentComponent.Columns.Add(Delete);

            view();
            loadCloName();
            loadAssessmentTitle();
            cbCloName.Show();

        }


    }
}
