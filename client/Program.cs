using Grpc.Core;
using Dummy;

const string target = "127.0.0.1:50051";

// Create a channel
Channel channel = new Channel(target, ChannelCredentials.Insecure);

channel.ConnectAsync().ContinueWith((task) =>
{
    if (task.Status == TaskStatus.RanToCompletion)
    {
        Console.WriteLine("The client connected successfully");
    }
});

// Create a client
var client = new DummyService.DummyServiceClient(channel);

channel.ShutdownAsync().Wait();
Console.ReadKey();