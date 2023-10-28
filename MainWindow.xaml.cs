using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace XamlTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.LoadXamlFileList();
        }

        private void LoadXamlFileList()
        {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            var xamls = dir.GetFiles("*.xaml");
            if ( xamls != null && xamls.Length > 0)
            {
                this.btn_reload.IsEnabled = true;
                this.list_file.ItemsSource = xamls.Select(t=>t.Name);
            }
        }

        private void list_file_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RenderFlowDocument();
        }

        private void btn_reload_Click(object sender, RoutedEventArgs e)
        {
            RenderFlowDocument();
        }

        private void RenderFlowDocument()
        {
            if (list_file.SelectedValue != null)
            {
                ResourceDictionary customResourceDict = new ResourceDictionary();
                customResourceDict.Source = new Uri(Directory.GetCurrentDirectory() + "\\" + list_file.SelectedValue);
                List<FlowDocumentCell> cells = new List<FlowDocumentCell>();
                foreach (System.Collections.DictionaryEntry pair in customResourceDict)
                {
                    FlowDocument flowDocument = pair.Value as FlowDocument;
                    cells.Add(new FlowDocumentCell() { Key = (string)pair.Key, Document = flowDocument });
                }
                this.items_document.ItemsSource = cells;
            }
        }
    }
}
