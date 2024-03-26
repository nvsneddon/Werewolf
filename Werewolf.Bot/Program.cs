﻿using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Werewolf.Bot;
using Werewolf.Bot.Commands;

IServiceProvider services = new ServiceCollection()
    .AddSingleton<DiscordSocketClient>()
    .AddSingleton<CommandService>()
    .AddScoped<PingCommand>()
    .AddSingleton<ISlashCommandHandler, SlashCommandHandler>()
    .AddSingleton<Bot>()
    .BuildServiceProvider();


await services.GetRequiredService<Bot>().RunAsync();