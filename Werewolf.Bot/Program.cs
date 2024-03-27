using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Werewolf.Bot;
using Werewolf.Bot.Commands;
using Werewolf.Core.Interfaces;
using Werewolf.Core.Services;

IServiceProvider services = new ServiceCollection()
    .AddSingleton<IDiscordClient, DiscordSocketClient>()
    .AddSingleton<DiscordSocketClient>()
    .AddSingleton<CommandService>()
    .AddScoped<PingCommand>()
    .AddScoped<StartCommand>()
    .AddSingleton<ISlashCommandHandler, SlashCommandHandler>()
    .AddSingleton<ISlashCommandRegistrator, SlashCommandRegistration>()
    .AddSingleton<Bot>()
    .AddScoped<IGameService, GameService>()
    .AddScoped<IRandomNumberGenerator, RandomNumberGenerator>()
    .AddScoped<IRoleAssignmentService, RoleAssignmentService>()
    .BuildServiceProvider();

await services.GetRequiredService<Bot>().RunAsync();