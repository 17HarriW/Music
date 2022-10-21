using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class NoteOff : MidiEvent
    {
        Note Note;

        MidiOut MidiDevice;

        public NoteOff(Note n, MidiOut device)
        {
            Note = n;
            MidiDevice = device;

            buffer[0] = 0x80; // Always on channel 0
            buffer[1] = (byte)n.NoteNumber;
            buffer[2] = (byte)n.Volume;
        }

        public override void Send()
        {
            MidiDevice.SendBuffer(buffer);
        }
    }
}
