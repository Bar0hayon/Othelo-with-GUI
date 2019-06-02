using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ex05_Othelo
{
    public partial class GameBoardForm : Form
    {
        private const int k_CellSize = 50;
        private Button[,] m_BoardButtons;
        private int m_BoardSize;
        private eCell m_TurnOf = eCell.White;
        private bool v_IsVsComputer;
        private GameBoardEngine m_GameBoardEngine;
        private eCell m_Winner;
        private int m_WhitePoints;
        private int m_BlackPoints;

        public int WhitePoints
        {
            get
            {
                return m_WhitePoints;
            }
        }

        public int BlackPoints
        {
            get
            {
                return m_BlackPoints;
            }
        }

        public eCell Winner
        {
            get
            {
                return m_Winner;
            }
        }

        public GameBoardForm(int i_BoardSize, bool i_IsVsComputer)
        {
            m_BoardSize = i_BoardSize;
            v_IsVsComputer = i_IsVsComputer;
            m_GameBoardEngine = new GameBoardEngine(i_BoardSize);
            m_GameBoardEngine.SetLegalMoves(m_TurnOf);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size((k_CellSize * m_BoardSize) + 20, (k_CellSize * m_BoardSize) + 20);
            this.Name = "GameBoardForm";
            this.Text = string.Format("Othelo - {0}'s turn", m_TurnOf.ToString());
            this.StartPosition = FormStartPosition.CenterScreen;
            m_BoardButtons = new Button[m_BoardSize, m_BoardSize];
            for(int i = 0; i < m_BoardSize; i++)
            {
                for(int j = 0; j < m_BoardSize; j++)
                {
                    m_BoardButtons[i, j] = new Button();
                    setButtonProperties(i, j);
                    this.Controls.Add(m_BoardButtons[i, j]);
                    m_BoardButtons[i, j].Click += CellButton_Click;
                }
            }
        }

        private void CellButton_Click(object sender, EventArgs e)
        {
            Point userMove = getUserMovePoint((Button)sender);
            m_GameBoardEngine.MakeUserMove(userMove, m_TurnOf);
            toggleTurnAndContinue();
        }

        private void toggleTurnAndContinue()
        {
            toggleTurn();
            this.Text = string.Format("Othelo - {0}'s turn", m_TurnOf.ToString());
            m_GameBoardEngine.SetLegalMoves(m_TurnOf);
            if(m_GameBoardEngine.isLegalMoveExists())
            {
                continueGame();
            }
            else
            {
                toggleTurn();
                if(m_GameBoardEngine.isLegalMoveExists())
                {
                    continueGame();
                }
                else
                {
                    endGame();
                }
            }
        }

        private void endGame()
        {
            m_BlackPoints = getPointsByColor(eCell.Black);
            m_WhitePoints = getPointsByColor(eCell.White);
            m_Winner = setWinner();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private eCell setWinner()
        {
            eCell winner;
            if(m_WhitePoints > m_BlackPoints)
            {
                winner = eCell.White;
            }
            else if(m_BlackPoints > m_WhitePoints)
            {
                winner = eCell.Black;
            }
            else
            {
                winner = eCell.Empty;
            }
        
            return winner;
        }

        private int getPointsByColor(eCell i_Color)
        {
            int pointsCount = 0;
            foreach(eCell cell in m_GameBoardEngine.Board)
            {
                if(cell == i_Color)
                {
                    pointsCount++;
                }
            }

            return pointsCount;
        }

        private void continueGame()
        {
            if (m_TurnOf == eCell.White || !v_IsVsComputer)
            {
                setAllButtons();
            }
            else
            {
                Point PcMove = m_GameBoardEngine.GetPcMove(m_TurnOf);
                m_GameBoardEngine.MakeUserMove(PcMove, m_TurnOf);
                toggleTurnAndContinue();
            }
        }

        private void setAllButtons()
        {
            for (int i = 0; i < m_BoardSize; i++) 
            {
                for (int j = 0; j < m_BoardSize; j++) 
                {
                    setButtonProperties(i, j);
                }
            }
        }

        private void toggleTurn()
        {
            if (m_TurnOf == eCell.Black)
            {
                m_TurnOf = eCell.White;
            }
            else
            {
                m_TurnOf = eCell.Black;
            }
        }

        private Point getUserMovePoint(Button sender)
        {
            char xAsChar = sender.Name.ToCharArray()[10];
            int x = (int)(xAsChar - '0');
            char yAsChar = sender.Name.ToCharArray()[12];
            int y = (int)(yAsChar - '0');
            return new Point(x, y);
        }

        private void setButtonProperties(int i_x, int i_y)
        {
            m_BoardButtons[i_x, i_y].Width = k_CellSize;
            m_BoardButtons[i_x, i_y].Height = m_BoardButtons[i_x, i_y].Width;
            m_BoardButtons[i_x, i_y].Top = 10 + (i_x * m_BoardButtons[i_x, i_y].Height);
            m_BoardButtons[i_x, i_y].Left = 10 + (i_y * m_BoardButtons[i_x, i_y].Width);
            m_BoardButtons[i_x, i_y].Name = string.Format("buttonCell{0},{1}", i_x, i_y);
            m_BoardButtons[i_x, i_y].Enabled = m_GameBoardEngine.Board[i_x, i_y] == eCell.LegalMove;
            m_BoardButtons[i_x, i_y].BackgroundImage = getBackGroundImage(i_x, i_y);
            m_BoardButtons[i_x, i_y].BackgroundImageLayout = ImageLayout.Stretch;
        }

        private Image getBackGroundImage(int i_x, int i_y)
        {
            Image backGroundImage;
            string path = string.Format("{0}\\..\\..\\", System.IO.Directory.GetCurrentDirectory());
            switch (m_GameBoardEngine.Board[i_x, i_y])
            {
                case eCell.Black:
                    backGroundImage = Image.FromFile(path + "CoinRed.png");
                    break;
                case eCell.White:
                    backGroundImage = Image.FromFile(path + "CoinYellow.png");
                    break;
                case eCell.LegalMove:
                    backGroundImage = Image.FromFile(path + "refreshGreen.png");
                    break;
                default:
                    backGroundImage = null;
                    break;
            }

            return backGroundImage;
        }
    }
}
