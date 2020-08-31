namespace UareUSampleCSharp
{
    partial class ShowPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowPerson));
            this.name = new System.Windows.Forms.Label();
            this.cnic = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.Label();
            this.notes = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.cnicTextBox = new System.Windows.Forms.MaskedTextBox();
            this.phoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(13, 13);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(35, 13);
            this.name.TabIndex = 0;
            this.name.Text = "Name";
            // 
            // cnic
            // 
            this.cnic.AutoSize = true;
            this.cnic.Location = new System.Drawing.Point(13, 42);
            this.cnic.Name = "cnic";
            this.cnic.Size = new System.Drawing.Size(72, 13);
            this.cnic.TabIndex = 4;
            this.cnic.Text = "CNIC Number";
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Location = new System.Drawing.Point(13, 72);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(78, 13);
            this.phone.TabIndex = 6;
            this.phone.Text = "Phone Number";
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(13, 101);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(45, 13);
            this.address.TabIndex = 8;
            this.address.Text = "Address";
            // 
            // notes
            // 
            this.notes.AutoSize = true;
            this.notes.Location = new System.Drawing.Point(13, 165);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(35, 13);
            this.notes.TabIndex = 10;
            this.notes.Text = "Notes";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Location = new System.Drawing.Point(124, 165);
            this.notesTextBox.MaxLength = 5000;
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ReadOnly = true;
            this.notesTextBox.Size = new System.Drawing.Size(491, 140);
            this.notesTextBox.TabIndex = 13;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(124, 10);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(250, 20);
            this.nameTextBox.TabIndex = 14;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(124, 101);
            this.addressTextBox.MaxLength = 500;
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.ReadOnly = true;
            this.addressTextBox.Size = new System.Drawing.Size(250, 49);
            this.addressTextBox.TabIndex = 17;
            // 
            // cnicTextBox
            // 
            this.cnicTextBox.Location = new System.Drawing.Point(124, 39);
            this.cnicTextBox.Mask = "00000-0000000-0";
            this.cnicTextBox.Name = "cnicTextBox";
            this.cnicTextBox.ReadOnly = true;
            this.cnicTextBox.Size = new System.Drawing.Size(250, 20);
            this.cnicTextBox.TabIndex = 18;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(124, 69);
            this.phoneTextBox.Mask = "0000-0000000";
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.ReadOnly = true;
            this.phoneTextBox.Size = new System.Drawing.Size(250, 20);
            this.phoneTextBox.TabIndex = 19;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(455, 10);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(160, 120);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 20;
            this.pictureBox.TabStop = false;
            // 
            // ShowPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 324);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.cnicTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.address);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.cnic);
            this.Controls.Add(this.name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Person Detail";
            this.Closed += new System.EventHandler(this.ShowPerson_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label cnic;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label notes;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.MaskedTextBox cnicTextBox;
        private System.Windows.Forms.MaskedTextBox phoneTextBox;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}