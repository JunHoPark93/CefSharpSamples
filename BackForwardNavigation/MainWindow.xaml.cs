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

namespace BackForwardNavigation
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            Dispatcher.BeginInvoke((Action) (() =>
            {
                AddressBox.Text = e.Url;
                BackBtn.IsEnabled = Browser.CanGoBack;
                NavigationBtn.IsEnabled = !string.IsNullOrWhiteSpace(AddressBox.Text);
                ForwardBtn.IsEnabled = Browser.CanGoForward;
            }));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Browser.CanGoBack)
            {
                Browser.Back();
            }
        }

        private void NavigationBtn_Click(object sender, RoutedEventArgs e)
        {
            // if address exists
            if (!string.IsNullOrWhiteSpace(AddressBox.Text))
            {
                Browser.Address = AddressBox.Text;
            }

        }

        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.Forward();
            }
        }
    }
}
