using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Music
{
    class Music
    {
        List<Notation> Notes = new List<Notation>();
        public void Play()
        {
            MidiOut player = new MidiOut(0);
            Console.WriteLine("Using " + MidiOut.DeviceInfo(0).ProductName);
            

            Console.WriteLine("Playing...");
            foreach (Notation n in Notes)
            {
                n.MidiDevice = player;
                n.Play();
                if (n.GetType().Name == "Note")
                {
                    Note note = (Note)n;
                    Console.WriteLine(n);
                    //Console.WriteLine($"Playing note {note.NoteNumber} for {n.Duration} beats");
                } else
                {
                    Console.WriteLine(n);
                    //Console.WriteLine($"Resting for {n.Duration} beats");
                }
            }
        }

        public int NoteToNumber(char noteName, bool flat, bool sharp, int octave)
        {
            int noteNumber = 0;
            switch(noteName)
            {
                case 'C':
                    noteNumber = 0;
                    break;
                case 'D':
                    noteNumber = 2;
                    break;
                case 'E':
                    noteNumber = 4;
                    break;
                case 'F':
                    noteNumber = 5;
                    break;
                case 'G':
                    noteNumber = 7;
                    break;
                case 'A':
                    noteNumber = 9;
                    break;
                case 'V':
                    noteNumber = 11;
                    break;
            }

            // Decrease if flat
            if (flat)
            {
                noteNumber--;
            }

            // Increase if sharp
            if (sharp)
            {
                noteNumber++;
            }

            return noteNumber + (octave * 12);
        }

        public Music(string Filename)
        {
            Console.WriteLine($"Loading file from {Filename}");
            // Load from the file
            string fileContents = File.ReadAllText(Filename);

            // Remove the comments
            fileContents = Regex.Replace(fileContents, @"\/\/.*","");

            // Extract the notes
            int octave = 4;
            foreach(Match m in Regex.Matches(fileContents, @"([A-G])?([b#])?(\d)*(:(\d))?"))
            {
                // Get the note name
                string note = m.Groups[1].Value;

                // Decide if it's a note or rest
                if(note.Length > 0)
                {
                    // Get the octave
                    if (m.Groups[3].Value.Length > 0)
                    {
                        octave = int.Parse(m.Groups[3].Value);
                    }

                    // Get flat or sharp
                    bool flat = m.Groups[2].Value == "b";
                    bool sharp = m.Groups[2].Value == "#";

                    Note n = new Note();

                    n.NoteNumber = NoteToNumber(note[0], flat, sharp, octave);
                    n.Duration = 1;
                    if (m.Groups[5].Value.Length > 0)
                    {
                        n.Duration = int.Parse(m.Groups[5].Value);
                    }

                    Notes.Add(n);
                } else
                {
                    // Rest
                    Rest r = new Rest();
                    r.Duration = 1;

                    if (m.Groups[5].Value.Length > 0)
                    {
                        r.Duration = int.Parse(m.Groups[5].Value);
                        Notes.Add(r);
                    }
                }

                //Console.WriteLine($"Note: {note} | Octave: {octave} | Number: {n.NoteNumber} | Duration: {n.Duration}");
            }
            Console.WriteLine(fileContents);
        }
    }
}
