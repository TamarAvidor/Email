using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public abstract class Message
    {
        public abstract int GetLegnth();

        public abstract byte[] Serialize();

        public abstract void Deserialize(byte[] data);

        public abstract void Normalize();
    }
}
