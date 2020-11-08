namespace WebWinform
{
    partial class InputForm
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
            this.Txt_CarNo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Pnl_Input = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Txt_CarNo
            // 
            this.Txt_CarNo.Location = new System.Drawing.Point(401, 88);
            this.Txt_CarNo.Name = "Txt_CarNo";
            this.Txt_CarNo.Size = new System.Drawing.Size(233, 21);
            this.Txt_CarNo.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(401, 206);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 21);
            this.textBox1.TabIndex = 1;
            // 
            // Pnl_Input
            // 
            this.Pnl_Input.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pnl_Input.Location = new System.Drawing.Point(0, 345);
            this.Pnl_Input.Name = "Pnl_Input";
            this.Pnl_Input.Size = new System.Drawing.Size(1284, 316);
            this.Pnl_Input.TabIndex = 2;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.Pnl_Input);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Txt_CarNo);
            this.Name = "InputForm";
            this.Text = "InputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_CarNo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel Pnl_Input;
    }
}