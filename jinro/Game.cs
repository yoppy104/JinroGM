using System;
using System.Collections.Generic;
using System.Text;

namespace JinroGM
{
    /// <summary>
    /// 死亡の種類
    /// </summary>
    public enum DeathType
    {
        NONE,         // 生存
        EXECUTE,    // 処刑
        RAID,          // 狼による殺害
        DIVINATE    // 占いによって死亡（狐のみ）
    }


    public enum Fase
    {
        MORNING,            // 朝（夜に死亡したプレイヤーの伝達、終了判定等）
        DISCUSSION,        // 議論
        VOTE,                  // 投票
        BEFOER_NIGHT,    // 夜以降前（処刑されたプレイヤーの伝達、終了判定等)
        NIGHT                  // 夜（各役職の能力行使)
    }

    /// <summary>
    /// 人狼ゲームの流れを管理するクラス
    /// </summary>
    class Game
    {
        // 死亡タイミングを管理する辞書
        public readonly Dictionary<DeathType, string> DEATH_TIMING = new Dictionary<DeathType, string>()
        {
            {DeathType.NONE, "ー"},
            {DeathType.EXECUTE, "昼"},
            {DeathType.RAID, "夜"},
            {DeathType.DIVINATE, "夜" }
        };


        /*
         *  プレイヤー関連の変数
         */
        private int _num_of_player;      // ゲームへの参加人数

        private int _num_of_outside_of_warewolf; // 人狼以外の人数
        private int _num_of_warewolf;                  // 人狼の人数

        private Player[] _players;             // プレイヤーの一覧（インデックスをIDとして使用する)
        private int[] _alive_players_id;     // 生存プレイヤーのIDリスト
        private int[] _death_players_id;    // 死亡プレイヤーのIDリスト

        private int _num_of_alive;  // 生存プレイヤーの人数

        /*
         *  ゲーム進行関係の変数
         */
        private int _day;  // ゲームのプレイ日数

        private Fase _fase; // 現在のフェーズを判定



        Game()
        {

        }
    }
}
