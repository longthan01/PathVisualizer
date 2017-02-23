namespace PathVisualizer
{
    partial class Main
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
            this.button1 = new System.Windows.Forms.Button();
            this.chkClickConnect = new System.Windows.Forms.CheckBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(548, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create node";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // chkClickConnect
            // 
            this.chkClickConnect.AutoSize = true;
            this.chkClickConnect.Location = new System.Drawing.Point(520, 70);
            this.chkClickConnect.Name = "chkClickConnect";
            this.chkClickConnect.Size = new System.Drawing.Size(103, 17);
            this.chkClickConnect.TabIndex = 1;
            this.chkClickConnect.Text = "Click to connect";
            this.chkClickConnect.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(548, 41);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 23);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.Text = "Undo last";
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 261);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.chkClickConnect);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkClickConnect;
        private System.Windows.Forms.Button btnUndo;
    }
}