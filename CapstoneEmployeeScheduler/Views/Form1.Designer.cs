namespace CapstoneEmployeeScheduler.Views
{
    partial class EmployeeModal
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
            this.EmployeeTitle = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.shiftsAvailable = new System.Windows.Forms.TextBox();
            this.shiftsAvailableLabel = new System.Windows.Forms.Label();
            this.absentButton = new System.Windows.Forms.CheckBox();
            this.disableButton = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // EmployeeTitle
            // 
            this.EmployeeTitle.AutoSize = true;
            this.EmployeeTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.EmployeeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeTitle.Location = new System.Drawing.Point(163, 31);
            this.EmployeeTitle.Name = "EmployeeTitle";
            this.EmployeeTitle.Size = new System.Drawing.Size(261, 31);
            this.EmployeeTitle.TabIndex = 5;
            this.EmployeeTitle.Text = "Add/Edit Employee";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(24, 184);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(142, 24);
            this.emailLabel.TabIndex = 7;
            this.emailLabel.Text = "Email Address: ";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(24, 118);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(162, 24);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Employee Name: ";
            // 
            // emailBox
            // 
            this.emailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailBox.Location = new System.Drawing.Point(223, 180);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(349, 29);
            this.emailBox.TabIndex = 10;
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.Location = new System.Drawing.Point(223, 113);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(349, 29);
            this.nameBox.TabIndex = 9;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Aqua;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(85, 415);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(117, 39);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.Aqua;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(371, 415);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(114, 39);
            this.submitButton.TabIndex = 13;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            // 
            // shiftsAvailable
            // 
            this.shiftsAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shiftsAvailable.Location = new System.Drawing.Point(223, 249);
            this.shiftsAvailable.Multiline = true;
            this.shiftsAvailable.Name = "shiftsAvailable";
            this.shiftsAvailable.Size = new System.Drawing.Size(349, 35);
            this.shiftsAvailable.TabIndex = 15;
            // 
            // shiftsAvailableLabel
            // 
            this.shiftsAvailableLabel.AutoSize = true;
            this.shiftsAvailableLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.shiftsAvailableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shiftsAvailableLabel.Location = new System.Drawing.Point(24, 252);
            this.shiftsAvailableLabel.Name = "shiftsAvailableLabel";
            this.shiftsAvailableLabel.Size = new System.Drawing.Size(140, 24);
            this.shiftsAvailableLabel.TabIndex = 14;
            this.shiftsAvailableLabel.Text = "Shifts Available:";
            // 
            // absentButton
            // 
            this.absentButton.AutoSize = true;
            this.absentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.absentButton.Location = new System.Drawing.Point(85, 351);
            this.absentButton.Name = "absentButton";
            this.absentButton.Size = new System.Drawing.Size(94, 28);
            this.absentButton.TabIndex = 16;
            this.absentButton.Text = "Absent";
            this.absentButton.UseVisualStyleBackColor = true;
            this.absentButton.CheckedChanged += new System.EventHandler(this.absentButton_CheckedChanged);
            // 
            // disableButton
            // 
            this.disableButton.AutoSize = true;
            this.disableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disableButton.Location = new System.Drawing.Point(384, 351);
            this.disableButton.Name = "disableButton";
            this.disableButton.Size = new System.Drawing.Size(110, 28);
            this.disableButton.TabIndex = 17;
            this.disableButton.Text = "Disabled";
            this.disableButton.UseVisualStyleBackColor = true;
            this.disableButton.CheckedChanged += new System.EventHandler(this.disableButton_CheckedChanged);
            // 
            // EmployeeModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(596, 494);
            this.Controls.Add(this.disableButton);
            this.Controls.Add(this.absentButton);
            this.Controls.Add(this.shiftsAvailable);
            this.Controls.Add(this.shiftsAvailableLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.EmployeeTitle);
            this.Name = "EmployeeModal";
            this.Text = "Add/Edit Employee";
            this.Load += new System.EventHandler(this.EmployeeModal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EmployeeTitle;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox shiftsAvailable;
        private System.Windows.Forms.Label shiftsAvailableLabel;
        private System.Windows.Forms.CheckBox absentButton;
        private System.Windows.Forms.CheckBox disableButton;
    }
}