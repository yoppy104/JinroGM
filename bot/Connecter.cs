using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using System.IO;
using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace JinroGM
{
    class Connecter
    {
        // Botのトークン
        public string _token
        {
            get;
            private set;
        }

        // 接続先トークン
        public DiscordSocketClient _client
        {
            get;
            private set;
        }

        // コマンド受送信クラス
        public static CommandService _commands 
        {
            get;
            private set;
        }

        // サービスクラス
        public static IServiceProvider _services
        {
            get;
            private set;
        }

        // アクションメソッド用のデリゲート
        public delegate Task action(SocketUserMessage message);

        // デリゲートを一元管理する辞書
        private Dictionary<string, action> action_method = new Dictionary<string, action>();


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Connecter()
        {
            // トークンの読み込み
            StreamReader sr = new StreamReader(Utility.MakePath(ConstValue.DATAS_DIRECTORY_PATH, ConstValue.TOKEN_FILE_PATH));
            _token = sr.ReadLine();
            sr.Close();
            _token = _token.Replace("\n", ""); // 改行記号の除去

            // クライエントの読み込み
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info
            });
            _client.Log += Log;

            _commands = new CommandService();
            _services = new ServiceCollection().BuildServiceProvider();
            _client.MessageReceived += CommandRecieved;

            SetActionMethod(); // アクションメソッドをリスナーに登録する
        }

        /// <summary>
        /// なにがしかのメッセージを受信したときの処理
        /// </summary>
        /// <param name="messageParam">受信したメッセージ</param>
        /// <returns></returns>
        public async Task CommandRecieved(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;

            // デバッグ用メッセージの出力
            Console.WriteLine("{0} {1}:{2}", message.Channel.Name, message.Author.Username, message);
            // メッセージがnullの場合
            if (message == null) return;
            //発言者がBotの場合は無視する
            if (message.Author.IsBot) return;

            var context = new CommandContext(_client, message);

            var CommandContext = message.Content;

            if (CommandContext[0] != '@')  return;

            if (action_method.ContainsKey(CommandContext))
            {
                await action_method[CommandContext](message);
            }
            else
            {
                await SendMessage(message.Channel, String.Format("I can't listen this command : [ {0} ]", CommandContext));
            }
        }

        /// <summary>
        /// Discord上にメッセージを送信する
        /// </summary>
        /// <param name="channel">送信するチャンネル</param>
        /// <param name="message">送信するメッセージ</param>
        /// <returns></returns>
        public async Task SendMessage(ISocketMessageChannel channel, string message)
        {
            await channel.SendMessageAsync(message);
        }


        /// <summary>
        /// メソッドを追加する
        /// </summary>
        /// <param name="key">コマンドキー</param>
        /// <param name="method">アクション関数</param>
        public void AddListener(string key, action method)
        {
            if (key[0] != '@')
            {
                Console.WriteLine("[AddListener] keyの先頭が@ではありません。");
                return;
            }
            action_method[key] = method;
        }



        /// <summary>
        /// アクションメソッドの初期設定を行う
        /// </summary>
        private void SetActionMethod()
        {
            AddListener("@おはよう", async delegate (SocketUserMessage message)
            {
                await SendMessage(message.Channel, "Hello...");
            });
        }


        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        /// <returns></returns>
        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }
    }
}
