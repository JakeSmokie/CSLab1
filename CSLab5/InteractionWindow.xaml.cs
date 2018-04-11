using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Labs;

namespace CSLab5
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class InteractionWindow : Window
    {
        private MathsProccessor.MathsProccessorClient client;
        private List<OperationHistoryNode> history;

        public InteractionWindow(MathsProccessor.MathsProccessorClient client)
        {
            this.client = client;
            InitializeComponent();

            history = new List<OperationHistoryNode>();
            operationsHistory.ItemsSource = history;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void operationsHistory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
