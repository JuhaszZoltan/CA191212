using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CA191212
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            //Osztok(0);

            Console.WriteLine($"N = 1 -> {NJegyuEgyesPrim(1)}");
            Console.WriteLine($"N = 2 -> {NJegyuEgyesPrim(2)}");
            Console.WriteLine($"N = 3 -> {NJegyuEgyesPrim(3)}");
            Console.WriteLine($"N = 4 -> {NJegyuEgyesPrim(4)}");
            Console.WriteLine($"N = 5 -> {NJegyuEgyesPrim(5)}");


            //Teglalap(78, 23, "látjátok szemeim szümtükhel mik vogymuk");

            for (int i = 0; i < 10; i++)
            {
                Teglalap(rnd.Next(Console.WindowWidth), rnd.Next(Console.WindowHeight), "X");
            }

            Console.ReadKey();
        }

        static void Teglalap(int sz, int m, string szoveg)
        {
            int sk = Console.WindowWidth / 2;
            int mk = Console.WindowHeight / 2;
            
            //felső él
            for (int i = 0; i < sz; i++)
            {
                Console.SetCursorPosition(sk - (sz / 2) + i, mk - (m / 2));
                VeletlenSzin();
                Console.Write('*');
                System.Threading.Thread.Sleep(10);
            }
            //jobb él
            for (int i = 0; i < m; i++)
            {
                Console.SetCursorPosition(sk + (sz / 2), mk - (m / 2) + i);
                VeletlenSzin();
                Console.Write('*');
                System.Threading.Thread.Sleep(10);
            }
            //alsó él
            for (int i = 0; i < sz; i++)
            {
                Console.SetCursorPosition(sk + (sz / 2) - i, mk + (m / 2));
                VeletlenSzin();
                Console.Write('*');
                System.Threading.Thread.Sleep(10);
            }
            //bal ál
            for (int i = 0; i < m; i++)
            {
                Console.SetCursorPosition(sk - (sz / 2), mk + (m / 2) - i);
                VeletlenSzin();
                Console.Write('*');
                System.Threading.Thread.Sleep(10);
            }
            Console.SetCursorPosition(sk - szoveg.Length / 2, mk);
            Console.WriteLine(szoveg);
        }
        static void VeletlenSzin()
        {
            Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 16);
        }

        static int[] Osztok(int szam)
        {
            if (szam == 0) throw new Exception("a nullának végtelen osztója van");

            int[] osztok = new int[100];

            int db = 0;
            for (int i = 1; i <= szam/2; i++)
            {
                if(szam % i == 0)
                {
                    osztok[db] = i;
                    db++;
                }
            }
            osztok[db] = szam;

            Array.Resize(ref osztok, db + 1);
            return osztok;
        }
        static int DbOszto(int szam)
        {
            return Osztok(szam).Length;
        }

        static bool PrimE(int szam)
        {
            return Osztok(szam).Length == 2;
        }

        static int NJegyuEgyesPrim(int n)
        {
            if (n == 1) return -1;

            for (int i = (int)Math.Pow(10, n - 1) + 1; i < (int)Math.Pow(10, n); i += 10)
            {
                if (PrimE(i)) return i;
            }

            return -1;
        }

    }
}
