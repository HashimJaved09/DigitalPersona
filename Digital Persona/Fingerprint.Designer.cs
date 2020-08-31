namespace UareUSampleCSharp
{
    partial class Fingerprint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.okButton = new System.Windows.Forms.Button();
            this.enrollPictureBox = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtEnroll = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.enrollPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(571, 234);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "Save";
            // 
            // enrollPictureBox
            // 
            this.enrollPictureBox.Location = new System.Drawing.Point(358, 15);
            this.enrollPictureBox.Name = "enrollPictureBox";
            this.enrollPictureBox.Size = new System.Drawing.Size(288, 213);
            this.enrollPictureBox.TabIndex = 11;
            this.enrollPictureBox.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(276, 234);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtEnroll
            // 
            this.txtEnroll.Location = new System.Drawing.Point(12, 15);
            this.txtEnroll.Multiline = true;
            this.txtEnroll.Name = "txtEnroll";
            this.txtEnroll.Size = new System.Drawing.Size(339, 213);
            this.txtEnroll.TabIndex = 9;
            // 
            // Fingerprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 273);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.enrollPictureBox);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtEnroll);
            this.MaximumSize = new System.Drawing.Size(674, 312);
            this.MinimumSize = new System.Drawing.Size(374, 312);
            this.Name = "Fingerprint";
            this.Text = "Fingerprint";
            this.Closed += new System.EventHandler(this.Fingerprint_Closed);
            this.Load += new System.EventHandler(this.Fingerprint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.enrollPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox enrollPictureBox;
        internal System.Windows.Forms.Button btnBack;
        internal System.Windows.Forms.TextBox txtEnroll;
    }
}