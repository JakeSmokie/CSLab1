using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Grpc.Core;
using Labs;

namespace CSLab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object lockObject = new object();
        private bool opened = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            lock (lockObject)
            {
                if (e.Key == Key.Escape)
                {
                    Environment.Exit(0);
                }
                if (e.Key == Key.Enter)
                {

                    if (opened)
                    {
                        return;
                    }

                    opened = true;

                    var address = AddressTextBox.Text;
                    var channel = new Channel(address, ChannelCredentials.Insecure);
                    var client = new MathsProccessor.MathsProccessorClient(channel);

                    AddressTextBox.Background = new SolidColorBrush(Color.FromRgb(127, 255, 127));

                    try
                    {
                        // Test connection
                        client.Set(new Arguments() { ID = "0", Input = 0 });

                        var window = new InteractionWindow(client);
                        window.Show();

                        this.Close();
                    }
                    catch (RpcException)
                    {
                        AddressTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 63, 63));
                        opened = false;
                    }
                }
            }
        }
    }
}
