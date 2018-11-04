using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace AppContainer
{
    class SceneListResourceHandler : ResourceHandler
    {
        public override bool ProcessRequestAsync(IRequest request, ICallback callback)
        {
            Task.Run(() =>
            {
                using (callback)
                {
                    string value = "<SceneList><Scene name=\"Scene1\"/><Scene name=\"Scene2\"/></SceneList>";
                    Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
                    if (stream == null)
                    {
                        callback.Cancel();
                    }
                    //Reset the stream position to 0 so the stream can be copied into the underlying unmanaged buffer
                    stream.Position = 0;
                    //Populate the response values - No longer need to implement GetResponseHeaders (unless you need to perform a redirect)
                    ResponseLength = stream.Length;
                    MimeType = "text/plain";
                    StatusCode = (int)HttpStatusCode.OK;
                    Stream = stream;

                    callback.Continue();
                }
            });

            return true;
        }
    }
}
