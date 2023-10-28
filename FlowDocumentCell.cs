using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace XamlTool
{
    public class FlowDocumentCell
    {
        public string Key
        {
            get;
            set;
        }

        public string Xaml
        {
            get;
            set;
        }

        public FlowDocument Document
        {
            get;
            set;
        }
    }
}
