using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex05_Othelo
{
    class someForm : Form
    {
        private Button someButton = new Button();
        public someForm()
        {
            initializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initializeComponent();
        }

        private void initializeComponent()
        {
           
            
            someButton.Height = 10;
            someButton.Width = 10;
            someButton.Top = 30;
            someButton.Left = 30;
            someButton.Name = "someButton";
            someButton.Visible = true;

            this.Controls.AddRange(new Control[] { someButton });
        }
    }
}
