using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrypterRSA
{
    internal class HexToByteArrayConverter
    {
        // fik den af nicklas
        public byte[] StringToByteArray(string hex)
        {
            string[] hexvalues = hex.Split('-');
            byte[] restoredByteArray = new byte[hexvalues.Length];

            for (int i = 0; i < hexvalues.Length; i++)
            {
                restoredByteArray[i] = Convert.ToByte(hexvalues[i], 16);
            }
            return restoredByteArray;
        }
    }
}
