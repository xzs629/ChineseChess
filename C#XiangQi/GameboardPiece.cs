using System;
using System.Collections.Generic;
using System.Text;

namespace XiangQi
{
    public class GameboardPiece
    {
        public abstract class Piece
        {
            public int side;
            public Piece(int side)
            {
                this.side = side;
            }
            public abstract char ToChar();

            public abstract bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess);

        }

        public class blank : Piece
        {
            public blank(int side)
                : base(side)
            {

            }

            public override char ToChar()
            {
                return ' ';
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                return true;
            }
        }

        public class General : Piece
        {
            public General(int side)
                : base(side)
            {

            }
            public override char ToChar()
            {
                return 'G';
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (System.Math.Abs(posx - posx2) == 2 && System.Math.Abs(posy - posy2) == 0 || System.Math.Abs(posx - posx2) == 0 && System.Math.Abs(posy - posy2) == 2)
                {
                    if (chess[posy2 / 2, posx2 / 2].side == chess[posy / 2, posx / 2].side)
                        return false;
                    else if (posy2 > 4 && posy2 < 14 || posx2 < 6 || posx2 > 10)
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
        }

        public class Advisor : Piece
        {
            public Advisor(int side)
                : base(side)
            {

            }
            public override char ToChar()
            {
                return 'A';
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (System.Math.Abs(posx - posx2) == 2 && System.Math.Abs(posy - posy2) == 2)
                {
                    if (chess[posy2 / 2, posx2 / 2].side == chess[posy / 2, posx / 2].side)
                        return false;
                    else if (posy2 > 4 && posy2 < 14 || posx2 < 6 || posx2 > 10)
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
        }
        public class Cannon : Piece //炮
        {
            public Cannon(int side)
                : base(side)
            {

            }
            public override char ToChar()
            {
                return 'C';
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                int p = 0;
                int i, j, k;
                if (posx2 == posx)//同时移动情况，竖着走
                {
                    i = posy < posy2 ? posy : posy2;//起始点纵坐标
                    j = posy > posy2 ? posy : posy2;//终点纵坐标
                    for (k = i + 2; k < j; k=k+2)
                    {
                        if (chess[k/2, posx2/2].side != 3)//中间有棋子
                        {
                            p++;
                        }
                    }
                    if (p > 1)
                    {
                        return false;
                    }
                }
                else if (posy2 == posy)//同行移动情况，横着走
                {
                    i = posx < posx2 ? posx : posx2;//起始点横坐标
                    j = posx > posx2 ? posx : posx2;//终点横坐标
                    for (k = i + 2; k < j; k=k+2)
                    {
                        if (chess[posy2/2, k/2].side != 3)//中间有棋子
                        {
                            p++;
                        }
                    }
                    if (p > 1)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                if (p == 0 && chess[posy2/2, posx2/2].side != 3)//中间没有棋子且目标点有棋子
                {
                    return false;
                }
                if (p == 1 && chess[posy2/2, posx2/2].side == 3)//中间有棋子且目标点无棋子
                {
                    return false;
                }
                return true;
            }
        }

        public class Rook : Piece  //车
        {
            public Rook(int side)
                : base(side)
            {

            }
            public override char ToChar()
            {
                return 'R';
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (posx == posx2 && posy != posy2)  //车竖移
                {
                    if (chess[posy2 / 2, posx2 / 2].side == chess[posy / 2, posx / 2].side)
                        return false;
                    for (int i = (posy / 2) + 1; i <= (posy2 / 2) - 1; i++)
                    {
                        if (chess[i, posx / 2].side != 3)
                            return false;
                    }
                }
                if (posy == posy2 && posx != posx2)  //车横移
                {
                    if (chess[posy2 / 2, posx2 / 2].side == chess[posy / 2, posx / 2].side)
                        return false;
                    for (int i = (posx / 2) + 1; i <= (posx2 / 2) - 1; i++)
                    {
                        if (chess[posy / 2, i].side != 3)
                            return false;
                    }
                }
                return true;
            }
        }

        public class Elephant : Piece
        {
            public Elephant(int side)
                : base(side)
            {

            }
            public override char ToChar()
            {
                return 'E';
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (System.Math.Abs(posx - posx2) == 4 && System.Math.Abs(posy - posy2) == 4)
                {
                    if (chess[posy2 / 2, posx2 / 2].side == chess[posy / 2, posx / 2].side)
                        return false;
                    else if (chess[(posy + posy2) / 4, (posx + posx2) / 4].side == 0 || chess[(posy + posy2) / 4, (posx + posx2) / 4].side == 1)
                        return false;    //对角线中间有棋子，卡象脚

                    else if (chess[posy / 2, posx / 2].side == 0)  //红方象
                    {
                        if (posy2 > 8)
                            return false;
                        else
                            return true;
                    }
                    else if (chess[posy / 2, posx / 2].side == 1)  //黑方象
                    {
                        if (posy2 < 10)
                            return false;
                        else
                            return true;
                    }
                    else
                        return true;
                }
                else
                    return false;
            }
        }

        public class Horse : Piece
        {
            public Horse(int side)
                : base(side)
            {

            }
            public override char ToChar()
            {
                return 'H';
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (chess[posy2 / 2, posx2 / 2].side == chess[posy / 2, posx / 2].side)
                    return false;
                if (System.Math.Abs(posx - posx2) == 2 && System.Math.Abs(posy - posy2) == 4)
                {
                    if (chess[(posy + posy2) / 4, posx / 2].side != 3)
                    {
                        return false;
                    }
                }
                else if (System.Math.Abs(posx - posx2) == 4 && System.Math.Abs(posy - posy2) == 2)
                {
                    if (chess[posy / 2, (posx + posx2) / 4].side != 3)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
        }     
        public class Soldier : Piece
        {
            public Soldier(int side)
                : base(side)
            {

            }
            public override char ToChar()
            {
                return 'S';
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (chess[posy2 / 2, posx2 / 2].side == chess[posy / 2, posx / 2].side)
                    return false;
                else if (chess[posy,posx].side == 1)
                {
                    if (posy2 > 10)
                    {
                        if (posy == posy2 && System.Math.Abs(posx2 - posx) > 0)
                        {
                            return false;
                        }
                    }
                    if (posx == posx2 && posy2 - posy > 1)
                    {
                        return false;
                    }
                    if (System.Math.Abs(posx - posx2) > 2 || System.Math.Abs(posy - posy2) > 2)
                    {
                        return false;
                    }
                }
                else
                {
                    if (posy2 < 8)
                    {
                        if (posy == posy2 && System.Math.Abs(posx2 - posx) > 0)
                        {
                            return false;
                        }
                    }
                    if (posx == posx2 && posy - posy2 > 1)
                    {
                        return false;
                    }
                    if (System.Math.Abs(posx - posx2) > 2 || System.Math.Abs(posy - posy2) > 2)
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}

