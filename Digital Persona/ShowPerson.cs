using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UareUSampleCSharp
{
    public partial class ShowPerson : Form
    {
        int iPersonID;
        private object p;
        string imgName = "";
        byte[] imgFile = {0x0};
        string right_thumb = "";
        string pathToWriteFile = "";
        Database db = new Database();
        DataTable dataTable = new DataTable();

        public ShowPerson(object p)
        {
            InitializeComponent();
            this.iPersonID = (int)p;
        }

        private void ShowPerson_Load(object sender, EventArgs e)
        {
            GetData();

            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "SearchPerson")
                {
                    this.btnEdit.Visible = true;
                    break;
                }
                else
                {
                    this.btnEdit.Visible = false;
                }
            }
        }

        private void GetData()
        {
            try
            {
                this.dataTable = db.getPerson(this.iPersonID);

                if (dataTable.Rows.Count > 0)
                {
                    this.nameTextBox.Text = dataTable.Rows[0]["Name"].ToString();
                    this.cnicTextBox.Text = dataTable.Rows[0]["CNIC_Number"].ToString();
                    this.guardianTextBox.Text = dataTable.Rows[0]["Guardian_CNIC"].ToString();
                    this.phoneTextBox.Text = dataTable.Rows[0]["Phone_Number"].ToString();
                    this.addressTextBox.Text = dataTable.Rows[0]["Address"].ToString();
                    this.notesTextBox.Text = dataTable.Rows[0]["Notes"].ToString();
                    this.imgName = dataTable.Rows[0]["Image_Name"].ToString();
                    this.imgFile = (byte[])dataTable.Rows[0]["Image_File"];
                    this.right_thumb = dataTable.Rows[0]["Right_Thumb"].ToString();

                    this.thumbAnswer.Text = ((this.right_thumb != "" && this.right_thumb.Length > 0) ? "YES" : "NO");

                    if (this.imgName.Length > 0 || this.imgFile.Length > 1)
                    {
                        string ext = this.imgName.Split('.').Last();
                        string picturesFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                        pathToWriteFile = picturesFolderPath + "\\" + this.cnicTextBox.Text + "." + ext;

                        if (!File.Exists(pathToWriteFile))
                            File.WriteAllBytes(pathToWriteFile, this.imgFile);

                        this.pictureBox.Image = Image.FromFile(pathToWriteFile);
                    }
                }
                else
                {
                    MessageBox.Show("No Match Found!");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error while Fetching Person: " + error.ToString());
            }
        }

        private void ShowPerson_Closed(object sender, EventArgs e)
        {
            try
            {
                if (!this.pathToWriteFile.Equals(""))
                {
                    this.pictureBox.Image.Dispose();
                }

                if (File.Exists(pathToWriteFile))
                    File.Delete(pathToWriteFile);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error occured while deleting the Picture: " + error.ToString());
            }
        }
        
        private Edit_Data _editData;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_editData == null)
            {
                _editData = new Edit_Data(this.iPersonID);
                _editData._sender = (Form_Main)Application.OpenForms["Form_Main"];
            }

            //foreach (Form form in Application.OpenForms)
            //{
            //    if (form.Name == "ShowPersons")
            //    {
            //        ShowPersons GrandParent = null;

            //        GrandParent = (ShowPersons)Application.OpenForms["ShowPersons"];
            //        GrandParent.MdiParent = this.ParentForm;

            //        this.Dispose();
            //        _editData.ShowDialog();
            //        GrandParent.GetData();

            //        break;
            //    }
            //    else if (form.Name == "SearchPerson")
            //    {
            //        SearchPerson GrandParent = null;

            //        GrandParent = (SearchPerson)Application.OpenForms["SearchPerson"];
            //        GrandParent.MdiParent = this.ParentForm;

            //        this.Dispose();
            //        _editData.ShowDialog();
            //        GrandParent.ClearData();

            //        break;
            //    }
            //    else if (form.Name == "SearchFingerPrint")
            //    {
            //        SearchFingerPrint GrandParent = null;

            //        GrandParent = (SearchFingerPrint)Application.OpenForms["SearchFingerPrint"];
            //        GrandParent.MdiParent = this.ParentForm;

            //        this.Dispose();
            //        _editData.ShowDialog();
            //        GrandParent.RelaodData();

            //        break;
            //    }
            //}

            SearchPerson GrandParent = new SearchPerson();

            GrandParent = (SearchPerson)Application.OpenForms["SearchPerson"];
            GrandParent.MdiParent = this.ParentForm;

            this.Dispose();
            _editData.ShowDialog();
            GrandParent.ClearData();

            _editData.Dispose();
            _editData = null;
        }

        public object dt { get; set; }
    }
}
