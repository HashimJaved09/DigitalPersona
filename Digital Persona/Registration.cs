using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using DPUruNet;
using System.IO;
using System.Drawing.Imaging;

namespace UareUSampleCSharp
{
    public partial class Registration : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        public Form_Main _sender;

        List<Fmd> preenrollmentFmds;
        string selectedPath = "";
        Byte[] image_file = {0x0};
        string image_name = "";
        string rightThumb = "";
        int count;

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, System.EventArgs e)
        {
            txtEnroll.Text = string.Empty;
            preenrollmentFmds = new List<Fmd>();
            count = 0;

            SendMessage(Action.SendMessage, "Place your Right Thumb on the device.");

            if (!_sender.OpenReader())
            {
                this.Close();
            }

            if (!_sender.StartCaptureAsync(this.OnCaptured))
            {
                this.Close();
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int status = 0;
                Database db = new Database();
                string nameDTO = this.nameTextBox.Text.Trim();
                string guardianDTO = guardianTextBox.Text.Replace("-", "");
                string cnicDTO = cnicTextBox.Text.Replace("-", "");
                string phoneDTO = this.phoneTextBox.Text.Replace("-", "");
                string addressDTO = this.addressTextBox.Text.Trim();
                string notesDTO = this.notesTextBox.Text.Trim();
                string rightThumbDTO = this.rightThumb;
                string imageNameDTO = this.image_name.Trim();
                byte[] imageFileDTO = this.image_file;

                if (this.nameTextBox.Text.Trim() == "" || this.nameTextBox.Text.Trim() == null || this.nameTextBox.Text.Trim().Length < 5)
                {
                    MessageBox.Show("Please Enter Name. Minimum Length of Name is 5 Characters.");
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

                if (this.rightThumb == "")
                {
                    DialogResult dr = MessageBox.Show("Save without scanning thumb?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        status = db.insertData(nameDTO, guardianDTO, cnicDTO, phoneDTO, addressDTO, notesDTO, rightThumbDTO, imageNameDTO, imageFileDTO);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    status = db.insertData(nameDTO, guardianDTO, cnicDTO, phoneDTO, addressDTO, notesDTO, rightThumbDTO, imageNameDTO, imageFileDTO);
                }

                if (status == 1)
                {
                    MessageBox.Show("Data Inserted Successfully!");
                    ClearFeilds();
                }
                else if (status == -1)
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

                image_name = selectedPath;

                if (!image_name.Equals(""))
                {
                    image_file = File.ReadAllBytes(selectedPath);

                    this.picture.Image = Image.FromFile(image_name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while Uploading/Canceling Picture: " + ex.ToString());
            }
        }

        private void Registration_Closed(object sender, System.EventArgs e)
        {
            try
            {
                if (!this.image_name.Equals(""))
                {
                    this.picture.Image.Dispose();
                }
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
                            //this.okButton.Visible = true;
                            //this.enrollPictureBox.Visible = true;
                            //this.Size = new Size(674, 312);
                            break;
                        case Action.UpdateReaderState:
                            if ((Reader)payload != null)
                            {
                                //txtReaderSelected.Text = ((Reader)payload).Description.SerialNumber;
                                //btnCapture.Enabled = true;
                                //btnStreaming.Enabled = true;
                                //btnVerify.Enabled = true;
                                //btnIdentify.Enabled = true;
                                //btnEnroll.Enabled = true;
                                //btnEnrollmentControl.Enabled = true;

                                //this.buttonFingerPrint.Enabled = true;

                                //if (fmds.Count > 0)
                                //{
                                //    btnIdentificationControl.Enabled = true;
                                //}
                            }
                            else
                            {
                                //txtReaderSelected.Text = String.Empty;
                                //btnCapture.Enabled = false;
                                //btnStreaming.Enabled = false;
                                //btnVerify.Enabled = false;
                                //btnIdentify.Enabled = false;
                                //btnEnroll.Enabled = false;
                                //btnEnrollmentControl.Enabled = false;
                                //btnIdentificationControl.Enabled = false;

                                //this.buttonFingerPrint.Enabled = false;
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

                        this.rightThumb = Fmd.SerializeXml(resultConversion.Data);

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

        private void ClearFeilds()
        {
            this.nameTextBox.Text = "";
            this.guardianTextBox.Text = "";
            this.cnicTextBox.Text = "";
            this.phoneTextBox.Text = "";
            this.addressTextBox.Text = "";
            this.notesTextBox.Text = "";
            this.txtEnroll.Text = "";
            this.picture.Image = null;
            this.enrollPictureBox.Image = null;
            SendMessage(Action.SendMessage, "Place your Right Thumb on the device.");
        }

        #endregion
    }
}
