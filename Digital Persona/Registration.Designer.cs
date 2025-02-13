﻿namespace UareUSampleCSharp
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.name = new System.Windows.Forms.Label();
            this.cnic = new System.Windows.Forms.Label();
            this.guardian = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.phone = new System.Windows.Forms.Label();
            this.notes = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.enrollPictureBox = new System.Windows.Forms.PictureBox();
            this.txtEnroll = new System.Windows.Forms.TextBox();
            this.btnUploadPicture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.guardianTextBox = new System.Windows.Forms.MaskedTextBox();
            this.cnicTextBox = new System.Windows.Forms.MaskedTextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.deviceNotConnected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enrollPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(25, 17);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(42, 13);
            this.name.TabIndex = 0;
            this.name.Text = "Name *";
            // 
            // cnic
            // 
            this.cnic.AutoSize = true;
            this.cnic.Location = new System.Drawing.Point(25, 54);
            this.cnic.Name = "cnic";
            this.cnic.Size = new System.Drawing.Size(79, 13);
            this.cnic.TabIndex = 2;
            this.cnic.Text = "CNIC Number *";
            // 
            // guardian
            // 
            this.guardian.AutoSize = true;
            this.guardian.Location = new System.Drawing.Point(25, 92);
            this.guardian.Name = "guardian";
            this.guardian.Size = new System.Drawing.Size(78, 13);
            this.guardian.TabIndex = 4;
            this.guardian.Text = "Guardian CNIC";
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(25, 173);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(45, 13);
            this.address.TabIndex = 6;
            this.address.Text = "Address";
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.LightGreen;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(122, 558);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(235, 35);
            this.submitBtn.TabIndex = 8;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Location = new System.Drawing.Point(25, 131);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(72, 13);
            this.phone.TabIndex = 9;
            this.phone.Text = "Phone Numer";
            // 
            // notes
            // 
            this.notes.AutoSize = true;
            this.notes.Location = new System.Drawing.Point(25, 293);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(35, 13);
            this.notes.TabIndex = 11;
            this.notes.Text = "Notes";
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(453, 12);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(160, 120);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 13;
            this.picture.TabStop = false;
            // 
            // enrollPictureBox
            // 
            this.enrollPictureBox.Location = new System.Drawing.Point(671, 243);
            this.enrollPictureBox.Name = "enrollPictureBox";
            this.enrollPictureBox.Size = new System.Drawing.Size(350, 350);
            this.enrollPictureBox.TabIndex = 19;
            this.enrollPictureBox.TabStop = false;
            // 
            // txtEnroll
            // 
            this.txtEnroll.Location = new System.Drawing.Point(671, 39);
            this.txtEnroll.Multiline = true;
            this.txtEnroll.Name = "txtEnroll";
            this.txtEnroll.Size = new System.Drawing.Size(350, 186);
            this.txtEnroll.TabIndex = 18;
            // 
            // btnUploadPicture
            // 
            this.btnUploadPicture.BackColor = System.Drawing.Color.LightBlue;
            this.btnUploadPicture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUploadPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnUploadPicture.ForeColor = System.Drawing.Color.White;
            this.btnUploadPicture.Location = new System.Drawing.Point(378, 558);
            this.btnUploadPicture.Name = "btnUploadPicture";
            this.btnUploadPicture.Size = new System.Drawing.Size(235, 35);
            this.btnUploadPicture.TabIndex = 20;
            this.btnUploadPicture.Text = "Upload Picture";
            this.btnUploadPicture.UseVisualStyleBackColor = false;
            this.btnUploadPicture.Click += new System.EventHandler(this.btnUploadPicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(668, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Place your Right Thumb on the Device";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Location = new System.Drawing.Point(122, 290);
            this.notesTextBox.MaxLength = 5000;
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(491, 240);
            this.notesTextBox.TabIndex = 29;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(122, 168);
            this.addressTextBox.MaxLength = 500;
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(491, 96);
            this.addressTextBox.TabIndex = 28;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(122, 128);
            this.phoneTextBox.Mask = "0000-0000000";
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(235, 20);
            this.phoneTextBox.TabIndex = 27;
            // 
            // guardianTextBox
            // 
            this.guardianTextBox.Location = new System.Drawing.Point(122, 89);
            this.guardianTextBox.Mask = "00000-0000000-0";
            this.guardianTextBox.Name = "guardianTextBox";
            this.guardianTextBox.Size = new System.Drawing.Size(235, 20);
            this.guardianTextBox.TabIndex = 26;
            // 
            // cnicTextBox
            // 
            this.cnicTextBox.Location = new System.Drawing.Point(122, 51);
            this.cnicTextBox.Mask = "00000-0000000-0";
            this.cnicTextBox.Name = "cnicTextBox";
            this.cnicTextBox.Size = new System.Drawing.Size(235, 20);
            this.cnicTextBox.TabIndex = 25;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(122, 14);
            this.nameTextBox.MaxLength = 100;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(235, 20);
            this.nameTextBox.TabIndex = 24;
            // 
            // deviceNotConnected
            // 
            this.deviceNotConnected.AutoSize = true;
            this.deviceNotConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceNotConnected.ForeColor = System.Drawing.Color.Red;
            this.deviceNotConnected.Location = new System.Drawing.Point(860, 12);
            this.deviceNotConnected.Name = "deviceNotConnected";
            this.deviceNotConnected.Size = new System.Drawing.Size(188, 20);
            this.deviceNotConnected.TabIndex = 30;
            this.deviceNotConnected.Text = "Device Not Connected";
            this.deviceNotConnected.Visible = false;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1060, 602);
            this.Controls.Add(this.deviceNotConnected);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.guardianTextBox);
            this.Controls.Add(this.cnicTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUploadPicture);
            this.Controls.Add(this.enrollPictureBox);
            this.Controls.Add(this.txtEnroll);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.address);
            this.Controls.Add(this.guardian);
            this.Controls.Add(this.cnic);
            this.Controls.Add(this.name);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1076, 641);
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration Form";
            this.Closed += new System.EventHandler(this.Registration_Closed);
            this.Load += new System.EventHandler(this.Registration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enrollPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label cnic;
        private System.Windows.Forms.Label guardian;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Label notes;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.PictureBox enrollPictureBox;
        internal System.Windows.Forms.TextBox txtEnroll;
        private System.Windows.Forms.Button btnUploadPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.MaskedTextBox phoneTextBox;
        private System.Windows.Forms.MaskedTextBox guardianTextBox;
        private System.Windows.Forms.MaskedTextBox cnicTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label deviceNotConnected;
    }
}