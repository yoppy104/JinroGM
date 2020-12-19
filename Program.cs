using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace JinroGM
{
    class Program
    {
        private Connecter _connecter;

        static void Main(string[] args) 
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _connecter = new Connecter();

<<<<<<< HEAD
            // ログインしてデータの取得を待機する
            await Connecter._commands.AddModuleAsync<Assembly>(Connecter._services);
            await _connecter._client.LoginAsync(TokenType.Bot, _connecter._token);
            await _connecter._client.StartAsync();
=======
            _client.Log += Log;
            _commands = new CommandService();
            _services = new ServiceCollection().BuildServiceProvider();
            _client.MessageReceived += CommandRecieved;

            string token = "@@@";
            await _commands.AddModuleAsync<Assembly>(_services);
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
>>>>>>> 83347c4a493b595e21c041a5a53b2b0c0c4b13f2

            await Task.Delay(-1);
        }
    }
}
