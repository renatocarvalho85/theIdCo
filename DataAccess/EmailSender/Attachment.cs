using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace DataAccess.EmailSender
{
    public class Attachment
    {
        public Attachment(string fileName, object content)
        {
            FileName = fileName;
            Content = content;
            Type = AttachmentType.text;
        }
        public enum AttachmentType
        {
            json,
            text
        }
        public string FileName { get; set; }
        public object  Content { get; set; }
        public AttachmentType Type { get; set; }

        public async Task<MemoryStream> ContetToSend()
        {
            string text;
            switch (Type)
            {
                case AttachmentType.json:
                    text = Newtonsoft.Json.JsonConvert.SerializeObject(Content);
                    break;
                case AttachmentType.text:
                    text = Content.ToString();
                    break;
                default:
                    throw  new ArgumentOutOfRangeException();
            }

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8);
            await writer.WriteAsync(text);
            await writer.FlushAsync();
            stream.Position = 0;
            return stream;
                
        }
    }
}
