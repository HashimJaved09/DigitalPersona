namespace UareUSampleCSharp
{
    partial class SearchPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchPerson));
            this.name = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cnic = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.cnicTextBox = new System.Windows.Forms.MaskedTextBox();
            this.phoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.guardianTextBox = new System.Windows.Forms.MaskedTextBox();
            this.guardian = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(13, 15);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(63, 13);
            this.name.TabIndex = 2;
            this.name.Text = "Enter Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(648, 339);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            // 
            // cnic
            // 
            this.cnic.AutoSize = true;
            this.cnic.Location = new System.Drawing.Point(13, 52);
            this.cnic.Name = "cnic";
            this.cnic.Size = new System.Drawing.Size(100, 13);
            this.cnic.TabIndex = 8;
            this.cnic.Text = "Enter CNIC Number";
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Location = new System.Drawing.Point(13, 89);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(106, 13);
            this.phone.TabIndex = 11;
            this.phone.Text = "Enter Phone Number";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(170, 15);
            this.nameTextBox.MaxLength = 100;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(194, 20);
            this.nameTextBox.TabIndex = 14;
            // 
            // cnicTextBox
            // 
            this.cnicTextBox.Location = new System.Drawing.Point(170, 49);
            this.cnicTextBox.Mask = "00000-0000000-0";
            this.cnicTextBox.Name = "cnicTextBox";
            this.cnicTextBox.Size = new System.Drawing.Size(194, 20);
            this.cnicTextBox.TabIndex = 15;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(170, 86);
            this.phoneTextBox.Mask = "0000-0000000";
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(194, 20);
            this.phoneTextBox.TabIndex = 16;
            // 
            // guardianTextBox
            // 
            this.guardianTextBox.Location = new System.Drawing.Point(170, 121);
            this.guardianTextBox.Mask = "00000-0000000-0";
            this.guardianTextBox.Name = "guardianTextBox";
            this.guardianTextBox.Size = new System.Drawing.Size(194, 20);
            this.guardianTextBox.TabIndex = 24;
            // 
            // guardian
            // 
            this.guardian.AutoSize = true;
            this.guardian.Location = new System.Drawing.Point(13, 124);
            this.guardian.Name = "guardian";
            this.guardian.Size = new System.Drawing.Size(146, 13);
            this.guardian.TabIndex = 23;
            this.guardian.Text = "Enter Guardian CNIC Number";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(388, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 35);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SearchPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 368);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.guardianTextBox);
            this.Controls.Add(this.guardian);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.cnicTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.cnic);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search a Person";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label cnic;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.MaskedTextBox cnicTextBox;
        private System.Windows.Forms.MaskedTextBox phoneTextBox;
        private System.Windows.Forms.MaskedTextBox guardianTextBox;
        private System.Windows.Forms.Label guardian;
        internal System.Windows.Forms.Button btnSearch;
    }
}