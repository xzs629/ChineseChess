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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid grid = new Grid();
        Gameboard board = new Gameboard();
        int k = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
       void creatgrid()
        {
            ImageBrush bg = new ImageBrush();
            bg.ImageSource = new BitmapImage(new Uri("D:\\Visual studio 项目\\WpfApp1\\Resource\\bg.png", UriKind.RelativeOrAbsolute));
            Background = bg;
            for (int col = 0; col < 9; col++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(colDef);
            }
            for (int row = 0; row < 10; row++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(rowDef);
            }
            Redraw();
        }
        void Redraw()
        {
            grid.Children.Clear();
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Image img = new Image();
                    img.MouseDown += new MouseButtonEventHandler(Image_MouseDown);

                    //画棋子
                    img.Source = new BitmapImage(new Uri(board.chess[row,col].ToString(), UriKind.RelativeOrAbsolute));

                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);
                    grid.Children.Add(img);
                }
            }
        }
        void Redraw1() //选棋后的刷新
        {
            grid.Children.Clear();
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Image img = new Image();
                    img.MouseDown += new MouseButtonEventHandler(Image_MouseDown);

                    if (board.chess[board.posy, board.posx].ValidMoves(board.posx, board.posy, col, row, board.chess))  //显示可走的地方
                        img.Source = new BitmapImage(new Uri(board.chess[row, col].ToStringSelect(), UriKind.RelativeOrAbsolute));
                    else if (row == board.posy && col == board.posx)  //变成选中形态的棋子
                        img.Source = new BitmapImage(new Uri(board.chess[row, col].ToStringSelect(), UriKind.RelativeOrAbsolute));
                    else  //画棋子
                        img.Source = new BitmapImage(new Uri(board.chess[row, col].ToString(), UriKind.RelativeOrAbsolute));

                    Grid.SetRow(img, row);
                    Grid.SetColumn(img, col);
                    grid.Children.Add(img);
                }
            }           
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {          
            Image img = (Image)sender;
            int row = Grid.GetRow(img);
            int column = Grid.GetColumn(img);
         
            if (board.GameState == 0) //选棋子
            {
                board.JudgeSize(row, column);
                if (board.SucessSelect)
                {
                    Redraw1();
                }
            }
            else //移动棋子
            {
                board.MovePiece(row, column);
                if (board.SucessMove)
                {
                    Redraw();
                    board.IfGameover();
                }
            }
        }
        private void Button_Start(object sender, RoutedEventArgs e)
        {
            board.InitializeGameboard();
            creatgrid();
            this.Content = grid;
        }
    }
}
