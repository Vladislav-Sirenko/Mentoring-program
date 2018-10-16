using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linked = new LinkedList<int>();
            linked.Add(0);
            linked.Add(1);
            linked.Add(2);
            linked.Add(3);
            linked.Add(4);
            foreach (var vare in linked)
            {
                Console.WriteLine(vare);
            }
            foreach (var vare in linked)
            {
                Console.WriteLine(vare);
            }

            Console.ReadKey();


        }


    }
}
