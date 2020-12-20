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

        Game()
        {

        }
    }
}
