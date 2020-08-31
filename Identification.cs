using System;
using System.Data;
using System.Windows.Forms;
using DPUruNet;
using System.Collections.Generic;

namespace UareUSampleCSharp
{
    public partial class Identification : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        public Form_Main _sender;
        Database db = new Database();
        List<int> IDs = new List<int>();
        List<Fmd> fmds = new List<Fmd>();
        Dictionary<Fmd, int> fmdsDic = new Dictionary<Fmd, int>();
        Dictionary<int, Fmd> matchedFmds = new Dictionary<int, Fmd>();
        private const int PROBABILITY_ONE = 0x7fffffff;

        private const int DPFJ_PROBABILITY_ONE = 0x7fffffff;
        private Fmd rightIndex;
        private Fmd rightThumb;
        private Fmd anyFinger;
        private int count;

        public Identification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Identification_Load(object sender, System.EventArgs e)
        {
            getData();

            txtIdentify.Text = string.Empty;
            rightIndex = null;
            rightThumb = null;
            anyFinger = null;
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

        private void getData()
        {
            try
            {
                DataTable dt = db.getFingerPrints();

                foreach (DataRow row in dt.Rows)
                {
                    if (row["Right_Thumb"].ToString() != "")
                    {
                        Fmd temp = Fmd.DeserializeXml(row["Right_Thumb"].ToString());

                        fmds.Add(temp);
                        fmdsDic.Add(temp, (int)row["iPersonID"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured while getting Finger Prints: " + e.ToString());
            }
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

                SendMessage(Action.SendMessage, "A finger was captured.");

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                SendMessage(Action.SendMessage, "Please wait while searching is done in background.");

                anyFinger = resultConversion.Data;
                Fmd[] fmdsArray = fmds.ToArray();

                foreach (Fmd fmd in fmdsArray)
                {
                    CompareResult compareResult = Comparison.Compare(anyFinger, 0, fmd, 0);
                    if (compareResult.Score < (PROBABILITY_ONE / 100000))
                    {
                        IDs.Add(fmdsDic[fmd]);
                    }
                }
                SendMessage(Action.SendMessage, IDs.Count.ToString() + " Finger Print(s) Matched.");
                count = 0;

                if (IDs.Count > 0)
                {
                    SendMessage(Action.ShowMatchedEntry, "");
                }
                else
                {
                    SendMessage(Action.HideMatchedEntry, "");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Identification: " + ex.Message);             
            }
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void btnBack_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void Identification_Closed(object sender, System.EventArgs e)
        {
            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
        }

        #region SendMessage
        private enum Action
        {
            SendMessage,
            ShowMatchedEntry,
            HideMatchedEntry
        }
        private delegate void SendMessageCallback(Action action, string payload);
        private void SendMessage(Action action, string payload)
        {
            try
            {
                if (this.txtIdentify.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            txtIdentify.Text += payload + "\r\n\r\n";
                            txtIdentify.SelectionStart = txtIdentify.TextLength;
                            txtIdentify.ScrollToCaret();
                            break;
                        case Action.ShowMatchedEntry:
                            this.btnShowResult.Visible = true;
                            break;
                        case Action.HideMatchedEntry:
                            this.btnShowResult.Visible = false;
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion
        
        private SearchFingerPrint _searchFingerPrint;
        private void btnShowResult_Click(object sender, EventArgs e)
        {
            if (_searchFingerPrint == null)
            {
                _searchFingerPrint = new SearchFingerPrint(this.IDs);
            }

            _searchFingerPrint.ShowDialog();

            _searchFingerPrint.Dispose();
            _searchFingerPrint = null;
        }
    }
}