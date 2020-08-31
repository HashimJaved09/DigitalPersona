using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UareUSampleCSharp
{
    public partial class SearchFingerPrint : Form
    {
        private List<int> IDs;
        Database db = new Database();
        DataTable dt = new DataTable();

        public SearchFingerPrint(List<int> list)
        {
            InitializeComponent();

            this.IDs = list;

            dt.Columns.Add("iPersonID");
            dt.Columns.Add("Name");
            dt.Columns.Add("CNIC_Number");
            dt.Columns.Add("Phone_Number");
            dt.Columns.Add("Address");
        }

        private void SearchFingerPrint_Load(object sender, EventArgs e)
        {
            dt = db.getPersonLessData(0).Clone();

            getData();
        }

        private void getData()
        {
            try
            {
                foreach(int id in IDs)
                {
                    DataTable temp = db.getPersonLessData(id);
                    
                    if (temp.Rows.Count > 0)
                    {
                        dt.ImportRow(temp.Rows[0]);
                    }
                }

                this.dataGridView1.DataSource = dt;

                DataGridViewButtonColumn showDetailsButton = new DataGridViewButtonColumn();
                showDetailsButton.HeaderText = "Show Details";
                showDetailsButton.Name = "Show_Details";
                showDetailsButton.Text = "Show Details";
                showDetailsButton.UseColumnTextForButtonValue = true;

                if (dt.Rows.Count > 0 && dataGridView1.Columns["Show_Details"] == null)
                {
                    dataGridView1.Columns.Add(showDetailsButton);
                    this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured while getting Results for Matched Finger Prints: " + e.ToString());
            }
        }

        private ShowPerson _showPerson;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (_showPerson == null)
                {
                    _showPerson = new ShowPerson(dt.Rows[e.RowIndex]["iPersonID"]);
                }

                _showPerson.ShowDialog();

                _showPerson.Dispose();
                _showPerson = null;
            }
        }
    }
}
