using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFence
{
    class RailFenceMachine
    {
        public int rails { get; set; }

        public RailFenceMachine(int _n)
        {
            rails = _n; // Ilość szyn
        }

        /*
         * Szyfrowanie
         */
        public string Encrypt(string textToCipher)
        {
            StringBuilder tab = new StringBuilder(); // Tablica do tworzenia tekstu po szyfrowaniu

            for (int i = 0; i < rails; i++)
            {
                for (int j = 0; j < Math.Ceiling((decimal)textToCipher.Length / rails); j++)
                {
                    if (i == 0)
                    {
                        int index;
                        index = (2 * (rails - 1) * j); // Powtarzalność sekwencji góra-dół = 2(n-1)
                        if (index < textToCipher.Length)    // Jeżeli index nie wychodzi poza granicę rozmiaru tablicy
                        {
                            tab.Append(textToCipher[index]);
                        }

                    }
                    else if (i == rails - 1)    // Jeżeli dojdziemy do dołu płotka
                    {
                        int index;
                        index = ( 2 * (rails - 1) * j) + rails - 1;
                        if (index < textToCipher.Length)
                        {
                            tab.Append(textToCipher[index]);
                        }
                    }
                    else
                    {
                        int top;

                        top = ((2 * (rails - 1)) * j);
                        int index;
                        index = top - i;
                        if (index > 0 && index < textToCipher.Length)
                        {
                            tab.Append(textToCipher[index]);
                        }
                        index = top + i;
                        if (index > 0 && index < textToCipher.Length)
                        {
                            tab.Append(textToCipher[index]);
                        }

                    }
                }
            }

            return tab.ToString();
        }

        /*
         * Deszyfrowanie
         */
        public string Decrypt(string textToDecipher)
        {
            char[] tmp = new char[textToDecipher.Length];
            int pom = 0;
            for (int i = 0; i < rails; i++)
            {
                for (int j = 0; j < Math.Ceiling((decimal)textToDecipher.Length / rails); j++)
                {
                    if (i == 0)
                    {
                        int index;
                        index = ((2 * (rails - 1)) * j);

                        if (index < textToDecipher.Length)
                        {
                            tmp[index] = textToDecipher[pom];
                            pom++;
                        }

                    }
                    else if (i == rails - 1)
                    {
                        int index;
                        index = ((2 * (rails - 1)) * j) + rails - 1;
                        if (index < textToDecipher.Length)
                        {
                            tmp[index] = textToDecipher[pom];
                            pom++;
                        }
                    }
                    else
                    {
                        int top;

                        top = ((2 * (rails - 1)) * j);
                        int index;
                        index = top - i;
                        if (index > 0 && index < textToDecipher.Length)
                        {
                            tmp[index] = textToDecipher[pom];
                            pom++;
                        }
                        index = top + i;
                        if (index > 0 && index < textToDecipher.Length)
                        {
                            tmp[index] = textToDecipher[pom];
                            pom++;
                        }

                    }
                }
            }

            return new string(tmp);
        }
    }
}
