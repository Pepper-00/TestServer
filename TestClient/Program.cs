using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using ChatProto;

namespace ChatClient
{
    class Program
    {
        const string Address = "http://localhost:50051";

        public static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress(Address);
            var client = new ChatService.ChatServiceClient(channel);

            while (true)
            {
                Console.Write("Enter your name: ");
                string user = Console.ReadLine();

                Console.Write("Enter your message: ");
                string message = Console.ReadLine();

                var chatMessage = new ChatMessage { User = user, Message = message };
                var response = await client.SendMessageAsync(chatMessage);

                Console.WriteLine($"Server response: {response.Response}");
            }
        }
    }
}
