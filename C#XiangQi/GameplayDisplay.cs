using System;
using System.Collections.Generic;
using System.Text;

namespace XiangQi
{
    public class GameplayDisplay
    {
        public char[,] a = new char[19, 17];
        public int posx;
        public int posy;
        public int posx2;
        public int posy2;

        public void Change()
        {         

            string BoardLayout =
    "┏━┳━┳━┳━┳━┳━┳━┳━┓" +
    "┃ ┃ ┃ ┃╲┃╱┃ ┃ ┃ ┃" +
    "┣━╋━╋━╋━╋━╋━╋━╋━┫" +
    "┃ ┃ ┃ ┃╱┃╲┃ ┃ ┃ ┃" +
    "┣━╋━╋━╋━╋━╋━╋━╋━┫" +
    "┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃" +
    "┣━╋━╋━╋━╋━╋━╋━╋━┫" +
    "┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃" +
    "┣━┻━┻━┻━┻━┻━┻━┻━┫" +
    "┃               ┃" +
    "┣━┳━┳━┳━┳━┳━┳━┳━┫" +
    "┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃" +
    "┣━╋━╋━╋━╋━╋━╋━╋━┫" +
    "┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃ ┃" +
    "┣━╋━╋━╋━╋━╋━╋━╋━┫" +
    "┃ ┃ ┃ ┃╲┃╱┃ ┃ ┃ ┃" +
    "┣━╋━╋━╋━╋━╋━╋━╋━┫" +
    "┃ ┃ ┃ ┃╱┃╲┃ ┃ ┃ ┃" +
    "┗━┻━┻━┻━┻━┻━┻━┻━┛";

            for (int row = 0; row < 19; row++)//把字符串棋盘存入字符数组
            {
                for (int col = 0; col < 17; col++)
                {
                    a[row, col] = BoardLayout[col + row * 17];
                }
            }
        }
        public void DisplayBoard(Gameboard gamebord)
        {
            for (int row = 0; row < 19; row++)//打印棋盘
            {
                for (int col = 0; col < 17; col++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    if (col == 0)
                        if (row % 2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(row / 2 + " ");
                        }
                        else
                            Console.Write("  ");

                    if (gamebord.chess[row/2,col/2].side == 0 && row%2 == 0 && col%2 == 0 )
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(a[row, col]);
                    }
                    else if (gamebord.chess[row / 2, col / 2].side == 1 && row % 2 == 0 && col % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(a[row, col]);
                    }
                   else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(a[row, col]);
                    }
                }
                Console.Write(" \n");
            }
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("  a b c d e f g h i ");   
        }

        public void AskSelectPiece()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Which piece do you want to move?");

            string pos = Console.ReadLine();
            while (pos[0] > 'i' || pos[0] < 'a' || pos[1] > '9' || pos[1] < '0')
            {
                Console.WriteLine("This piece does not exist!");
                Console.WriteLine("Please enter again!");
                pos = Console.ReadLine();
            }

            if (pos[0] == 'a') posx = 0;
            if (pos[0] == 'b') posx = 2;
            if (pos[0] == 'c') posx = 4;
            if (pos[0] == 'd') posx = 6;
            if (pos[0] == 'e') posx = 8;
            if (pos[0] == 'f') posx = 10;
            if (pos[0] == 'g') posx = 12;
            if (pos[0] == 'h') posx = 14;
            if (pos[0] == 'i') posx = 16;

            if (pos[1] == '0') posy = 0;
            if (pos[1] == '1') posy = 2;
            if (pos[1] == '2') posy = 4;
            if (pos[1] == '3') posy = 6;
            if (pos[1] == '4') posy = 8;
            if (pos[1] == '5') posy = 10;
            if (pos[1] == '6') posy = 12;
            if (pos[1] == '7') posy = 14;
            if (pos[1] == '8') posy = 16;
            if (pos[1] == '9') posy = 18;
        }

        public void AskMovePiece()
        {
            Console.WriteLine("Please enter the position you want to move:");
            string pos = Console.ReadLine();

            while (pos[0] > 'i' || pos[0] < 'a' || pos[1] > '9' || pos[1] < '0')
            {
                Console.WriteLine("Your move is invalid!!");
                Console.WriteLine("Please enter again!");
                pos = Console.ReadLine();
            }
            if (pos[0] == 'a') posx2 = 0;
            if (pos[0] == 'b') posx2 = 2;
            if (pos[0] == 'c') posx2 = 4;
            if (pos[0] == 'd') posx2 = 6;
            if (pos[0] == 'e') posx2 = 8;
            if (pos[0] == 'f') posx2 = 10;
            if (pos[0] == 'g') posx2 = 12;
            if (pos[0] == 'h') posx2 = 14;
            if (pos[0] == 'i') posx2 = 16;

            if (pos[1] == '0') posy2 = 0;
            if (pos[1] == '1') posy2 = 2;
            if (pos[1] == '2') posy2 = 4;
            if (pos[1] == '3') posy2 = 6;
            if (pos[1] == '4') posy2 = 8;
            if (pos[1] == '5') posy2= 10;
            if (pos[1] == '6') posy2 = 12;
            if (pos[1] == '7') posy2 = 14;
            if (pos[1] == '8') posy2 = 16;
            if (pos[1] == '9') posy2 = 18;
        }

    }
}