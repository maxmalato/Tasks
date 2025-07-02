namespace Tasks.Tests;

public class IntegrationTests : IClassFixture<TasksWebAppFactory<Program>>
{
    private readonly TasksWebAppFactory<Program> _factory;

    internal IntegrationTests(TasksWebAppFactory<Program> factory) => _factory = factory;

    [Fact]
    public async Task GetTasks_ReturnsSuccessStatusCode()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Nenhum tarefa encontra em Xunit", content);
    }
}