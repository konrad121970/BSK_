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

namespace RailFence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // RailFence rail = new RailFence();
        public string inputData;
        public int n;
        public string outputData;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Szyfruj_Button_Click(object sender, RoutedEventArgs e)
        {
            if(toCipher.Text.Length == 0 || nTextBox.Text.Length == 0)
            {
                cipheredText.Text = "Podaj właściwe dane";

                return;
            }

            inputData = toCipher.Text;
            n = int.Parse(nTextBox.Text);

            RailFenceMachine rail = new RailFenceMachine(n);

            outputData = rail.Encrypt(inputData);
            cipheredText.Text = outputData;
        }

        private void Odszyfruj_Button_Click(object sender, RoutedEventArgs e)
        {
            if (toDecipher.Text.Length == 0 || nTextBox.Text.Length == 0)
            {
                decipheredText.Text = "Podaj właściwe dane";

                return;
            }

            inputData = toDecipher.Text;
            n = int.Parse(nTextBox2.Text);

            RailFenceMachine rail = new RailFenceMachine(n);

            outputData = rail.Decrypt(inputData);
            decipheredText.Text = outputData;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void toDecipherText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
