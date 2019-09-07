using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeySignatures
{
    class KeySignature
    {
        public KeySignature(string name, string majorKey, string minorKey)
        {
            Name = name;
            MajorKey = majorKey;
            MinorKey = minorKey;
        }

        public string Name { get; }
        public string MajorKey { get; }
        public string MinorKey { get; }
    }
}
