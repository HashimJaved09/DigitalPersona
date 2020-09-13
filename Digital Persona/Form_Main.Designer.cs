namespace UareUSampleCSharp
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.txtReaderSelected = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnReaderSelect = new System.Windows.Forms.Button();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.btnShowPersons = new System.Windows.Forms.Button();
            this.btnSearchPerson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtReaderSelected
            // 
            this.txtReaderSelected.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtReaderSelected.Location = new System.Drawing.Point(12, 37);
            this.txtReaderSelected.Name = "txtReaderSelected";
            this.txtReaderSelected.ReadOnly = true;
            this.txtReaderSelected.Size = new System.Drawing.Size(236, 20);
            this.txtReaderSelected.TabIndex = 7;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(236, 15);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "Selected Device:";
            // 
            // btnIdentify
            // 
            this.btnIdentify.BackColor = System.Drawing.SystemColors.Control;
            this.btnIdentify.Enabled = false;
            this.btnIdentify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIdentify.Location = new System.Drawing.Point(12, 216);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(236, 35);
            this.btnIdentify.TabIndex = 12;
            this.btnIdentify.Text = "Search with Finger Print";
            this.btnIdentify.UseVisualStyleBackColor = false;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnReaderSelect
            // 
            this.btnReaderSelect.BackColor = System.Drawing.SystemColors.Control;
            this.btnReaderSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReaderSelect.Location = new System.Drawing.Point(12, 70);
            this.btnReaderSelect.Name = "btnReaderSelect";
            this.btnReaderSelect.Size = new System.Drawing.Size(236, 35);
            this.btnReaderSelect.TabIndex = 8;
            this.btnReaderSelect.Text = "Device Selection";
            this.btnReaderSelect.UseVisualStyleBackColor = false;
            this.btnReaderSelect.Click += new System.EventHandler(this.btnReaderSelect_Click);
            // 
            // btnRegistration
            // 
            this.btnRegistration.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistration.Location = new System.Drawing.Point(12, 118);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(236, 35);
            this.btnRegistration.TabIndex = 19;
            this.btnRegistration.Text = "Registration";
            this.btnRegistration.UseVisualStyleBackColor = false;
            this.btnRegistration.Click += new System.EventHandler(this.registration_Click);
            // 
            // btnShowPersons
            // 
            this.btnShowPersons.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowPersons.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnShowPersons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnShowPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPersons.Location = new System.Drawing.Point(12, 264);
            this.btnShowPersons.Name = "btnShowPersons";
            this.btnShowPersons.Size = new System.Drawing.Size(236, 35);
            this.btnShowPersons.TabIndex = 20;
            this.btnShowPersons.Text = "Show All Records";
            this.btnShowPersons.UseVisualStyleBackColor = false;
            this.btnShowPersons.Click += new System.EventHandler(this.btnShowPersons_Click);
            // 
            // btnSearchPerson
            // 
            this.btnSearchPerson.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearchPerson.FlatAppearance.BorderSize = 0;
            this.btnSearchPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPerson.Location = new System.Drawing.Point(12, 167);
            this.btnSearchPerson.Name = "btnSearchPerson";
            this.btnSearchPerson.Size = new System.Drawing.Size(236, 35);
            this.btnSearchPerson.TabIndex = 21;
            this.btnSearchPerson.Text = "Search a Person";
            this.btnSearchPerson.UseVisualStyleBackColor = false;
            this.btnSearchPerson.Click += new System.EventHandler(this.btnSearchRecord_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(261, 311);
            this.Controls.Add(this.btnSearchPerson);
            this.Controls.Add(this.btnShowPersons);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.txtReaderSelected);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.btnReaderSelect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(277, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(277, 320);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Entry Software";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtReaderSelected;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnIdentify;
        internal System.Windows.Forms.Button btnReaderSelect;
        internal System.Windows.Forms.Button btnRegistration;
        internal System.Windows.Forms.Button btnShowPersons;
        internal System.Windows.Forms.Button btnSearchPerson;
    }
}