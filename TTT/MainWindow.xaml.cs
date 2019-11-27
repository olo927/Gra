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

namespace TTT
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int SIZE = 9;
        Button[,] buttons = new Button[SIZE,SIZE];
        Label[] labels = new Label[SIZE];
        bool isXTurn = true;
        bool isLowGame = false;
        bool isHighGame = false;
        SolidColorBrush white, red;
        public MainWindow()
        {
            InitializeComponent();
            white = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            red = new SolidColorBrush(System.Windows.Media.Color.FromRgb(249, 182, 182));

        }

        private void twoPlayerStartButton_Click(object sender, RoutedEventArgs e)
        {
            isLowGame = false;
            isHighGame = false;
            SetButtonsTable();
            SetLabelTable();
            TwoPlayerGameMove();
            ResetBoard();
        } //done

        private void SetLabelTable()
        {
            labels[0] = l0;
            labels[1] = l1;
            labels[2] = l2;
            labels[3] = l3;
            labels[4] = l4;
            labels[5] = l5;
            labels[6] = l6;
            labels[7] = l7;
            labels[8] = l8;
        } //done

        private void SetButtonsTable()
        {
            buttons[0,0] = b00;
            buttons[0,1] = b01; 
            buttons[0,2] = b02;
            buttons[0,3] = b03;
            buttons[0,4] = b04;
            buttons[0,5] = b05;
            buttons[0,6] = b06;
            buttons[0,7] = b07;
            buttons[0,8] = b08;
            //
            buttons[1,0] = b10;
            buttons[1,1] = b11;
            buttons[1,2] = b12;
            buttons[1,3] = b13;
            buttons[1,4] = b14;
            buttons[1,5] = b15;
            buttons[1,6] = b16;
            buttons[1,7] = b17;
            buttons[1,8] = b18;
            //
            buttons[2,0] = b20;
            buttons[2,1] = b21;
            buttons[2,2] = b22;
            buttons[2,3] = b23;
            buttons[2,4] = b24;
            buttons[2,5] = b25;
            buttons[2,6] = b26;
            buttons[2,7] = b27;
            buttons[2,8] = b28;
            //
            buttons[3,0] = b30;
            buttons[3,1] = b31;
            buttons[3,2] = b32;
            buttons[3,3] = b33;
            buttons[3,4] = b34;
            buttons[3,5] = b35;
            buttons[3,6] = b36;
            buttons[3,7] = b37;
            buttons[3,8] = b38;
            //
            buttons[4,0] = b40;
            buttons[4,1] = b41;
            buttons[4,2] = b42;
            buttons[4,3] = b43;
            buttons[4,4] = b44;
            buttons[4,5] = b45;
            buttons[4,6] = b46;
            buttons[4,7] = b47;
            buttons[4,8] = b48;
            //
            buttons[5,0] = b50;
            buttons[5,1] = b51;
            buttons[5,2] = b52;
            buttons[5,3] = b53;
            buttons[5,4] = b54;
            buttons[5,5] = b55;
            buttons[5,6] = b56;
            buttons[5,7] = b57;
            buttons[5,8] = b58;
            //
            buttons[6,0] = b60;
            buttons[6,1] = b61;
            buttons[6,2] = b62;
            buttons[6,3] = b63;
            buttons[6,4] = b64;
            buttons[6,5] = b65;
            buttons[6,6] = b66;
            buttons[6,7] = b67;
            buttons[6,8] = b68;
            //
            buttons[7,0] = b70;
            buttons[7,1] = b71;
            buttons[7,2] = b72;
            buttons[7,3] = b73;
            buttons[7,4] = b74;
            buttons[7,5] = b75;
            buttons[7,6] = b76;
            buttons[7,7] = b77;
            buttons[7,8] = b78;
            //
            buttons[8,0] = b80;
            buttons[8,1] = b81;
            buttons[8,2] = b82;
            buttons[8,3] = b83;
            buttons[8,4] = b84;
            buttons[8,5] = b85;
            buttons[8,6] = b86;
            buttons[8,7] = b87;
            buttons[8,8] = b88;

        } //done

        private void TwoPlayerGameMove()
        {
            
            if (isXTurn)
            {
                WhichPlayerTurnLabel.Content = "Tura gracza X";
            }
            else
            {
                WhichPlayerTurnLabel.Content = "Tura gracza O";
            }
            LightButtons();

        }

        private void DarkButtons()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    buttons[i, j].Background = white;
                }
            }
        } //done

        private void LightButtons()
        {
            for(int i = 0; i<SIZE; i++)
            { 
                
                    for(int j = 0; j<SIZE;j++)
                    {
                        buttons[i,j].Background = red;
                    }
                
                
            }
        }  //Done

        private void SetSign_Click(object sender, RoutedEventArgs e)
        {
          
            int big, small;
            if(Int32.TryParse(Big.Text,out big) && Int32.TryParse(Small.Text, out small) && big>=1 && big<=9 && small >= 1 && small <= 9)
            {
                big--;
                small--;
                
                    try
                    {
                        if (buttons[big,small].Content.ToString()!="X" && buttons[big, small].Content.ToString() != "O")  
                        {
                            SetThisSign(big,small);
                            DarkButtons();
                            LightButtonsAfterTurn(small);
                            if (isLowGame)
                            {
                                small = OneLowPlayerGameMove();
                                DarkButtons();
                                LightButtonsAfterTurn(small);
                            }
                            if (isHighGame)
                            {
                                small = OneHighPlayerGameMove();
                                DarkButtons();
                                LightButtonsAfterTurn(small);
                            }


                    }
                        else
                        {
                            MessageBox.Show("To pole jest już zajęte.", "Błąd");
                        }
                    }catch (NullReferenceException)
                    {
                        MessageBox.Show("Gra nie została rozpoczęta");
                    }
                
            }
            else
            {
                MessageBox.Show("Możliwe, że wpsiałeś litere");
            }

        }
       
        private void LightButtonsAfterTurn(int small)
        {
            if (labels[small].Content.ToString() != "X" && labels[small].Content.ToString() != "O")
            {
                for(int i = 0; i<SIZE; i++)
                {
                    if(buttons[small, i].Content.ToString() != "X" && buttons[small, i].Content.ToString() != "O")
                    {
                        buttons[small, i].Background = red;
                    }
                }
            }
            else
            {
                for(int i =0; i<SIZE; i++)
                {
                    if (labels[i].Content.ToString() != "X" && labels[i].Content.ToString() != "O")
                    {
                        for (int j = 0; j < SIZE; j++)
                        {
                            if (buttons[i, j].Content.ToString() != "X" && buttons[i, j].Content.ToString() != "O")
                            {
                                buttons[i, j].Background = red;
                            }
                        }
                    }
                }
            }

        }

        private void ResetBoard()
        {
            for(int i = 0; i<SIZE; i++)
            {
                for(int j =0; j < SIZE; j++)
                {
                    buttons[i, j].Content = (j + 1).ToString();
                }
            }
            for(int i=0; i < SIZE; i++)
            {
                labels[i].Content = (i + 1).ToString();
            }
        } //done

        private void SetThisSign(int big, int small)
        {
            bool win = false;
            if(buttons[big, small].Background != red)
            {
                MessageBox.Show("Nie możesz tu postawić, postaw w polach zaznaczonych na czerwono");
                return;
            }
            buttons[big, small].Content = isXTurn ? "X" : "O";
            if (CheckIsSmallWin(big))
            {
                labels[big].Content = isXTurn ? "X" : "O";
                win = CheckIsBigWin();
            }

            if (win)
            {
                MessageBox.Show("Brawo gracz " + (isXTurn ? "X" : "O") + " wygrał tę rozgrywkę. Dla gracza " + (isXTurn ? "O" : "X") + " pozostał jedynie wstyd i hańba.", "WYGRANA");
            }

            isXTurn = !isXTurn;
            
        } //done 

        private bool CheckIsBigWin()
        {
            string sign = isXTurn ? "X" : "O";
            if ((labels[ 0].Content.ToString() == sign && labels[ 0].Content.ToString() == labels[ 1].Content.ToString() && labels[ 0].Content.ToString() == labels[ 2].Content.ToString()) ||
                labels[ 3].Content.ToString() == sign && labels[ 3].Content.ToString() == labels[ 4].Content.ToString() && labels[ 3].Content.ToString() == labels[ 5].Content.ToString() ||
                labels[ 6].Content.ToString() == sign && labels[ 6].Content.ToString() == labels[ 7].Content.ToString() && labels[ 6].Content.ToString() == labels[ 8].Content.ToString())
            { // Sprawdzanie lini poziomych
                return true;
            }
            if ((labels[ 0].Content.ToString() == sign && labels[ 0].Content.ToString() == labels[ 3].Content.ToString() && labels[ 0].Content.ToString() == labels[ 6].Content.ToString()) ||
               labels[ 1].Content.ToString() == sign && labels[ 1].Content.ToString() == labels[ 4].Content.ToString() && labels[ 1].Content.ToString() == labels[ 7].Content.ToString() ||
               labels[ 2].Content.ToString() == sign && labels[ 2].Content.ToString() == labels[ 5].Content.ToString() && labels[ 2].Content.ToString() == labels[ 8].Content.ToString())
            { // Sprawdzanie lini pionowych
                return true;
            }
            if ((labels[ 0].Content.ToString() == sign && labels[ 0].Content.ToString() == labels[ 4].Content.ToString() && labels[ 0].Content.ToString() == labels[ 8].Content.ToString()) ||
               labels[ 2].Content.ToString() == sign && labels[ 2].Content.ToString() == labels[ 4].Content.ToString() && labels[ 2].Content.ToString() == labels[ 6].Content.ToString())
            { // Sprawdzanie lini diagonalnych
                return true;
            }
            return false;
        } //done

        private void oneLowPlayerStartButton_Click(object sender, RoutedEventArgs e)
        {
            isLowGame = true;
            isHighGame = false;
            SetButtonsTable();
            SetLabelTable();
            ResetBoard();
            OneLowPlayerGameMove();
            
        }

        private int OneLowPlayerGameMove()
        {
            int[] si = { 0, 0 };
            if (isXTurn)
            {
                WhichPlayerTurnLabel.Content = "Tura gracza X";
            }
            else
            {
                WhichPlayerTurnLabel.Content = "Tura gracza O";
                si = LowLevelAI();
                SetThisSign(si[0], si[1]);

            }
            LightButtons();
            return si[1];
        }
        private int[] LowLevelAI()
        {
            int[] result = new int[2];
            Random random = new Random();
            do
            {
                result[0] = random.Next(0, 8);
                result[1] = random.Next(0,8);
            } while (buttons[result[0], result[1]].Background != red);

            return result;
        }
        private int[] HighLevelAI()
        {
            int[] result = new int[2];
            int small = -1;
            int big = -1;
            for(int i = 0; i < SIZE; i++)
            {
                if(labels[i].Content.ToString() == "O" || labels[i].Content.ToString() == "X")
                {
                    continue;
                }
                for(int j = 0; j< SIZE; j++)
                {
                    if(buttons[i,j].Background == red)
                    {
                        big = i;
                        small = j;
                        break;
                    }
                }
                if (big != -1)
                {
                    break;
                }
            }
            result[0] = big;
            //zliczanie wolnych miejsc
            int empty = 0;
            for(int i = 0; i<SIZE; i++)
            {
                if(buttons[big,i].Background == red)
                {
                    empty++;
                }
            }
            if(empty == 1)
            {
                result[1] = small;
                return result;
            }
            if(buttons[big,0].Background == red)
            {
                result[1] = 0;
                return result;
            }
            if(buttons[big, 0].Content.ToString() == "O")
            {
                if(buttons[big, 8].Background == red)
                {
                    result[1] = 8;
                }
                else
                {
                    if(buttons[big, 8].Content.ToString() == "O")
                    {
                        if (buttons[big, 4].Background == red)
                        {
                            result[1] = 4;
                        }
                        else
                        {
                            if (buttons[big, 2].Background == red)
                            {
                                result[1] = 2;
                            }
                            else
                            {
                                if (buttons[big, 2].Content.ToString() == "O")
                                {
                                    if (buttons[big, 1].Background == red)
                                    {
                                        result[1] = 1;
                                    }
                                    else
                                    {
                                        if (buttons[big, 5].Background == red)
                                        {
                                            result[1] = 5;
                                        }
                                        else
                                        {
                                            return LowLevelAI();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (buttons[big, 2].Background == red)
                {
                    result[1] = 2;
                }
                else
                {
                    if (buttons[big, 2].Content.ToString() == "O")
                    {
                        if (buttons[big, 1].Background == red)
                        {
                            result[1] = 1;
                        }
                        else
                        {
                            if (buttons[big, 5].Background == red)
                            {
                                result[1] = 5;
                            }
                            else
                            {
                                return LowLevelAI();
                            }
                        }
                    }
                }
            }



            return result;
        }

        private void oneHighPlayerStartButton_Click(object sender, RoutedEventArgs e)
        {
            isLowGame = false;
            isHighGame = true;
            SetButtonsTable();
            SetLabelTable();
            ResetBoard();
            OneHighPlayerGameMove();
        }

        private int OneHighPlayerGameMove()
        {
            int[] si = { 0, 0 };
            if (isXTurn)
            {
                WhichPlayerTurnLabel.Content = "Tura gracza X";
            }
            else
            {
                WhichPlayerTurnLabel.Content = "Tura gracza O";
                si = HighLevelAI();
                SetThisSign(si[0], si[1]);

            }
            LightButtons();
            return si[1];
        }

        private bool CheckIsSmallWin(int big)
        {
            string sign = isXTurn ? "X" : "O";
            if ((buttons[big, 0].Content.ToString() == sign && buttons[big, 0].Content.ToString() == buttons[big, 1].Content.ToString() && buttons[big, 0].Content.ToString() == buttons[big, 2].Content.ToString()) ||
                buttons[big, 3].Content.ToString() == sign && buttons[big, 3].Content.ToString() == buttons[big, 4].Content.ToString() && buttons[big, 3].Content.ToString() == buttons[big, 5].Content.ToString() ||
                buttons[big, 6].Content.ToString() == sign && buttons[big, 6].Content.ToString() == buttons[big, 7].Content.ToString() && buttons[big, 6].Content.ToString() == buttons[big, 8].Content.ToString())
            { // Sprawdzanie lini poziomych
                return true;
            }
            if ((buttons[big, 0].Content.ToString() == sign && buttons[big, 0].Content.ToString() == buttons[big, 3].Content.ToString() && buttons[big, 0].Content.ToString() == buttons[big, 6].Content.ToString()) ||
               buttons[big, 1].Content.ToString() == sign && buttons[big, 1].Content.ToString() == buttons[big, 4].Content.ToString() && buttons[big, 1].Content.ToString() == buttons[big, 7].Content.ToString() ||
               buttons[big, 2].Content.ToString() == sign && buttons[big, 2].Content.ToString() == buttons[big, 5].Content.ToString() && buttons[big, 2].Content.ToString() == buttons[big, 8].Content.ToString())
            { // Sprawdzanie lini pionowych
                return true;
            }
            if ((buttons[big, 0].Content.ToString() == sign && buttons[big, 0].Content.ToString() == buttons[big, 4].Content.ToString() && buttons[big, 0].Content.ToString() == buttons[big, 8].Content.ToString()) ||
               buttons[big, 2].Content.ToString() == sign && buttons[big, 2].Content.ToString() == buttons[big, 4].Content.ToString() && buttons[big, 2].Content.ToString() == buttons[big, 6].Content.ToString())
            { // Sprawdzanie lini diagonalnych
                return true;
            }
            return false;
        } //done
    }
}
