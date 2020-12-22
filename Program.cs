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

            // ログインしてデータの取得を待機する
            await Connecter._commands.AddModuleAsync<Assembly>(Connecter._services);
            await _connecter._client.LoginAsync(TokenType.Bot, _connecter._token);
            await _connecter._client.StartAsync();

            // 一般channelにコネクトメッセージを送信
            var channel = _connecter._client.GetChannel(787349069923221508) as ISocketMessageChannel;
            await _connecter.SendMessage(channel, "[system message]  Connect Success.");

            await Task.Delay(-1);
        }
    }
}
