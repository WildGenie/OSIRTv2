using CefSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Browser
{
    public class MemoryStreamResponseFilter : IResponseFilter
    {
        private MemoryStream memoryStream;

        bool IResponseFilter.InitFilter()
        {
            //NOTE: We could initialize this earlier, just one possible use of InitFilter
            memoryStream = new MemoryStream();

            return true;
        }

        FilterStatus IResponseFilter.Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {
            if (dataIn == null)
            {
                dataInRead = 0;
                dataOutWritten = 0;

                return FilterStatus.Done;
            }

            dataInRead = dataIn.Length;

            if (dataIn.Length > dataOut.Length)
            {
                var data = new byte[dataOut.Length];
                dataIn.Seek(0, SeekOrigin.Begin);
                dataIn.Read(data, 0, data.Length);
                dataOut.Write(data, 0, data.Length);

                dataInRead = dataOut.Length;
                dataOutWritten = dataOut.Length;
                return FilterStatus.NeedMoreData;
            }

            dataOutWritten = Math.Min(dataInRead, dataOut.Length);

            //Important we copy dataIn to dataOut
            try
            {
                dataIn.CopyTo(dataOut);
            }
            catch { Debug.WriteLine("HIIIIIIIIIIIIIIIIIIIIIIIIII");  }

            //Copy data to stream
            dataIn.Position = 0;
            dataIn.CopyTo(memoryStream);

            return FilterStatus.Done;
        }

        void IDisposable.Dispose()
        {
            memoryStream.Dispose();
            memoryStream = null;
        }

        public byte[] Data
        {
            get { return memoryStream.ToArray(); }
        }
    }
}
