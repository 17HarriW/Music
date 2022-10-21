using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    abstract class MidiEvent
    {
        // Bytes that are sent as MIDI data
        protected byte[] buffer = new byte[3];

        // 16 Channels to select from. Channel 9 is percussion
        protected int Channel;

        /// <summary>
        /// Sends MIDI data
        /// </summary>
        public void Send()
        {
            Console.WriteLine("Implement this");
        }
    }
}
