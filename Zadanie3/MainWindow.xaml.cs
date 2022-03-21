using System;
using System.Windows;

namespace Zadanie3 {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Zaszyfruj_Click(object sender, RoutedEventArgs e) {
            Cipher.SetInput(MessageLabel.Text);
            Cipher.SetKey(KeyLabel1.Text);
            Cipher.EncryptData();

            EncryptedMessage.Text = Cipher.GetEncryptedResult();
        }

        private void Odszyfruj_Click(object sender, RoutedEventArgs e) {
            Cipher.SetInput(CipherLabel.Text);
            Cipher.SetKey(KeyLabel2.Text);
            Cipher.DecryptData();

            DecryptedMessage.Text = Cipher.GetDecryptedResult();
        }
    }

}