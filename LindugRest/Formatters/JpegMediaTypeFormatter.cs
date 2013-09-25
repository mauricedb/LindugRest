using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using LindugRest.Models;

namespace LindugRest.Formatters
{
    public class JpegMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        private string _folder;

        public JpegMediaTypeFormatter(string folder)
        {
            _folder = folder;
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(Book).IsAssignableFrom(type);
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            var book = value as Book;
            if (book != null)
            {
                var path = Path.Combine(_folder, book.ImageName);
                var buffer = File.ReadAllBytes(path);
                writeStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}