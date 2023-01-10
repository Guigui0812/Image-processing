using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP1Traitement_Image
{
    class Program
    {



        public static int Calcul(int[] tab)
        {
            int result = 0;

            for(int i = 0; i < tab.Length; i++)
            {
                result += tab[i];
            }

            return result;
        }


        static void Main(string[] args)
        {
            int[] tab = new int[12];
            for(int i=0; i < tab.Length; i++)
            {
                tab[i] = (i + 1) * (i + 1);
                Console.WriteLine("Valeur du carré n°" + (i + 1) + " est " + tab[i].ToString());             
            }

            int res = Calcul(tab);

            Console.WriteLine("Somme des entiers : " + res);
            Console.ReadKey();
           
            Console.ReadLine();
        }
    }
}
