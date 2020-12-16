using System;

namespace XiangQi
{
    class Program
    {
        static void Main(string[] args)
        {
            GameplayDisplay b = new GameplayDisplay();
            Gameboard a = new Gameboard();
            b.Change();
            a.InitializeGameboard(b,a);

            while (true)
            {     
                b.AskSelectPiece();
                a.JudgeSide(b);
                b.AskMovePiece();
                a.NoPlaceToGo(b);
                a.CalculateValidMoves(b);
                a.MovePiece(b.posx, b.posy, b.posx2, b.posy2, b);            
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                b.DisplayBoard(a);
                if (a.GameFinished(b))
                {
                    Console.WriteLine("Game over");
                    break;
                }
            }
       }

    }
}
