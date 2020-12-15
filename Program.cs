using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Discord.Net;

namespace JinroGM
{
    class Program
    {
        private DiscordSocketClient _client;
        public static CommandService _commands;
        public static IServiceProvider _services;

        static void Main(string[] args) 
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info
            });

            _client.Log += Log;
            _commands = new CommandService();
            _services = new ServiceCollection().BuildServiceProvider();
            _client.MessageReceived += CommandRecieved;

            string token = "@@@";
            await _commands.AddModuleAsync<Assembly>(_services);
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        /// <summary>
        /// 何かしらのメッセージの受信
        /// </summary>
        /// <param name="messageParam"></param>
        /// <returns></returns>
        private async Task CommandRecieved(SocketMessage messageParam)
        {
            var message = messageParam as Discord.WebSocket.SocketUserMessage;

            // デバッグ用メッセージの出力
            Console.WriteLine("{0} {1}:{2}", message.Channel.Name, message.Author.Username, message);
            // メッセージがnullの場合
            if (message == null) return;
            //発言者がBotの場合は無視する
            if (message.Author.IsBot) return;

            var context = new CommandContext(_client, message);

            var CommandContext = message.Content;

            if (CommandContext == "おはよう")
            {
                await message.Channel.SendMessageAsync("Hello!");
            }
        }

        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }
    }
}
