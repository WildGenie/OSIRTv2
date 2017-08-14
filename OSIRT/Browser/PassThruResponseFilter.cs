using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Browser
{
    class PassThruResponseFilter : IResponseFilter
    {

        public bool InitFilter()
        {
            return true;
        }

        int count = 0;
        public FilterStatus Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            BinaryWriter sw;

            if (dataIn == null)
            {
                dataInRead = 0;
                dataOutWritten = 0;

                return FilterStatus.Done;
            }

            dataInRead = dataIn.Length;
            dataOutWritten = Math.Min(dataInRead, dataOut.Length);


            byte[] buffer = new byte[dataOutWritten];
            int bytesRead = dataIn.Read(buffer, 0, (int)dataOutWritten);

            //string s = System.Text.Encoding.UTF8.GetString(buffer);

            sw = new BinaryWriter(File.Open($@"C:\Users\Joe\Desktop\filter\file{++count}", FileMode.Append));
            sw.Write(buffer);
            sw.Close();

            dataOut.Write(buffer, 0, bytesRead);

            dataIn.CopyTo(dataOut);

            return FilterStatus.Done;
        }

        public void Dispose()
        {

        }
    }
}
