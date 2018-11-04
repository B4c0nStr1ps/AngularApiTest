using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace AppContainer
{
    class TestSchemaHandlerFactory : ISchemeHandlerFactory
    {
        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            var uri = new Uri(request.Url);
            if (uri.Authority == "localhost:50672")
            {
                return new SceneListResourceHandler();
            }
            return null;
        }
    }
}
