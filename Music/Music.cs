using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Music
    {
        List<Note> Notes = new List<Note>();
        public void Play()
        {
            Console.WriteLine("Playing...");
            foreach (Note n in Notes)
            {
                n.Play();
            }
        }

        public Music(string Filename)
        {
            Console.WriteLine($"Loading file from {Filename}");
            foreach(string line in File.ReadAllLines(Filename))
            {
                Console.WriteLine(line);
            }

        }
    }
}
