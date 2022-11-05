using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3b
{
    public class CeasarCipher
    {
        private int cipherCode;

        public int CipherCode
        {
            get => this.cipherCode;
            set
            {
                if (value % 26 != 0) this.cipherCode = value;
                else throw new ArgumentOutOfRangeException("Azbukata ti e greshna");
            }
        }

        public CeasarCipher()
        {
            this.CipherCode = 3;
        }

        public CeasarCipher(int cipherCode)
        {
            this.CipherCode = cipherCode;
        }

        public string EncryptText(string plainText)
        {
            char[] plainTextChars = plainText.ToCharArray();
            char[] cipherTextChars = new char[plainTextChars.Length];

            for (int i = 0; i < plainTextChars.Length; i++)
            {
                cipherTextChars[i] = (char)(((plainTextChars[i] - 'A' + this.CipherCode + 26) % 26) + 'A');
            }

            return new string(cipherTextChars);
        }
        
        public string DecryptText(string cipherText)
        {
            char[] plainTextChars = cipherText.ToCharArray();
            char[] cipherTextChars = new char[plainTextChars.Length];

            for (int i = 0; i < plainTextChars.Length; i++)
            {
                plainTextChars[i] = (char)(((cipherTextChars[i] - 'A' - this.CipherCode + 26) % 26) + 'A');
             }

            return new string(plainTextChars);
        }
    }
}
