using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Luffarschack_WPF
{
    public class SpelFunktioner
    {

        public bool PlayerX { get; set; } = true;
        public string PlayerNow { get; set; }

        private string[,] Board = new string[3, 3];




        public void ChangePlayer()
        {

            // Ändrar spelare: från X till O , O till X
            if (PlayerX == true)
            {
                PlayerNow = "X";
                PlayerX = false;
            }
            else
            {
                PlayerNow = "O";
                PlayerX = true;
            }

        }

        public bool PlayerWin()
        {


            //Horisontell Check
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(Board[i, 0]))
                {
                    if(Board[i,0] == Board[i,1] && Board[i, 0] == Board[i, 2])
                    {
                        return true;
                    }
                }
            }

            //Vertikal Check
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(Board[0, i]))
                {
                    if (Board[0, i] == Board[1, i] && Board[0, i] == Board[2, i])
                    {
                        return true;
                    }
                }
            }

            // Diagonal Check
            if (!string.IsNullOrEmpty(Board[0, 0]))
            {
                    if (Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2])
                    {
                        return true;
                    }
            }
           

            return false;
        }


        internal void UpdateBoard(Position position, string value)
        {
            Board[position.x, position.y] = value;
        }

    }

}
