using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    abstract class Notation
    {
        // Note number
        public int Duration;

        public MidiOut MidiDevice;

        /// <summary>
        /// Plays note
        /// </summary>
        public abstract void Play();

        public override string ToString()
        {
            return $"Unknown music notation for {Duration} beats";
        }
    }
}
