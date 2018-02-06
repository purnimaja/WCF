using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMathClientProject.ServiceReference1;

namespace SimpleMathClientProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleMathClient proxy = new SimpleMathClient("NetTcpBinding_ISimpleMath");
            //SimpleMathClient proxy1 = new SimpleMathClient("BasicHttpBinding_ISimpleMath"); 
            int Square = proxy.Square(10);
            int Cube = proxy.Cube(10);
            int Add = proxy.Add(10,20);

            Console.WriteLine("Enter a char");

            char z = char.Parse(Console.ReadLine());

            List<Person> c = proxy.GetPerson(z).ToList();

            foreach (Person p in c)
            {
                Console.WriteLine("name " + p.PersonName + " place is"+" " + p.Place);
                Console.ReadLine();
            }

            Console.WriteLine("Square is:"+Square);
            Console.WriteLine("Cube is:"+Cube);
            Console.WriteLine("Addition is:" +Add);

           // Console.WriteLine(" Person is:" +PersonName);
            Console.WriteLine();
        }
    }
}
