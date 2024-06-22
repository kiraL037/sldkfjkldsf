using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_22
{
    public static class OrderCount
    {
        public static int GetTotalOrders(List<Order> orders)
        {
            return orders.Count;
        }

        //public static double GetAverageTime(List<Order> orders) 
        //{
        //    if (orders.Count = 0) return 0;

        //    double totalTime = 0;

        //    foreach (var order in orders)
        //    {
        //        totalTime += order.Time.TotalHours;
        //    }
        //    return totalTime/orders.Count;
        //}
    }
}
