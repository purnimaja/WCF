using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SimpleMathService;
using System.ServiceModel.Description;


namespace SimpleMathServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //create the base addresses for each protocol
            Uri http = new Uri("http://localhost:9999");
            Uri tcp = new Uri("net.tcp://localhost:8888");
            Uri[] baseaddress = { http, tcp };

            ServiceHost svc = new ServiceHost(typeof(SimpleMath),baseaddress);//service host needs to know which methods are hosted
            try
            {
                svc.AddDefaultEndpoints();
                //enable Metadata publishing
                ServiceMetadataBehavior metadata = new ServiceMetadataBehavior();
                metadata.HttpGetEnabled = true;
                metadata.HttpGetUrl = new Uri("http://localhost:1111");
                svc.Description.Behaviors.Add(metadata);

                //start connection
                svc.Open();

                Console.WriteLine("Server Started.....");
                Console.ReadKey();

                //shut down the server 
                svc.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
