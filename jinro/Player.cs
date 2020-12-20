using System;
using System.Collections.Generic;
using System.Text;

namespace JinroGM
{
    /// <summary>
    /// プレイヤーのステータスを表示するクラス
    /// </summary>
    public class GameStatus
    {
        // 生存状態
        public bool _alive = true;

        // 死亡の種類
        public DeathType _death_type = DeathType.NONE;

        // カミングアウトの種類
        public RoleType _co_data = RoleType.NONE;

        public GameStatus(bool alive=false, DeathType death=DeathType.NONE, RoleType co = RoleType.NONE)
        {
            _alive = alive;
            _death_type = death;
            _co_data = co;
        }

        /// <summary>
        /// 自らのコピーを返す
        /// </summary>
        /// <returns>メモリ参照が異なり、内部値が同じインスタンス</returns>
        public GameStatus Copy()
        {
            return new GameStatus(_alive, _death_type, _co_data);
        }
    }

    /// <summary>
    /// プレイヤーのDiscordステータス
    /// </summary>
    public class DiscordStatus
    {
        // 通話に接続しているかどうか
        public bool _connect_session = false;

        // マイクがミュートされているかどうか
        public bool _mike_mute = false;

        // スピーカーがミュートされているかどうか
        public bool _speaker_mute = false;

        public DiscordStatus(bool connect=false, bool mike=false, bool speaker = false)
        {
            _connect_session = connect;
            _mike_mute = mike;
            _speaker_mute = speaker;
        }

        /// <summary>
        /// コピーを返す関数
        /// </summary>
        /// <returns>メモリ参照が異なり内部値が同じインスタンス</returns>
        public DiscordStatus Copy()
        {
            return new DiscordStatus(_connect_session, _mike_mute, _speaker_mute);
        }
    }

    /// <summary>
    /// プレイヤークラス
    /// </summary>
    class Player
    {
        // プレイヤー名
        private string _name;

        // ユーザーID
        private string _user_id;

        // 役職
        private IRole _role;

        // ゲームでの状態
        private GameStatus _game_status = new GameStatus();

        // Discordでの状態
        private DiscordStatus _discord_status = new DiscordStatus();

        public Player(string name, string user_id, RoleType role=RoleType.NONE)
        {
            _name = name;
            _user_id = user_id;

            // 役職が指定されていたら、役職の初期化を行う。
            if (role == RoleType.NONE) return;

            _role = AllRoleManager.GetRoleInstance(role);
        }

        /// <summary>
        /// 役職を設定する
        /// </summary>
        /// <param name="type">役職のタイプ</param>
        public void SetRole(RoleType type)
        {
            _role = AllRoleManager.GetRoleInstance(type);
        }
    }
}
