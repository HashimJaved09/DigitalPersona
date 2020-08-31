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
    public partial class SearchPerson : Form
    {
        DataTable dt = new DataTable();
        Database db = new Database();

        public SearchPerson()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dt = db.searchPerson(this.nameTextBox.Text.Trim(), this.cnicTextBox.Text.Trim(), this.phoneTextBox.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    SetData(dt);
                }
                else
                {
                    SendMessage(Action.Delarge, "");

                    if (dataGridView1.Columns["Show_Details"] != null)
                    {
                        this.dataGridView1.Columns.Remove("Show_Details");
                    }
                    this.dataGridView1.DataSource = null;
                    MessageBox.Show("No Match Found!");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error while Fetching Person: " + error.ToString());
            }
        }

        private void SetData(DataTable dt)
        {
            try
            {
                SendMessage(Action.Enlarge, "");

                dataGridView1.DataSource = dt;

                DataGridViewButtonColumn showDetailsButton = new DataGridViewButtonColumn();
                showDetailsButton.HeaderText = "Show Details";
                showDetailsButton.Name = "Show_Details";
                showDetailsButton.Text = "Show Details";
                showDetailsButton.UseColumnTextForButtonValue = true;

                if (dataGridView1.Columns["Show_Details"] == null)
                {
                    dataGridView1.Columns.Add(showDetailsButton);
                    this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error while Searching Persons: " + error.ToString());
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

        #region SendMessage
        private enum Action
        {
            Enlarge,
            Delarge
        }
        private delegate void SendMessageCallback(Action state, object payload);
        private void SendMessage(Action state, object payload)
        {
            if (this.cnicTextBox.InvokeRequired)
            {
                SendMessageCallback d = new SendMessageCallback(SendMessage);
                this.Invoke(d, new object[] { state, payload });
            }
            else
            {
                switch (state)
                {
                    case Action.Enlarge:
                        this.Size = new Size(700, 520);
                        this.dataGridView1.Visible = true;
                        break;
                    case Action.Delarge:
                        this.Size = new Size(519, 370);
                        this.dataGridView1.Visible = false;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
    }
}
