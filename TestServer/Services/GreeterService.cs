using System.Threading.Tasks;
using Grpc.Core;
using ChatProto;

namespace ChatServer
{
    public class ChatServiceImpl : ChatService.ChatServiceBase
    {
        public override Task<ChatResponse> SendMessage(ChatMessage request, ServerCallContext context)
        {
            Console.WriteLine($"Received message from {request.User}: {request.Message}");
            return Task.FromResult(new ChatResponse { Response = $"Message received: {request.Message}" });
        }
    }
}
