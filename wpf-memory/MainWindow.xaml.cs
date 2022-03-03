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

namespace wpf_memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int clickNumber = 0;
        public Button? firstClick;
        public Button? secondClick;

        public MainWindow()
        {
            InitializeComponent();

            var rand = new Random();

            Dictionary<string, int> memo = new Dictionary<string, int>() { { "A", 0 }, { "B", 0 }, { "C", 0 }, { "D", 0 }, { "E", 0 }, { "F", 0 } };
            foreach (Button btn in MemoGrid.Children)
            {
                int numerek;
                do
                {
                    numerek = rand.Next(0, memo.Count);
                } while (memo.ElementAt(numerek).Value == 2);
                btn.Tag = memo.ElementAt(numerek).Key;
                //btn.Content = memo.ElementAt(numerek).Key;
                memo[memo.ElementAt(numerek).Key]++;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            btn.Content = btn.Tag;

            /*if(firstClick != null && secondClick != null && (firstClick.Tag==btn.Tag || secondClick.Tag == btn.Tag))
            {
                return;
            }*/

            if (clickNumber == 2)
            {
                if (firstClick.Tag == secondClick.Tag)
                {
                    firstClick.Visibility = Visibility.Hidden;
                    secondClick.Visibility = Visibility.Hidden;
                }
                else
                {
                    firstClick.Content = "";
                    secondClick.Content = "";
                }
                firstClick = null;
                secondClick = null;
                clickNumber = 0;
            }

            if (firstClick == null)
            {
                firstClick = btn;
            }
            else
            {
                secondClick = btn;
            }

            clickNumber++;
        }
    }
}
