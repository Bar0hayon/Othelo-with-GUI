using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex05_Othelo
{
    public class GameManager
    {
        private StartForm m_StartForm;
        private GameBoardForm m_GameBoardForm;
        private int m_BlackWinsCount = 0;
        private int m_WhiteWinsCount = 0;

        public void StartGame()
        {
            m_StartForm = new StartForm();
            m_StartForm.ShowDialog();
            if (m_StartForm.DialogResult == DialogResult.OK)
            {
                runGame();
            }
        }

        private void runGame()
        {
            string messageString;
            do
            {
                m_GameBoardForm = new GameBoardForm(m_StartForm.BoardSize, m_StartForm.IsVsComputer);
                m_GameBoardForm.ShowDialog();
                messageString = getMessageString();
        }
            while (m_GameBoardForm.DialogResult == DialogResult.OK &&
            MessageBox.Show(messageString, "Othelo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK);
        }

        private string getMessageString()
        {
            StringBuilder messageStringBuilder = new StringBuilder();
            if(m_GameBoardForm.Winner == eCell.Black)
            {
                m_BlackWinsCount++;
                messageStringBuilder.Append(string.Format(
                                            "Black Won!! ({0}/{1}) ({2}/{3})", 
                                            m_GameBoardForm.BlackPoints,
                                            m_GameBoardForm.WhitePoints,
                                            m_BlackWinsCount,
                                            m_WhiteWinsCount));
            }
            else if(m_GameBoardForm.Winner == eCell.White)
            {
                m_WhiteWinsCount++;
                messageStringBuilder.Append(string.Format(
                                            "White Won!! ({0}/{1}) ({2}/{3})",
                                            m_GameBoardForm.WhitePoints, 
                                            m_GameBoardForm.BlackPoints, 
                                            m_WhiteWinsCount,
                                            m_BlackWinsCount ));
            }
            else
            {
                messageStringBuilder.Append(string.Format(
                                                   "Tie!! ({0}/{0}) ({1}/{2})",
                                                   m_GameBoardForm.WhitePoints, 
                                                   m_WhiteWinsCount, 
                                                   m_BlackWinsCount));
            }

            messageStringBuilder.Append("\nWould you like another round?");
            return messageStringBuilder.ToString();
        }
    }
}
