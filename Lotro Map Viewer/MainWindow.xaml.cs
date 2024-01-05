using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Lotro_Map_Viewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            using (FileStream s = new FileStream("data/regions.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                doc.Load(s);
            }

            LoadData.Document = doc;

        }
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is not null)
            {
                var tmp = (XmlElement)e.NewValue;
                txtNorth.Text = "Not Null";
                //txtNorth.Text = tmp.InnerXml;
            }
            else
            {
                txtNorth.Text = "Null";
            }
        }
    }
}