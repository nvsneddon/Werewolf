using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Werewolf.Bot;

IServiceProvider services = new ServiceCollection()
    .AddSingleton<DiscordSocketClient>()
    .AddSingleton<CommandService>()
    .AddSingleton<PingCommand>()
    .AddSingleton<SlashCommandHandler>()
    .AddSingleton<Bot>()
    .BuildServiceProvider();


await services.GetRequiredService<Bot>().RunAsync();