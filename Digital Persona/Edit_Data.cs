using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPUruNet;
using System.Drawing.Imaging;

namespace UareUSampleCSharp
{
    public partial class Edit_Data : Form
    {
        public Form_Main _sender;

        private int iPersonID;
        Database db = new Database();
        DataTable dataTable = new DataTable();
        List<Fmd> preenrollmentFmds;
        string selectedPath = "";
        Byte[] imgFile = { 0x0 };
        string imgName = "";
        string right_thumb = "";
        string pathToWriteFile = "";
        int count;

        public Edit_Data(object p)
        {
            InitializeComponent();
            this.iPersonID = (int)p;
            count = 0;
        }

        private void Edit_Data_Load(object sender, EventArgs e)
        {
            this.nameTextBox.Focus();
            preenrollmentFmds = new List<Fmd>();

            GetData();

            SendMessage(Action.SendMessage, "Place your Right Thumb on the device.");

            if (!_sender.OpenReader())
            {
                //this.Close();
                this.txtEnroll.Visible = false;
                this.enrollPictureBox.Visible = false;
                this.deviceNotConnected.Visible = true;
            }
            else
                this.deviceNotConnected.Visible = false;

            if (!_sender.StartCaptureAsync(this.OnCaptured))
            {
                //this.Close();
                this.txtEnroll.Visible = false;
                this.enrollPictureBox.Visible = false;
                this.deviceNotConnected.Visible = true;
            }
            else
                this.deviceNotConnected.Visible = false;
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

                    if (this.imgName.Length > 0 || this.imgFile.Length > 1)
                    {
                        string ext = this.imgName.Split('.').Last();
                        string picturesFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                        pathToWriteFile = picturesFolderPath + "\\" + this.cnicTextBox.Text + "." + ext;

                        if (!File.Exists(pathToWriteFile))
                            File.WriteAllBytes(pathToWriteFile, this.imgFile);

                        this.picture.Image = Image.FromFile(pathToWriteFile);
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

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            try
            {
                Thread t = new Thread((ThreadStart)(() =>
                {
                    OpenFileDialog saveFileDialog1 = new OpenFileDialog();

                    saveFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;)|*.jpg;*.jpeg;*.png;*.gif";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        selectedPath = saveFileDialog1.FileName;
                    }
                }));

                // Run your code from a thread that joins the STA Thread
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();

                imgName = selectedPath;

                if (!imgName.Equals(""))
                {
                    imgFile = File.ReadAllBytes(selectedPath);

                    this.picture.Image = Image.FromFile(imgName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while Uploading/Canceling Picture: " + ex.ToString());
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int status = 0;
                string nameDTO = this.nameTextBox.Text.Trim();
                string guardianDTO = guardianTextBox.Text.Replace("-", "");
                string cnicDTO = cnicTextBox.Text.Replace("-", "");
                string phoneDTO = this.phoneTextBox.Text.Replace("-", "");
                string addressDTO = this.addressTextBox.Text.Trim();
                string notesDTO = this.notesTextBox.Text.Trim();
                string rightThumbDTO = this.right_thumb;
                string imageNameDTO = this.imgName.Trim();
                byte[] imageFileDTO = this.imgFile;

                if (this.nameTextBox.Text.Trim() == "" || this.nameTextBox.Text.Trim() == null || this.nameTextBox.Text.Trim().Length < 3)
                {
                    MessageBox.Show("Please Enter Name. Minimum Length of Name is 3 Characters.");
                    this.nameTextBox.Focus();
                    return;
                }
                if (this.guardianTextBox.Text.Replace("-", "") == null || (this.guardianTextBox.Text.Replace("-", "").Replace(" ", "").Length > 0 && this.guardianTextBox.Text.Replace("-", "").Replace(" ", "").Length < 13))
                {
                    MessageBox.Show("Please Enter a Valid Guardian CNIC Number.");
                    this.guardianTextBox.Focus();
                    return;
                }
                if (this.cnicTextBox.Text.Replace("-", "") == "" || this.cnicTextBox.Text.Replace("-", "") == null || (this.cnicTextBox.Text.Replace("-", "").Replace(" ", "").Length > 0 && this.cnicTextBox.Text.Replace("-", "").Replace(" ", "").Length < 13))
                {
                    MessageBox.Show("Please Enter a Valid CNIC Number.");
                    this.cnicTextBox.Focus();
                    return;
                }
                if (this.phoneTextBox.Text.Replace("-", "") == null || (this.phoneTextBox.Text.Replace("-", "").Replace(" ", "").Length > 0 && this.phoneTextBox.Text.Replace("-", "").Replace(" ", "").Length < 11))
                {
                    MessageBox.Show("Please Enter a Valid Phone Number.");
                    this.phoneTextBox.Focus();
                    return;
                }

                if (rightThumbDTO == "" && _sender.CurrentReader != null)
                {
                    DialogResult dr = MessageBox.Show("Save without scanning thumb?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        status = db.updatePerson(iPersonID, nameDTO, guardianDTO, cnicDTO, phoneDTO, addressDTO, notesDTO, rightThumbDTO, imageNameDTO, imageFileDTO);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    status = db.updatePerson(iPersonID, nameDTO, guardianDTO, cnicDTO, phoneDTO, addressDTO, notesDTO, rightThumbDTO, imageNameDTO, imageFileDTO);
                }

                if (status == 1)
                {
                    MessageBox.Show("Data Updated Successfully!");
                }
                else if (status == 0)
                {
                    MessageBox.Show("CNIC Already Registered.");
                    this.cnicTextBox.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occured please try again.");
                Console.WriteLine("Error: " + error.ToString());
            }
        }

        private void Edit_Data_Closed(object sender, System.EventArgs e)
        {
            try
            {
                if (!this.imgName.Equals(""))
                {
                    this.picture.Image.Dispose();
                }

                if (!File.Exists(pathToWriteFile))
                    File.Delete(pathToWriteFile);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error occured while deleting the Picture: " + error.ToString());
            }

            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
        }

        #region SendMessage

        private enum Action
        {
            SendBitmap,
            SendMessage,
            WindowEnlargement,
            UpdateReaderState
        }

        private delegate void SendMessageCallback(Action action, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.txtEnroll.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            txtEnroll.Text += payload + "\r\n\r\n";
                            txtEnroll.SelectionStart = txtEnroll.TextLength;
                            txtEnroll.ScrollToCaret();
                            break;
                        case Action.SendBitmap:
                            this.enrollPictureBox.Image = (Bitmap)payload;
                            this.enrollPictureBox.Refresh();
                            break;
                        case Action.WindowEnlargement:
                            break;
                        case Action.UpdateReaderState:
                            if ((Reader)payload != null)
                            {
                                this.txtEnroll.Visible = true;
                                this.enrollPictureBox.Visible = true;
                                this.deviceNotConnected.Visible = false;
                            }
                            else
                            {
                                this.txtEnroll.Visible = false;
                                this.enrollPictureBox.Visible = false;
                                this.deviceNotConnected.Visible = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region HeavyFunctions

        /// <summary>
        /// Create a bitmap from raw data in row/column format.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, 93, 95), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }

        /// <summary>
        /// Handler for when a fingerprint is captured.
        /// </summary>
        /// <param name="captureResult">contains info and data on the fingerprint capture</param>
        private void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!_sender.CheckCaptureResult(captureResult)) return;

                count++;

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);

                if (count > 0)
                {
                    Fid.Fiv fiv = captureResult.Data.Views[0];
                    SendMessage(Action.SendBitmap, CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }

                SendMessage(Action.SendMessage, "A Reading was captured.  \r\nCount:  " + (count));

                if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(resultConversion.ResultCode.ToString());
                }

                preenrollmentFmds.Add(resultConversion.Data);

                if (count >= 4)
                {
                    DataResult<Fmd> resultEnrollment = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, preenrollmentFmds);

                    if (resultEnrollment.ResultCode == Constants.ResultCode.DP_SUCCESS)
                    {
                        SendMessage(Action.SendMessage, "An enrollment FMD was successfully created.");
                        SendMessage(Action.SendMessage, "Place Right Thumb on the device.");
                        preenrollmentFmds.Clear();
                        count = 0;

                        this.right_thumb = Fmd.SerializeXml(resultConversion.Data);

                        return;
                    }
                    else if (resultEnrollment.ResultCode == Constants.ResultCode.DP_ENROLLMENT_INVALID_SET)
                    {
                        SendMessage(Action.SendMessage, "Enrollment was unsuccessful.  Please try again.");
                        SendMessage(Action.SendMessage, "Place Right Thumb on the device.");
                        preenrollmentFmds.Clear();
                        count = 0;
                        return;
                    }
                }

                SendMessage(Action.SendMessage, "Now place the same finger on the device.");
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);
            }
        }

        #endregion
    }
}
