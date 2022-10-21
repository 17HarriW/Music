using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class NoteOn : MidiEvent
    {
        Note Note;
        MidiOut device;

        public NoteOn(Note n, MidiOut device)
        {
            Note = n;
            this.device = device;
            buffer[0] = 0x90; // Always on channel 0
            buffer[1] = (byte)n.NoteNumber;
            buffer[2] = (byte)n.Volume;
        }

        public override void Send()
        {
            device.SendBuffer(buffer);
        }
    }
}
