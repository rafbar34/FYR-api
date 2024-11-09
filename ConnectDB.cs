using System.Threading.Tasks;
using Supabase;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Supabase.Interfaces;
using Microsoft.Extensions.Configuration;

public class ConnectDBService : IHostedService
{
    private readonly Client _SupaBaseClient;
    private readonly IConfiguration _configuration;

    public ConnectDBService(IConfiguration configuration)
    {
        _configuration = configuration;

        var url = _configuration["AppSettings:SupbaseUrl"]; ;
        var key = _configuration["AppSettings:SupabaseApiKey"]; ;

        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        _SupaBaseClient = new Client(url, key, options);

    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {

        await _SupaBaseClient.InitializeAsync();
        Console.WriteLine("Connected to Supabase");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public Client SupabaseClient => _SupaBaseClient;
}