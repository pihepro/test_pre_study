using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;
using storage;

namespace ThriftServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Apache thrift server");
             try
                {
                    StorageServiceHandler handler = new StorageServiceHandler();
                    StorageService.Processor processor = new StorageService.Processor(handler);
                    TServerTransport serverTransport = new TServerSocket(9090);
                    TServer server = new TSimpleServer(processor, serverTransport);

                    // Use this for a multithreaded server
                    // server = new TThreadPoolServer(processor, serverTransport);

                    Console.WriteLine("Starting the server...");
                    server.Serve();
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.StackTrace);
                }
                Console.WriteLine("done.");
            }
        }
    }

