using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
            Music masterpiece = new Music("Music.txt");
            masterpiece.Play();
        }
    }
}
