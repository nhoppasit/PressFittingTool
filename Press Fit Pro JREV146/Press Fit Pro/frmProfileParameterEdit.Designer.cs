namespace Press_Fit_Pro
{
    partial class frmProfileParameterEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHPar = new System.Windows.Forms.TextBox();
            this.txtFPar = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFAction = new System.Windows.Forms.TextBox();
            this.txtHAction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Height Parameter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Force Parameter:";
            // 
            // txtHPar
            // 
            this.txtHPar.Location = new System.Drawing.Point(135, 21);
            this.txtHPar.Name = "txtHPar";
            this.txtHPar.Size = new System.Drawing.Size(100, 20);
            this.txtHPar.TabIndex = 2;
            // 
            // txtFPar
            // 
            this.txtFPar.Location = new System.Drawing.Point(134, 47);
            this.txtFPar.Name = "txtFPar";
            this.txtFPar.Size = new System.Drawing.Size(100, 20);
            this.txtFPar.TabIndex = 3;
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(134, 73);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtSpeed.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Speed:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(224, 116);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 42);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(338, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 42);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFAction
            // 
            this.txtFAction.Location = new System.Drawing.Point(346, 47);
            this.txtFAction.Name = "txtFAction";
            this.txtFAction.Size = new System.Drawing.Size(100, 20);
            this.txtFAction.TabIndex = 11;
            // 
            // txtHAction
            // 
            this.txtHAction.Location = new System.Drawing.Point(347, 21);
            this.txtHAction.Name = "txtHAction";
            this.txtHAction.Size = new System.Drawing.Size(100, 20);
            this.txtHAction.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Force Action:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Height Action:";
            // 
            // frmProfileParameterEdit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(468, 174);
            this.Controls.Add(this.txtFAction);
            this.Controls.Add(this.txtHAction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFPar);
            this.Controls.Add(this.txtHPar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProfileParameterEdit";
            this.Text = "Profile parameter edit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProfileParameterEdit_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHPar;
        private System.Windows.Forms.TextBox txtFPar;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFAction;
        private System.Windows.Forms.TextBox txtHAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}