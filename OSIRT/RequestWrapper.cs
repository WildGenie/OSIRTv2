using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeTypes;

namespace OSIRT
{
    public class RequestWrapper
    {
        //public IRequest Request { get; private set; }
        //public IResponse Response { get; private set; }

        public string RequestUrl { get; private set; }
        public ResourceType ResourceType { get; private set; }
        public string MimeType { get; private set; }
        public byte[] Data { get; private set; }


        public RequestWrapper(string requestUrl, ResourceType resourceType, string mimeType, byte[] data)
        {
            RequestUrl = requestUrl;
            ResourceType = resourceType;
            MimeType = mimeType;
            Data = data;
        }

        public bool IsStringRequest()
        {
            return ResourceType == ResourceType.MainFrame || ResourceType == ResourceType.SubFrame || ResourceType == ResourceType.Script || ResourceType == ResourceType.Stylesheet;
        }



        public string FileName()
        {
            string filename = "";
            switch (ResourceType)
            {
                case ResourceType.MainFrame:
                    filename = "mainframe.html";
                    //filename = GetSafeFilename(filename);
                break;
                case ResourceType.SubFrame:
                    filename = GetSafeFilename(filename); //$"subframe{++subframe}.html";
                break;
                //case ResourceType.Stylesheet:
                //    filename = $"style{++css}.css";
                //    break;
                case ResourceType.Script:
                case ResourceType.Image:
                case ResourceType.Stylesheet:
                case ResourceType.FontResource:
                case ResourceType.Object:
                case ResourceType.Xhr:
                    filename = GetSafeFilename(filename);
                    break;
                //case ResourceType.Image:
                //    filename = GetSafeFilename(filename);
                //    break;

            }
            return filename;
        }

        private string GetSafeFilename(string filename)
        {
            try
            {
                filename = Path.GetFileName(RequestUrl);
                filename = string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));

                if (filename.Length > 150)
                {
                    filename = filename.Substring(0, 150);
                }

                if (filename == "") filename = "blank_file_" + DateTime.Now.ToString("ddMMyyyyHHmmss");// + "." + MimeTypeMap.GetExtension(MimeType);
            }
            catch
            {
                filename = "error_file_" + DateTime.Now.ToString("ddMMyyyyHHmmss");// + "." + MimeTypeMap.GetExtension(MimeType);
            }

            //Console.WriteLine("Returned file name: " + filename);
            return filename;

        }


    }
}
