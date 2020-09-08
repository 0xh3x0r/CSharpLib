using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2
{


    // ༼ つ ◕_◕ ༽つ this class creates a custom generated number base, it calculates everything according  to length determined by 'Karakterler' (which can be dynamic) array 
    public class Sayitabani
    {

        // (ﾉ◕ヮ◕)ﾉ  Every index indicates value of the ascii character in this number base    ヽ(◕ヮ◕ヽ)
        public static char[] Karakterler = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F','G','H','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b'
        ,'c','d','e','f','g','h','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};


        // (づ｡◕‿‿◕｡)づ This function gets the number value of the given character in the array 
        private static int KarakterDegeri(char ifade)
        {


            for (int i = 0; i < Karakterler.Length; i++)
            {
                if (Karakterler[i] == ifade) return i;

            }

            return -1;

        }

        // Because Math.Pow is too mainstream  ¯\_(ツ)_/¯
        private static decimal üs(int x, int y)
        {
            int sonuc = 1;
            for (int i = 0; i < y; i++)
            {
                sonuc *= x;
            }

            return sonuc;
        }


        // Convert the string into 10base if 0-9 are the first 9 character in the array it can convert 10base in to 10base which makes no sense  ლ(´ڡ`ლ)

        public static decimal Donustur(string param) 
        {
            int tabanboyutu = Karakterler.Length;
            decimal ret = 0;
            int strlen = param.Length - 1;
            if (param.Length <= 17) // decimal.maxValue is 17 digit in my base so anything > 17 is an error. 
            {
                for (int i = 0; i <= strlen; i++)
                {
                    ret += KarakterDegeri(param[(strlen - i)]) * üs(tabanboyutu, i); // -> param[2](reverse) den okumaya başla iterum'un üssü ile iteruma karşılık gelen Karakter'in sayisal degerini çarp


                }
            }
            return ret;

        }

        // Convert 10th base into custom base (｡◕‿◕｡)
        public static string Donustur(decimal param) 
        {
            int tabanboyutu = Karakterler.Length;
            string ret = "";
            decimal sayi = param;
            int kalan = -1;
            Stack<char> stack4reversing = new Stack<char>();
            while (sayi >= 1) // not x > 0 bcs need2ignore floating point
            {
                kalan = (int)(sayi % tabanboyutu);
                sayi /= tabanboyutu;
                stack4reversing.Push(Karakterler[kalan]); // this is for not using string funcs and for lowering processor weight, output is reverse


            }
            while (stack4reversing.Count > 0)
                ret += stack4reversing.Pop();



            return ret;
        }








    } 

    }