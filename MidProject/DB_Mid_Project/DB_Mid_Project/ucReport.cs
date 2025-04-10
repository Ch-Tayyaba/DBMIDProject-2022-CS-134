using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.pdf.draw;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace DB_Mid_Project
{
    public partial class ucReport : UserControl
    {
        string name;
        string line;
        public ucReport()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void load1()
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($"select c.Name as CLO,s.RegistrationNumber,s.FirstName,s.LastName, a.Title as Assessment, a.TotalMarks,a.TotalWeightage,\r\nac.Name as AsssessmentComp,ac.TotalMarks ,((rl.MeasurementLevel * ac.TotalMarks) / MAXLevel.MaximumLevel) as FinalObtainedMarks\r\nfrom Clo as c join Rubric as r on c.Id = r.CloId join RubricLevel as rl on r.Id = rl.RubricId \r\njoin StudentResult as sr on sr.RubricMeasurementId = rl.Id join Student as s on s.Id = sr.StudentId join AssessmentComponent as ac on ac.Id = sr.AssessmentComponentId \r\njoin Assessment as a on a.Id = ac.AssessmentId JOIN (SELECT MAX(MeasurementLevel) AS MaximumLevel FROM RubricLevel) AS MAXLevel ON 1=1  order by c.Name", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvReport.DataSource = null;
            dgvReport.DataSource = dt;
            dgvReport.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void load2()
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($"select  s.RegistrationNumber,s.FirstName,s.LastName,r.Details as Rubric, rl.Details as RubricLevel, rl.MeasurementLevel,a.Title as Assessment, \r\nac.Name as AssessmentComp, ac.TotalMarks,((rl.MeasurementLevel * ac.TotalMarks) / MAXLevel.MaximumLevel) as ObtainedMarks from Rubric as r join RubricLevel as rl on r.Id = rl.RubricId join StudentResult as sr on sr.RubricMeasurementId = rl.Id \r\njoin Student as s on s.Id = sr.StudentId join AssessmentComponent ac on ac.Id = sr.AssessmentComponentId join Assessment AS A ON A.Id = AC.AssessmentId \r\nJOIN (SELECT MAX(MeasurementLevel) AS MaximumLevel FROM RubricLevel) AS MAXLevel ON 1=1 order by r.Details", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvReport.DataSource = null;
            dgvReport.DataSource = dt;
            dgvReport.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void load3()
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($"select s.RegistrationNumber,s.FirstName,s.LastName, a.Title as Assessment, a.TotalMarks as AssessmentTotalMarks,a.TotalWeightage as AssessmentTotalWeightage,\r\nac.Name as AsssessmentComp,ac.TotalMarks as CompTotalMarks ,((rl.MeasurementLevel * ac.TotalMarks) / MAXLevel.MaximumLevel) as ComponentObtainedMarks\r\n, SUM(((rl.MeasurementLevel * ac.TotalMarks) / MAXLevel.MaximumLevel)) OVER (PARTITION BY s.Id, a.Id) AS AssessmentObtainedMarks from Assessment as a \r\njoin AssessmentComponent as ac on a.Id = ac.AssessmentId join StudentResult as sr on sr.AssessmentComponentId = ac.Id join Student as s on s.Id = sr.StudentId \r\njoin RubricLevel as rl on rl.Id = sr.RubricMeasurementId JOIN (SELECT MAX(MeasurementLevel) AS MaximumLevel FROM RubricLevel) AS MAXLevel ON 1=1 order by a.Title", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvReport.DataSource = null;
            dgvReport.DataSource = dt;
            dgvReport.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void load4()
        {
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand($"SELECT  MONTH(ca.AttendanceDate) AS Month, YEAR(ca.AttendanceDate) AS Year,COUNT(DISTINCT CASE WHEN sa.AttendanceStatus = 1 THEN s.Id END) AS PresentStudents, COUNT(DISTINCT CASE WHEN sa.AttendanceStatus = 2 THEN s.Id END) AS AbsentStudents, COUNT(DISTINCT CASE WHEN sa.AttendanceStatus = 3 THEN s.Id END) AS OnLeaveStudents, COUNT(DISTINCT CASE WHEN sa.AttendanceStatus = 4 THEN s.Id END) AS LateStudents, COUNT(DISTINCT s.Id) AS Totalstudents\r\nFROM Student AS s JOIN StudentAttendance AS sa ON sa.StudentId = s.Id JOIN  ClassAttendance AS ca ON ca.Id = sa.AttendanceId GROUP BY MONTH(ca.AttendanceDate), YEAR(ca.AttendanceDate) ORDER BY Year, Month", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvReport.DataSource = null;
            dgvReport.DataSource = dt;
            dgvReport.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void ExportToPDF(DataGridView dgv, string name, string l)
        {
            try
            {
                Document document = new Document(PageSize.A4, 20, 20, 20, 20);
                PdfWriter.GetInstance(document, new FileStream(name + ".pdf", FileMode.Create));
                document.Open();
                iTextSharp.text.Font headingFont = FontFactory.GetFont("Times New Roman", 18, iTextSharp.text.Font.BOLD);
                Paragraph heading = new Paragraph(name, headingFont);
                heading.Alignment = Element.ALIGN_CENTER;
                heading.SpacingBefore = 10f;
                heading.SpacingAfter = 10f;

                document.Add(heading);

                LineSeparator line = new LineSeparator();
                document.Add(line);


                iTextSharp.text.Font courseFont = FontFactory.GetFont("Times New Roman", 12);
                Paragraph course = new Paragraph(l, courseFont);

                course.Alignment = Element.ALIGN_CENTER;
                course.IndentationLeft = 55f;
                course.SpacingAfter = 20f;
                document.Add(course);

                LineSeparator line2 = new LineSeparator();
                document.Add(line2);



                PdfPTable table = new PdfPTable(dgv.Columns.Count);
                table.WidthPercentage = 100;
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    table.AddCell(cell);
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index == dgvReport.Rows.Count)
                    {
                        continue;

                    }
                    else
                    {
                        try
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value.ToString()));
                                table.AddCell(pdfCell);
                            }
                        }
                        catch (Exception exp) { MessageBox.Show("Fill all the columns of table (status) it can not be null"); }

                    }


                }
                document.Add(table);
                document.Close();
            }

            catch (Exception exp) { MessageBox.Show("Fill all the columns of table (status) it can not be null"); }
            // Close the document
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (cbSelectReport.Text == "CLO Wise Class Result")
            {
                name = cbSelectReport.Text;
                line = "Report of Clo Wise result of Students According to the Assessment Components they have attempted yet";
                ExportToPDF(dgvReport, name, line);
                MessageBox.Show("Report Generated");

            }
            else if (cbSelectReport.Text == "Rubric Wise Class Result")
            {
                name = "Rubric Wise Class Result";
                line = "Report of Rubric Wise result of Students to make improvment in future";
                ExportToPDF(dgvReport, name, line);
                MessageBox.Show("Report Generated");
            }
            else if (cbSelectReport.Text == "Assessment Wise Class Result")
            {
                name = "Assessment Wise Class Result";
                line = "Report of Students per Assessment Wise shows the marks of each Assessment Components with Assessment Components";
                ExportToPDF(dgvReport, name, line);
                MessageBox.Show("Report Generated");
            }
            else if (cbSelectReport.Text == "Count of Student Attendance per Month")
            {
                name = "Count of Student Attendance per Month";
                line = "Report of Student Attendance perMonth with the count of Present, Absent,leave and Late students";
                ExportToPDF(dgvReport, name, line);
                MessageBox.Show("Report Generated");

            }
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (cbSelectReport.Text == "CLO Wise Class Result")
            {
                load1();
            }
            else if (cbSelectReport.Text == "Rubric Wise Class Result")
            {
                load2();
            }
            else if (cbSelectReport.Text == "Assessment Wise Class Result")
            {
                load3();
            }
            else if (cbSelectReport.Text == "Count of Student Attendance per Month")
            {
                load4();
            }
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
