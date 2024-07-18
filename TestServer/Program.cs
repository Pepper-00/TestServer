using System;
using System.Threading.Tasks;
using Grpc.Core;
using ChatProto;
using Microsoft.AspNetCore.Hosting.Server;

namespace ChatServer
{
    class Program
    {
        const int Port = 50051;

        public static async Task Main(string[] args)
        {
            Server server = new Server
            {
                Services = { ChatService.BindService(new ChatServiceImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Chat server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            await server.ShutdownAsync();
        }
    }
}
