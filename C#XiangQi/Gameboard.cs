using System;
using System.Collections.Generic;
using System.Text;

namespace XiangQi
{

    public partial class Gameboard
    {
        public GameboardPiece.Piece[,] chess = new GameboardPiece.Piece[10, 9];
        public int k = 0;
        int Gameover = 0;

        public void InitializeGameboard(GameplayDisplay b, Gameboard a)
         {           
            
            b.Change();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    chess[i, j] = new GameboardPiece.blank(3);
                }
            }
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

            b.a[0, 0] = chess[0, 0].ToChar();
            b.a[0, 2] = chess[0, 1].ToChar();
            b.a[0, 4] = chess[0, 2].ToChar();
            b.a[0, 6] = chess[0, 3].ToChar();
            b.a[0, 8] = chess[0, 4].ToChar();
            b.a[0, 10] = chess[0, 5].ToChar();
            b.a[0, 12] = chess[0, 6].ToChar();
            b.a[0, 14] = chess[0, 7].ToChar();
            b.a[0, 16] = chess[0, 8].ToChar();
            b.a[4, 2] = chess[2, 1].ToChar();
            b.a[4, 14] = chess[2, 7].ToChar();
            b.a[6, 0] = chess[3, 0].ToChar();
            b.a[6, 4] = chess[3, 2].ToChar();
            b.a[6, 8] = chess[3, 4].ToChar();
            b.a[6, 12] = chess[3, 6].ToChar();
            b.a[6, 16] = chess[3, 8].ToChar();

            b.a[18, 0] = chess[9, 0].ToChar();
            b.a[18, 2] = chess[9, 1].ToChar();
            b.a[18, 4] = chess[9, 2].ToChar();
            b.a[18, 6] = chess[9, 3].ToChar();
            b.a[18, 8] = chess[9, 4].ToChar();
            b.a[18, 10] = chess[9, 5].ToChar();
            b.a[18, 12] = chess[9, 6].ToChar();
            b.a[18, 14] = chess[9, 7].ToChar();
            b.a[18, 16] = chess[9, 8].ToChar();
            b.a[14, 2] = chess[7, 1].ToChar();
            b.a[14, 14] = chess[7, 7].ToChar();
            b.a[12, 0] = chess[6, 0].ToChar();
            b.a[12, 4] = chess[6, 2].ToChar();
            b.a[12, 8] = chess[6, 4].ToChar();
            b.a[12, 12] = chess[6, 6].ToChar();
            b.a[12, 16] = chess[6, 8].ToChar();
            b.DisplayBoard(a);
        }


        public void JudgeSide(GameplayDisplay b)
        {
            if (k%2 == 0)
            {
                while ((chess[(b.posy) / 2, (b.posx) / 2].side) == 1 || (chess[(b.posy) / 2, (b.posx) / 2].side) == 3) { 
                    Console.WriteLine("You select the wrong piece!");
                    Console.WriteLine("Please enter again!");
                    Console.Write("\n");
                    b.AskSelectPiece();
              }
            }
            if (k%2 == 1)
            {
                while ((chess[(b.posy) / 2, (b.posx) / 2].side) == 0 || (chess[(b.posy) / 2, (b.posx) / 2].side) == 3)
                {
                    Console.WriteLine("You select the wrong piece!");
                    Console.WriteLine("Please enter again!");
                    Console.Write("\n");
                    b.AskSelectPiece();
                }
            }
                k++;
        }
     
        public void MovePiece(int posx, int posy, int posx2, int posy2, GameplayDisplay b)
        {
            if (b.a[posy2, posx2] == 'G')
                Gameover = 1;

            b.a[posy2, posx2] = b.a[posy, posx];
            chess[posy2 / 2, posx2 / 2] = chess[posy / 2, posx / 2];
            chess[posy / 2, posx / 2] = new GameboardPiece.blank(3);

            if (posy == 0)
            {
                if (posx == 0) b.a[posy, posx] = '┏';
                else if (posx == 16) b.a[posy, posx] = '┓';
                else b.a[posy, posx] = '┳';
            }
            else if(posy == 18)
            {
                if (posx == 0) b.a[posy, posx] = '┗';
                else if (posx == 16) b.a[posy, posx] = '┛';
                else b.a[posy, posx] = '┻';
            }
            else if(posx == 0)
            {
                if (posy > 0 && posy < 18) b.a[posy, posx] = '┣';
            }
            else if (posx == 16)
            {
                if (posy > 0 && posy < 18) b.a[posy, posx] = '┫';
            }
            else if (posy == 8)
            {
                if (posx > 0 && posx < 16) b.a[posy, posx] = '┻';
            }
            else if (posy == 10)
            {
                if (posx > 0 && posx < 16) b.a[posy, posx] = '┳';
            }

            else  b.a[posy, posx] = '╋';
        }

        public void CalculateValidMoves(GameplayDisplay b)
        {
            while (!chess[b.posy / 2, b.posx / 2].ValidMoves(b.posx, b.posy, b.posx2, b.posy2, chess))
            {
                        Console.WriteLine("Your move is invalid!");
                        Console.WriteLine("Please enter again!");
                        Console.Write("\n");
                        b.AskMovePiece();
                if (b.posx == b.posx2 && b.posy == b.posy2)
                    NoPlaceToGo(b);
            }
        }
        public bool GameFinished(GameplayDisplay b)
        {
            if (Gameover == 1)
                return true;
            else
                return false;
        }
        public void NoPlaceToGo(GameplayDisplay b)
        {
            while (b.posx == b.posx2 && b.posy == b.posy2)
            {
                k--;
                Console.WriteLine("Select again!");
                b.AskSelectPiece();
                JudgeSide(b);
                b.AskMovePiece();
            }
        }
    }
}
