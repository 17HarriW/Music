using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music
{
    class Note : Notation
    {
        // Number of note
        public int NoteNumber;

        // Volume note is played
        public int Volume = 127;

        public MidiOut MidiDevice;

        public override string ToString()
        {
            return $"Note {NoteNumber} at volume {Volume} for {Duration} beats";
        }

        public override void Play()
        {
            NoteOn on = new NoteOn(this, MidiDevice);
            on.Send();
            Thread.Sleep(100 * Duration);

            NoteOff off = new NoteOff(this, MidiDevice);
            off.Send();
        }
    }
}
