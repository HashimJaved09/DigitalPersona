namespace UareUSampleCSharp
{
    partial class Identification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Identification));
            this.btnBack = new System.Windows.Forms.Button();
            this.txtIdentify = new System.Windows.Forms.TextBox();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(276, 229);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtIdentify
            // 
            this.txtIdentify.Location = new System.Drawing.Point(12, 10);
            this.txtIdentify.Multiline = true;
            this.txtIdentify.Name = "txtIdentify";
            this.txtIdentify.Size = new System.Drawing.Size(339, 213);
            this.txtIdentify.TabIndex = 5;
            // 
            // btnShowResult
            // 
            this.btnShowResult.Location = new System.Drawing.Point(12, 229);
            this.btnShowResult.Name = "btnShowResult";
            this.btnShowResult.Size = new System.Drawing.Size(143, 23);
            this.btnShowResult.TabIndex = 7;
            this.btnShowResult.Text = "Show Matched Entries";
            this.btnShowResult.Visible = false;
            this.btnShowResult.Click += new System.EventHandler(this.btnShowResult_Click);
            // 
            // Identification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(358, 273);
            this.Controls.Add(this.btnShowResult);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtIdentify);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(374, 312);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(374, 312);
            this.Name = "Identification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search with Finger Print";
            this.Closed += new System.EventHandler(this.Identification_Closed);
            this.Load += new System.EventHandler(this.Identification_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnBack;
        internal System.Windows.Forms.TextBox txtIdentify;
        internal System.Windows.Forms.Button btnShowResult;
    }
}