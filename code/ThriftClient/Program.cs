using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;
using storage;

namespace ThriftClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Apache thrift client:");

            try
            {
                TTransport transport = new TSocket("localhost", 9090);
                TProtocol protocol = new TBinaryProtocol(transport);
                StorageService.Client client = new StorageService.Client(protocol);

                transport.Open();
                try
                {
                    client.ping();
                    Console.WriteLine("ping()");
                    var list = client.storagePoints();
                    foreach(var p in list){
                        Console.WriteLine("Id: {0}, Name: {1}, Description: {2}", p.StorageId, p.Name, p.Description);
                    }
                    var result = client.read(1);
                    Console.WriteLine("read: " + result);

                    if (client.write(0, "uusi arvo"))
                    {
                        Console.WriteLine("write ok");
                    }
                    else
                    {
                        Console.WriteLine("write failed");
                    }
                   
                }
                finally
                {
                    transport.Close();
                }
            }
            catch (TApplicationException x)
            {
                Console.WriteLine(x.StackTrace);
            }

        }
    }
}
