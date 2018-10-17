using Hash_Table;
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
           //LinkedList<int> linked = new LinkedList<int>();
            //linked.Add(0);
            //linked.Add(1);
            //linked.Add(2);
            //linked.Add(3);
            //linked.Add(4);
            //linked.AddAt(3,100);
            //linked.Pop();
            //linked.Pop();

            //foreach (var vare in linked)
            //{
            //    Console.WriteLine(vare);
            //}

            //foreach (var vare in linked)
            //{
            //    Console.WriteLine(vare);
            //}

            HashTable ht = new HashTable();
            ht.Add(1,"one");
            ht.Add(2,"two");
            ht[2]="lol";
            Console.WriteLine(ht[2]);
            //Console.WriteLine(ht[1].ToString());
            //Console.WriteLine(ht[2].ToString());
            //Console.WriteLine(ht.Contains(2));
            //object a = new object();
            //ht.TryGet(3, out a);
            //Console.WriteLine(a.ToString());
            Console.ReadKey();


        }


    }
}
