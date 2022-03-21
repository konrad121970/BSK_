using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM.Core;
using WpfMVVM.MVVM.Model;

namespace WpfMVVM.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand SzyfrujCommand { get; set; }
        public RelayCommand OdszyfrujCommand { get; set; }
        public MainViewModel()
        {
            Algorytm2 alg = new Algorytm2();

            SzyfrujCommand = new RelayCommand(o =>
            {
                Zawartosc = alg.Encrypt(TextBoxValue);
            });
            OdszyfrujCommand = new RelayCommand(o => 
            {
                Zawartosc2 = alg.Decrypt(TextBoxValue2);
            });

        }

        public string Zawartosc
        {
            get { return _zawartosc; }
            set
            {
                _zawartosc = value;
                OnPropertyChanged();
            }
        }
        private string _zawartosc;

        public string TextBoxValue
        {
            get { return _textBoxValue; }
            set
            {
                _textBoxValue = value;
                OnPropertyChanged();
            }
        }
        private string _textBoxValue;



        public string Zawartosc2
        {
            get { return _zawartosc2; }
            set
            {
                _zawartosc2 = value;
                OnPropertyChanged();
            }
        }
        private string _zawartosc2;

        public string TextBoxValue2
        {
            get { return _textBoxValue2; }
            set
            {
                _textBoxValue2 = value;
                OnPropertyChanged();
            }
        }
        private string _textBoxValue2;
    }
}
