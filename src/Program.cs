using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var _client = new DiscordSocketClient();

await MainAsync();

async Task MainAsync()
{
    _client = new DiscordSocketClient();

    // Token stored as user secret.
    var token = config["Discord:Token"];

    await _client.LoginAsync(TokenType.Bot, token);
    await _client.StartAsync();

    // Block this task until the program is closed.
    await Task.Delay(-1);
}

