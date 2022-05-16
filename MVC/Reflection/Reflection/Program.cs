using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            PropertyInfo[] props = typeof(Personel).GetProperties();

            foreach (var item in props)
            {
                Console.WriteLine(item.Name);
            }

            
            MethodInfo[] methots = typeof(Personel).GetMethods();

            foreach (var item in methots)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadLine();

        }
    }
}
