using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
  
    public partial class Gameboard
    {
        public GameboardPiece.Piece[,] chess = new GameboardPiece.Piece[10, 9];
        int k = 0;
        public int posx;
        public int posy;
        public int posx2;
        public int posy2;
        public int GameState=0;
        public bool SucessMove;
        public bool SucessSelect;
        int Gameover = 0;

        public void InitializeGameboard()
         {                      
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    chess[i, j] = new GameboardPiece.blank(3);
                }
            }
             //红方
            chess[0, 0] = new GameboardPiece.Rook(0);
            chess[0, 1] = new GameboardPiece.Horse(0);
            chess[0, 2] = new GameboardPiece.Elephant(0);
            chess[0, 3] = new GameboardPiece.Advisor(0);
            chess[0, 4] = new GameboardPiece.General(0);
            chess[0, 5] = new GameboardPiece.Advisor(0);
            chess[0, 6] = new GameboardPiece.Elephant(0);
            chess[0, 7] = new GameboardPiece.Horse(0);
            chess[0, 8] = new GameboardPiece.Rook(0);
            chess[2, 1] = new GameboardPiece.Cannon(0);
            chess[2, 7] = new GameboardPiece.Cannon(0);
            chess[3, 0] = new GameboardPiece.Soldier(0);
            chess[3, 2] = new GameboardPiece.Soldier(0);
            chess[3, 4] = new GameboardPiece.Soldier(0);
            chess[3, 6] = new GameboardPiece.Soldier(0);
            chess[3, 8] = new GameboardPiece.Soldier(0);
             //黑方
            chess[9, 0] = new GameboardPiece.Rook(1);
            chess[9, 1] = new GameboardPiece.Horse(1);
            chess[9, 2] = new GameboardPiece.Elephant(1);
            chess[9, 3] = new GameboardPiece.Advisor(1);
            chess[9, 4] = new GameboardPiece.General(1);
            chess[9, 5] = new GameboardPiece.Advisor(1);
            chess[9, 6] = new GameboardPiece.Elephant(1);
            chess[9, 7] = new GameboardPiece.Horse(1);
            chess[9, 8] = new GameboardPiece.Rook(1);
            chess[7, 1] = new GameboardPiece.Cannon(1);
            chess[7, 7] = new GameboardPiece.Cannon(1);
            chess[6, 0] = new GameboardPiece.Soldier(1);
            chess[6, 2] = new GameboardPiece.Soldier(1);
            chess[6, 4] = new GameboardPiece.Soldier(1);
            chess[6, 6] = new GameboardPiece.Soldier(1);
            chess[6, 8] = new GameboardPiece.Soldier(1);
        }
        //判定哪方走
        public void JudgeSize(int row,int column)
        {          
            if (k % 2 == 0) //当红方走
            {
                if (chess[row, column].side == 1 )
                {
                    MessageBox.Show("Please select a red piece!");
                    SucessSelect = false;
                }
                else if (chess[row, column].side == 3)
                {
                    SucessSelect = false;
                }
                else
                {
                    posy = row;
                    posx = column;
                    GameState = 1;
                    k++;
                    SucessSelect = true;
                }
            }
            else //当黑方走
            {
                if (chess[row, column].side == 0)
                {
                    MessageBox.Show("Please select a black piece!");
                    SucessSelect = false;
                }
                else if (chess[row, column].side == 3)
                {
                    SucessSelect = false;
                }
                else
                {
                    posy = row;
                    posx = column;
                    GameState = 1;
                    k++;
                    SucessSelect = true;
                }
            }
        }
        public void MovePiece(int row, int column)
        {
            posy2 = row;
            posx2 = column;

            if (chess[posy, posx].ValidMoves(posx,posy,posx2,posy2,chess))  //合法移动
            {
                    if (chess[posy2, posx2].ToString2() == "General")  //判断被吃的是不是帅
                    Gameover = 1;

                    chess[posy2, posx2] = chess[posy, posx];
                    chess[posy, posx] = new GameboardPiece.blank(3);
                    GameState = 0;
                    SucessMove = true;
            }
            else if (chess[posy, posx] == chess[posy2, posx2])  //取消移动（再点击一次）
            {
                GameState = 0;
                SucessMove = true;
                k--;
            }
            else if (chess[posy, posx].side == chess[posy2, posx2].side)
            {

            }
            else  //不合法移动
            {
                SucessMove = false;
            }
        }
        public void IfGameover()
        {
            if (Gameover == 1)
             MessageBox.Show("Game over!");
        }
    }
}
