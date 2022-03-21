using System;
using System.Windows;

namespace Zadanie3 {

    public class Cipher {
        public static void SetInput(string value) {
            _Input = value;
        }

        public static void SetKey(string value) {
            _Key = value;
        }


        public static void EncryptData() {
            _Encrypted = "";

            if (!String.IsNullOrEmpty(_Input) && !String.IsNullOrEmpty(_Key)) {
                var data = _Input.Replace(" ", "");

                int[] arr = new int[_Key.Length];
                int last_value = 0;

                for (char i = 'A'; i < 'Z'; i++) {
                    for (int j = 0; j < _Key.Length; j++) {
                        if (_Key[j] == i) {
                            arr[j] = last_value++;
                        }
                    }
                }

                for (int i = 0; i < arr.Length; i++) {
                    int offset = Array.IndexOf(arr, i);

                    for (int j = 0, k = (_Key.Length * j) + offset; k < data.Length; j++, k = (_Key.Length * j) + offset) {
                        _Encrypted += data[k];
                    }

                    _Encrypted += ' ';
                }

                _Encrypted = _Encrypted.Trim();
            }
        }

        public static void DecryptData() {
            _Decrypted = "";

            if (!String.IsNullOrEmpty(_Input) && !String.IsNullOrEmpty(_Key)) {
                var data = _Input.Split(' ');
                var length = _Input.Replace(" ", "").Length;

                int[] arr = new int[_Key.Length];
                int last_value = 0, it = 0;

                for (char i = 'A'; i < 'Z'; i++) {
                    for (int j = 0; j < _Key.Length; j++) {
                        if (_Key[j] == i) {
                            arr[j] = last_value++;
                        }
                    }
                }

                while (_Decrypted.Length < length) {
                    for (int i = 0; i < _Key.Length; i++) {
                        var index = arr[i];

                        if (data.Length > index && data[index].Length > it) {
                            _Decrypted += data[index][it];
                        }
                    }

                    it++;
                }
            }
        }


        public static string GetEncryptedResult() {
            return _Encrypted;
        }

        public static string GetDecryptedResult() {
            return _Decrypted;
        }


        // Input
        private static string _Input;
        private static string _Key;

        // Output
        private static string _Encrypted;
        private static string _Decrypted;
    }

}