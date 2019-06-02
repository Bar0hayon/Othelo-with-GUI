namespace Ex05_Othelo
{
    public partial class StartForm
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
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonPlayVsComputer = new System.Windows.Forms.Button();
            this.buttonPlayVsFriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonBoardSize.Location = new System.Drawing.Point(89, 43);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(392, 47);
            this.buttonBoardSize.TabIndex = 0;
            this.buttonBoardSize.Text = "Board Size: 6x6 (click to increase)";
            this.buttonBoardSize.UseVisualStyleBackColor = true;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonPlayVsComputer
            // 
            this.buttonPlayVsComputer.Location = new System.Drawing.Point(89, 119);
            this.buttonPlayVsComputer.Name = "buttonPlayVsComputer";
            this.buttonPlayVsComputer.Size = new System.Drawing.Size(193, 59);
            this.buttonPlayVsComputer.TabIndex = 1;
            this.buttonPlayVsComputer.Text = "Play against the computer";
            this.buttonPlayVsComputer.UseVisualStyleBackColor = true;
            this.buttonPlayVsComputer.Click += new System.EventHandler(this.buttonPlayVsComputer_Click);
            // 
            // buttonPlayVsFriend
            // 
            this.buttonPlayVsFriend.Location = new System.Drawing.Point(288, 119);
            this.buttonPlayVsFriend.Name = "buttonPlayVsFriend";
            this.buttonPlayVsFriend.Size = new System.Drawing.Size(193, 59);
            this.buttonPlayVsFriend.TabIndex = 2;
            this.buttonPlayVsFriend.Text = "Play against your friend";
            this.buttonPlayVsFriend.UseVisualStyleBackColor = true;
            this.buttonPlayVsFriend.Click += new System.EventHandler(this.buttonPlayVsFriend_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 226);
            this.Controls.Add(this.buttonPlayVsFriend);
            this.Controls.Add(this.buttonPlayVsComputer);
            this.Controls.Add(this.buttonBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button buttonPlayVsComputer;
        private System.Windows.Forms.Button buttonPlayVsFriend;
    }
}