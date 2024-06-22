using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisProject
{
    public class DynamicDataModel
    {
        public Dictionary<string, object> Data { get; set; }

        public DynamicDataModel()
        {
            Data = new Dictionary<string, object>();
        }
    }
}
