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

namespace Luffarschack_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SpelFunktioner _spel = new SpelFunktioner();

        public MainWindow()
        {
            InitializeComponent();
           
        }


        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            foreach(var btn in GridButtons.Children)
            {
                if(btn is Button)
                {
                    ((Button)btn).Content = null;
                }
            }


            WinScreen.Visibility = Visibility.Collapsed;
            _spel = new SpelFunktioner();

        }

        private void SpaceClick(object sender, RoutedEventArgs e)
        {


            var _button = (Button)sender;
            

            if (_button.HasContent == true)
            {
                return;
            }


            var coord = _button.Tag.ToString().Split(',');
            var xValue = int.Parse(coord[0]);
            var yValue = int.Parse(coord[1]);
            var buttonPos = new Position() { x = xValue, y = yValue };
            _spel.UpdateBoard(buttonPos, _spel.PlayerNow);


     
            if (_spel.PlayerWin())
            {
                    WinScreen.Text = $"{_spel.PlayerNow.ToUpper()} WINS!";
                    WinScreen.Visibility = Visibility.Visible;
            }



            _button.Content = _spel.PlayerNow;
            _spel.ChangePlayer();



    


        }
    }
}
