using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace InjectDotNetToJavascript
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChromiumWebBrowser browser;

        public MainWindow()
        {

            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            InitializeComponent();

            browser = new ChromiumWebBrowser();
            browser.RegisterJsObject("dotNetMessage", new DotNetMessage());

            browser.IsBrowserInitializedChanged += (sender, args) =>
            {
                if (browser.IsBrowserInitialized)
                {
                    browser.LoadHtml(File.ReadAllText("index.html"));
                }
            };

            MainGrid.Children.Add(browser);
        }

        public class DotNetMessage
        {
            public void Show(string message)
            {
                MessageBox.Show(message);
            }
        }
    }
}
