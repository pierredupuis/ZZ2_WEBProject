using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace game_of_thrones
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] h = { "LOL", "I", "AM", "A", "GENIUS" };
            Tmanager t = new Tmanager();
            t.PrintHouses(h);
            Console.ReadLine();
        }
    }
}
