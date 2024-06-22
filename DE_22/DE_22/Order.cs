using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_22
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string AssignedMaster { get; set; }
    }
}
