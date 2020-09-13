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
    public partial class ShowPersons : Form
    {
        DataTable dataTable;
        Database db = new Database();

        public ShowPersons()
        {
            InitializeComponent();
        }

        private void ShowPersons_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            try
            {
                dataTable = db.getPersons();

                if (dataTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dataTable;

                    DataGridViewButtonColumn showDetailsButton = new DataGridViewButtonColumn();
                    showDetailsButton.HeaderText = "Show Details";
                    showDetailsButton.Name = "Show_Details";
                    showDetailsButton.Text = "Show Details";
                    showDetailsButton.UseColumnTextForButtonValue = true;

                    if (dataTable.Rows.Count > 0 && dataGridView1.Columns["Show_Details"] == null)
                    {
                        dataGridView1.Columns.Add(showDetailsButton);
                        this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
                    }
                }
                else
                {
                    MessageBox.Show("No Records Found!");
                    this.Close();
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("Error while Fetching Persons: " + error.ToString());
            }
        }
        
        private ShowPerson _showPerson;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (_showPerson == null)
                {
                    _showPerson = new ShowPerson(dataTable.Rows[e.RowIndex]["iPersonID"]);
                }

                _showPerson.ShowDialog();

                _showPerson.Dispose();
                _showPerson = null;
            }
        }
    }
}
