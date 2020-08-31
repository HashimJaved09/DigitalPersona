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

        public ShowPerson(object p)
        {
            InitializeComponent();
            this.iPersonID = (int)p;
            GetData();
        }

        private void GetData()
        {
            try
            {
                DataTable dt = db.getPerson(this.iPersonID);

                if (dt.Rows.Count > 0)
                {
                    this.nameTextBox.Text = dt.Rows[0]["Name"].ToString();
                    this.cnicTextBox.Text = dt.Rows[0]["CNIC_Number"].ToString();
                    this.phoneTextBox.Text = dt.Rows[0]["Phone_Number"].ToString();
                    this.addressTextBox.Text = dt.Rows[0]["Address"].ToString();
                    this.notesTextBox.Text = dt.Rows[0]["Notes"].ToString();
                    this.imgName = dt.Rows[0]["Image_Name"].ToString();
                    this.imgFile = (byte[])dt.Rows[0]["Image_File"];
                    this.right_thumb = dt.Rows[0]["Right_Thumb"].ToString();

                    this.thumbAnswer.Text = ((this.right_thumb != "" && this.right_thumb.Length > 0) ? "YES" : "NO");

                    if (this.imgName.Length > 0 || this.imgFile.Length > 1)
                    {
                        string ext = this.imgName.Split('.').Last();
                        string picturesFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                        pathToWriteFile = picturesFolderPath + "\\" + this.cnicTextBox.Text + "." + ext;
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

                    if (File.Exists(pathToWriteFile))
                        File.Delete(pathToWriteFile);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error occured while deleting the Picture: " + error.ToString());
            }
        }
    }
}
