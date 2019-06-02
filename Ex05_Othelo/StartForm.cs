using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05_Othelo
{
    public partial class StartForm : Form
    {
        private int m_BoardSize = 6;
        private const int k_MaxBoardSize = 12;
        private const int k_MinBoardSize = 6;
        private bool v_IsVsComputer;
        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }
        public bool IsVsComputer
        {
            get
            {
                return v_IsVsComputer;
            }
        }

        public StartForm()
        {
            InitializeComponent();
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            if(m_BoardSize == k_MaxBoardSize)
            {
                m_BoardSize = k_MinBoardSize;
            }
            else
            {
                m_BoardSize += 2;
            }

            buttonBoardSize.Text = string.Format("Board Size: {0}x{0} (click to increase)",
                m_BoardSize);
        }

        private void buttonPlayVsComputer_Click(object sender, EventArgs e)
        {
            v_IsVsComputer = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonPlayVsFriend_Click(object sender, EventArgs e)
        {
            v_IsVsComputer = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
