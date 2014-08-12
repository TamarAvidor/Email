using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class NewMailMessage : Message
    {
        public NewMailMessage()
        {
        }

        public string SenderName { get; set; }

        public DateTime Time { get; set; }

        public string DestinationList { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public override byte[] Serialize()
        {
            var length = GetLegnth();
            Encoding encoding = Encoding.ASCII;

            List<byte> bytes = new List<byte>();

            byte[] senderNameBytes = new byte[10 * sizeof(char)];
            var snamebytes = encoding.GetBytes(SenderName);
            Array.Copy(snamebytes, senderNameBytes, snamebytes.Length);

            byte[] timeBytes = BitConverter.GetBytes(Time.ToBinary());

            byte[] destinationBytes = new byte[109 * sizeof(char)];
            var dbytes = encoding.GetBytes(DestinationList);
            Array.Copy(dbytes, destinationBytes, dbytes.Length);


            byte[] subjectBytes = new byte[78 * sizeof(char)];
            var sbytes = encoding.GetBytes(Subject);
            Array.Copy(sbytes, subjectBytes, sbytes.Length);

            byte[] bodyBytes = new byte[512 * sizeof(char)];
            var bbytes = encoding.GetBytes(Body);
            Array.Copy(bbytes, bodyBytes, bbytes.Length);

            bytes.AddRange(BitConverter.GetBytes(length));
            bytes.AddRange(senderNameBytes);
            bytes.AddRange(timeBytes);
            bytes.AddRange(destinationBytes);
            bytes.AddRange(subjectBytes);
            bytes.AddRange(bodyBytes);

            return bytes.ToArray();
        }

        public override void Deserialize(byte[] data)
        {
            Encoding encoding = Encoding.ASCII;

            SenderName = encoding.GetString(data.Take(10 * sizeof(char)).ToArray()).Replace("\0", String.Empty);
            Time = DateTime.FromBinary(BitConverter.ToInt64(data.Skip(10 * sizeof(char)).Take(8).ToArray(), 0));
            DestinationList = encoding.GetString(data.Skip(10 * sizeof(char) + 8).Take(109 * sizeof(char)).ToArray()).Replace("\0", String.Empty);
            Subject = encoding.GetString(data.Skip(119 * sizeof(char) + 8).Take(78 * sizeof(char)).ToArray()).Replace("\0", String.Empty);
            Body = encoding.GetString(data.Skip(197 * sizeof(char) + 8).Take(512 * sizeof(char)).ToArray()).Replace("\0", String.Empty);
        }

        public override int GetLegnth()
        {
            var length = 10 * sizeof(char);
            length += 8; //Time length
            length += 109 * sizeof(char);
            length += 78 * sizeof(char);
            length += 512 * sizeof(char);

            return length;
        }

        public override void Normalize()
        {
            if(!String.IsNullOrEmpty(SenderName))
            {
                SenderName = SenderName.Substring(0, Math.Min(SenderName.Length, 10));
            }

            if (!String.IsNullOrEmpty(DestinationList))
            {
                DestinationList = DestinationList.Substring(0, Math.Min(DestinationList.Length, 109));
            }

            if (!String.IsNullOrEmpty(Subject))
            {
                Subject = Subject.Substring(0, Math.Min(Subject.Length, 78));
            }

            if (!String.IsNullOrEmpty(Body))
            {
                Body = Body.Substring(0, Math.Min(Body.Length, 512));
            }
        }
    }
}
