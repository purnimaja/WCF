using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace SimpleMathService
{
    [ServiceContract]
    public interface ISimpleMath
    {
        [OperationContract]
        int Square(int x);

        //service contract

        [OperationContract]
        int Cube(int x);

        [OperationContract]
        int Add(int x,int y);

        [OperationContract]
        List<Person> GetPerson(char x);


       

        //create an operation which takes  Stsrting alphabet as an arg and returns names
        //of all people starting with that alphabet
       

    }

    public class SimpleMath : ISimpleMath    //Actual Service
    {
        //create a list of person object
        List<Person> p = new List<Person>();
        List<Person> list = new List<Person>();

        public SimpleMath()
        {
            Person p = new Person();
            p.PersonName = "vishal";
            p.Place = "valsad";
            list.Add(p);

            Person p1 = new Person();
            p1.PersonName = "purnima";
            p1.Place = "sultanpur";
            list.Add(p1);

            Person p2 = new Person();
            p2.PersonName = "kiran";
            p2.Place = "akola";
            list.Add(p2);

            Person p3 = new Person();
            p3.PersonName = "neelam";
            p3.Place = "solapur";
            list.Add(p3);

            Person p4 = new Person();
            p4.PersonName = "hitesh";
            p4.Place = "ulhasnagar";
            list.Add(p4);

        }

        public int Square(int x)
        {
            return (x * x);
        }

        public int Cube(int x)
        {
            return (x * x * x);
        }

        public int Add(int x, int y)
        {
            return (x + y);
        }

        public List<Person> GetPerson(char x)
        {
           List<Person> list1 = new List<Person>();
            foreach (Person z in list)
            {
                if (z.PersonName[0] == x)
                {
                    list1.Add(z);
                }
            }
            return list1;
        }
    }
        [DataContract]
        public class Person
        {
            [DataMember]
            public string PersonName { get; set; }

        [DataMember]
        public string  Place { get; set; }
        }
    

}
