using Bogus;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Restaurant.WebApp.Test.TestInitializers;

namespace Restaurant.DDD.WebApp.Test;

[UsesVerify]
public class ProductTest
{
    private HttpClient _httpClient;
    private VerifySettings _settings;

    private void Initialize(string databaseName, IDatabaseSeed databaseSeed)
    {
        _settings = new VerifySettings();
        _settings.UseDirectory("Verify");

        Randomizer.Seed = new Random(123456789);

        var webAppFactory = new TestApplicationFactory<Program>(databaseName, databaseSeed);
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task<VerifyResult> GetTransaction_All_DefaultDatabaseSeed_ShouldListAllTransaction()
    {
        DefaultDatabaseSeed DatabaseSeed = new();
        Initialize(nameof(GetTransaction_All_DefaultDatabaseSeed_ShouldListAllTransaction), DatabaseSeed);

        var response = await _httpClient.GetAsync("Product/1/Basic");

        return await Verify(response.Content.ReadAsStringAsync(), _settings);
    }

}