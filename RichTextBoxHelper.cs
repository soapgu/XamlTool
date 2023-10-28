using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace XamlTool
{
    public class RichTextBoxHelper : DependencyObject
    {

        public static readonly DependencyProperty DocumentXamlProperty =
           DependencyProperty.RegisterAttached("DocumentXaml",
                                       typeof(FlowDocument),
                                       typeof(RichTextBoxHelper),
                                       new PropertyMetadata(new PropertyChangedCallback(DocumentChanged)));

        private static void DocumentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = (RichTextBox)obj;
            FlowDocument document = e.NewValue as FlowDocument;
            if (document == null)
            {
                control.Document = new FlowDocument();
            }
            else
            {
                control.Document = document;
            }
        }

        public static FlowDocument GetDocumentXaml(DependencyObject obj)
        {
            return (FlowDocument)obj.GetValue(DocumentXamlProperty);
        }

        public static void SetDocumentXaml(DependencyObject obj, string value)
        {
            obj.SetValue(DocumentXamlProperty, value);
        }
    }
}
