using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hristo.DataStructures
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var myList1 = new MyLinkedList<int>();
            myList1.Add(1);
            myList1.Add(2);
            myList1.Add(3);
            myList1.Add(4);
            foreach(var item in myList1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
