using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class MidiEvent
    {
        // Bytes that are sent as MIDI data
        private byte[] buffer = new byte[3];

        // 16 Channels to select from. Channel 9 is percussion
        private int Channel;

        /// <summary>
        /// Sends MIDI data
        /// </summary>
        public void Send()
        {
            Console.WriteLine("Implement sending MIDI data");
        }
    }
}
