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
    public class GameboardPiece
    {
        public abstract class Piece
        {
            public int side;
            public Piece(int side)
            {
                this.side = side;
            }
            public abstract String ToString();
            public abstract String ToStringSelect();
            public virtual String ToString2()
            {
                return " ";
            }
            public abstract bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess);

        }
        public class blank : Piece
        {
            public blank(int side)
                : base(side)
            {

            }
            public override String ToString()
            {
                return "D:\\Visual studio 项目\\WpfApp1\\Resource\\blank.png";
            }
            public override String ToStringSelect()
            {
                return "D:\\Visual studio 项目\\WpfApp1\\Resource\\select.png";
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
            public override String ToString()
            {
                if(side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedGeneral.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackGeneral.png";
                }
                else
                    return null;
            }
            public override String ToStringSelect()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedGeneral1.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackGeneral1.png";
                }
                else
                    return null;
            }
            public override String ToString2()
            {
                return "General";
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                int i, j, k;
                if (chess[posy2, posx2].ToString2() == "General" && posx2 == posx)
                {
                    i = posx < posx2 ? posx : posx2;//起始点纵坐标
                    j = posx > posx2 ? posx : posx2;//终点纵坐标
                    for (k = i + 1; k <= j - 1; k = k + 1)
                    {
                        if (chess[k, posx2].side != 3)//中间有棋子
                        {
                            return false;
                        }
                    }
                    return true;
                }
               else if (System.Math.Abs(posx - posx2) == 1 && System.Math.Abs(posy - posy2) == 0 || System.Math.Abs(posx - posx2) == 0 && System.Math.Abs(posy - posy2) == 1)
                {  //合法移动时
                    if (chess[posy2, posx2].side == chess[posy, posx].side)   //不能吃同方棋子
                        return false;
                    else if (posy2 > 2 && posy2 < 7 || posx2 < 3 || posx2 > 5)  //不能走出九宫格
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
            public override String ToString()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedAdvisor.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackAdvisor.png";
                }
                else
                    return null;
            }
            public override String ToStringSelect()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedAdvisor1.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackAdvisor1.png";
                }
                else
                    return null;
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (System.Math.Abs(posx - posx2) == 1 && System.Math.Abs(posy - posy2) == 1)
                {
                    if (chess[posy2, posx2].side == chess[posy, posx].side)
                        return false;
                    else if (posy2 > 2 && posy2 < 7 || posx2 < 3 || posx2 > 5)
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
            public override String ToString()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedCannon.png";
                }
                if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackCannon.png";
                }
                else
                    return null;
            }
            public override String ToStringSelect()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedCannon1.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackCannon1.png";
                }
                else
                    return null;
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                int p = 0;
                int i, j, k;
                if (posx2 == posx)//同时移动情况，竖着走
                {
                    i = posy < posy2 ? posy : posy2;//起始点纵坐标
                    j = posy > posy2 ? posy : posy2;//终点纵坐标
                    for (k = i + 1; k <= j - 1; k=k+1)
                    {
                        if (chess[k, posx2].side != 3)//中间有棋子
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
                    for (k = i + 1; k <= j-1; k=k+1)
                    {
                        if (chess[posy2, k].side != 3)//中间有棋子
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
                if (p == 0 && chess[posy2, posx2].side != 3)//中间没有棋子且目标点有棋子
                    return false;
                if (p == 1 && chess[posy2, posx2].side == 3)//中间有棋子且目标点无棋子
                    return false;
                if (chess[posy2, posx2].side == chess[posy, posx].side)  //目的点是同一方的棋子
                    return false;
                return true;
            }
        }
        public class Rook : Piece  //车
        {
            public Rook(int side)
                : base(side)
            {

            }
            public override String ToString()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedRook.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackRook.png";
                }
                else
                    return null;
            }
            public override String ToStringSelect()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedRook1.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackRook1.png";
                }
                else
                    return null;
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                int i, j, k;
                if (posx == posx2 && posy != posy2)  //车竖移
                {
                    if (chess[posy2, posx2].side == chess[posy, posx].side)
                        return false;

                    i = posy < posy2 ? posy : posy2;//起始点纵坐标
                    j = posy > posy2 ? posy : posy2;//终点纵坐标
                    for (k = i+1 ; k<= j-1 ; k++)
                    {
                        if (chess[k, posx].side != 3)
                            return false;
                    }
                }
                else if (posy == posy2 && posx != posx2)  //车横移
                {
                    if (chess[posy2, posx2].side == chess[posy, posx].side)
                        return false;

                    i = posx < posx2 ? posx : posx2;//起始点横坐标
                    j = posx > posx2 ? posx : posx2;//终点横坐标
                    for (k = i + 1; k <= j - 1; k++)
                    {
                        if (chess[posy, k].side != 3)
                            return false;
                    }
                }
                else
                    return false;

                return true;
            }
        }

        public class Elephant : Piece
        {
            public Elephant(int side)
                : base(side)
            {

            }
            public override String ToString()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedElephant.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackElephant.png";
                }
                else
                    return null;
            }
            public override String ToStringSelect()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedElephant1.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackElephant1.png";
                }
                else
                    return null;
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (System.Math.Abs(posx - posx2) == 2 && System.Math.Abs(posy - posy2) == 2)
                {
                    if (chess[posy2, posx2].side == chess[posy, posx].side)
                        return false;
                    else if (chess[(posy + posy2) / 2, (posx + posx2) / 2].side == 0 || chess[(posy + posy2) / 2, (posx + posx2) / 2].side == 1)
                        return false;    //对角线中间有棋子，卡象脚

                    else if (chess[posy , posx ].side == 0)  //红方象
                    {
                        if (posy2 > 4)
                            return false;
                        else
                            return true;
                    }
                    else if (chess[posy , posx ].side == 1)  //黑方象
                    {
                        if (posy2 < 5)
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
            public override String ToString()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedHorse.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackHorse.png";
                }
                else
                    return null;
            }
            public override String ToStringSelect()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedHorse1.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackHorse1.png";
                }
                else
                    return null;
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (chess[posy2 , posx2 ].side == chess[posy , posx ].side)
                    return false;
                if (System.Math.Abs(posx - posx2) == 1 && System.Math.Abs(posy - posy2) == 2)
                {
                    if (chess[(posy + posy2) / 2, posx].side != 3)
                    {
                        return false;
                    }
                }
                else if (System.Math.Abs(posx - posx2) == 2 && System.Math.Abs(posy - posy2) == 1)
                {
                    if (chess[posy , (posx + posx2) / 2].side != 3)
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
            public override String ToString()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedSoldier.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackSoldier.png";
                }
                else
                    return null;
            }
            public override String ToStringSelect()
            {
                if (side == 0)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\RedSoldier1.png";
                }
                else if (side == 1)
                {
                    return "D:\\Visual studio 项目\\WpfApp1\\Resource\\BlackSoldier1.png";
                }
                else
                    return null;
            }
            public override bool ValidMoves(int posx, int posy, int posx2, int posy2, GameboardPiece.Piece[,] chess)
            {
                if (chess[posy2, posx2].side == chess[posy, posx].side)
                    return false;
                 if (chess[posy,posx].side == 1) //黑方兵
                {
                    if (posy2 > 4) //过河前
                    {
                        if (System.Math.Abs(posx2 - posx) > 0)  //不能横着走
                            return false;
                    }
                    if ( posy2 - posy > 0)  //不能往回走
                        return false;
                    if (System.Math.Abs(posx - posx2) > 1 || System.Math.Abs(posy - posy2) > 1)  //只能走一格
                        return false;
                    if (System.Math.Abs(posx - posx2) > 0 && System.Math.Abs(posy - posy2) > 0)  //不能斜着走
                        return false;

                    return true;
                }
                 else  //红方兵
                {
                    if (posy2 < 5)  //过河前
                    {
                        if (System.Math.Abs(posx2 - posx) > 0)  //不能横着走
                            return false;
                    }
                    if ( posy - posy2 > 0)  //不能往回走
                        return false;
                    if (System.Math.Abs(posx - posx2) > 1 || System.Math.Abs(posy - posy2) > 1)  //只能走一格
                        return false;
                    if (System.Math.Abs(posx - posx2) > 0 && System.Math.Abs(posy - posy2) > 0)  //不能斜着走
                        return false;

                    return true;
                }
            }

        }
    }
}

