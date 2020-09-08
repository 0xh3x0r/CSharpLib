using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace XOREncryption
{
    public static class Cryptor
    {

        // Make sure your magic numbers are below < 255 otherwise it might overflow 2 bytes space.
        public static int magicNumber = 30;
        public static int magicNumber2 = 30;


        // Crypts char value into 2 byte array
        public static  byte[] Crypt(char value)
        {


            byte[] data2crypt = new byte[2];

            int i_encryption = ((value ^ magicNumber) + magicNumber2);

            int total_no_of_bytes = 0;

            while (i_encryption > 0)
            {
                total_no_of_bytes++;
                byte i_byte = (byte)(i_encryption & 255);
                data2crypt[2 - total_no_of_bytes] = i_byte;
                i_encryption >>= 8; // rsh 8 bit               
            }

            return data2crypt;
        }



        // This function requires 2x length of destination block because encrypted data might overflow 1 byte according to magic numbers!, so make sure you are allocated enough memory
        public static bool Insert(byte[] destblock,byte[] srcblock, int StartIndex)
        {
            int n = StartIndex; // second iterator
            if (destblock.Length >= srcblock.Length * 2)
            {
                for (int i = 0; i < srcblock.Length; i++)
                {

                    byte[] data2crypt = new byte[2];

                    int i_encryption = ((srcblock[i] ^ magicNumber) + magicNumber2);

                    int total_no_of_bytes = 0;

                    while (i_encryption > 0)
                    {
                        total_no_of_bytes++;
                        byte i_byte = (byte)(i_encryption & 255);
                        data2crypt[2 - total_no_of_bytes] = i_byte;
                        i_encryption >>= 8; // rsh 8 bit               
                    }

                    destblock[n] = data2crypt[0];
                    destblock[n + 1] = data2crypt[1];
                    n += 2;

                }
                return true;
            }
            else
                return false;

        }


        // Decrypts 2 byte value into a short in given index.
        public static short Decrypt(byte[] encryption, int StartIndex)
        {


            short decrypted = 0;
            if (encryption[StartIndex] != 0)
            {
                decrypted = (short)(encryption[StartIndex + 0] << 8);
                decrypted |= (short)encryption[StartIndex + 1];
            }
            else
            {
                decrypted = encryption[StartIndex + 1];
            }
            decrypted = (short)(decrypted - magicNumber2 ^ magicNumber);


            return decrypted;
        }



    }

}