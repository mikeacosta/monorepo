using Docker.DotNet;

namespace MovieRank.Integration.Tests.Setup;

public class TestContext : IAsyncLifetime
{
    private readonly DockerClient _dockerClient;
    private const string UnixSocket = "unix:///var/run/docker.sock";

    public TestContext()
    {
        _dockerClient = new DockerClientConfiguration(new Uri(UnixSocket)).CreateClient();
    }
    
    public async Task InitializeAsync()
    {
        
    }

    public async Task DisposeAsync()
    {
        throw new NotImplementedException();
    }
}