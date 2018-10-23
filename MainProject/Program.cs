using System;
using DataStructures.LinkedList;

namespace DataStructures.MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linked = new LinkedList<int> { 0, 1, 2, 3, 4 };
            linked.AddAt(3, 100);
            linked.Pop();
            linked.Pop();
            foreach (var vare in linked)
            {
                Console.WriteLine(vare);
            }

            foreach (var vare in linked)
            {
                Console.WriteLine(vare);
            }    
        }
    }
}
