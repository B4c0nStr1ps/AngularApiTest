using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
using CefSharp.Wpf;

namespace AppContainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            CefSettings settings = new CefSettings();
            settings.RegisterScheme(new CefSharp.CefCustomScheme
            {
                SchemeName = "http",
                SchemeHandlerFactory = new TestSchemaHandlerFactory(),
                DomainName = "localhost"
                //IsSecure = true //treated with the same security rules as those applied to "https" URLs
            });
            //Cef.AddCrossOriginWhitelistEntry("http://localhost:4200/", "http", "localhost", true);
            Cef.Initialize(settings);
            InitializeComponent();
            browser.BrowserSettings.WebSecurity = CefState.Disabled;
        }
    }
}
