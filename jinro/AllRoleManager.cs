using System;
using System.Collections.Generic;
using System.Text;

namespace JinroGM
{
    /// <summary>
    /// 役職のタイプを表す
    /// </summary>
    public enum RoleType
    {
        NONE,                      // 役職指定がない場合にのみ使用
        VILLAGE,                  // 村人
        WAREWOLF,              // 人狼
        FORTUNE_TELLER,    // 占い師
        PSYCHIC,                  // 霊媒師
        KNIGHT,                    // 騎士
        FOX,                         // 妖狐
        MADMAN                   // 狂人
    }


    /// <summary>
    /// 役職全体を管理するクラス
    /// </summary>
    static class AllRoleManager
    {
        // 役職を表す列挙型から表示名を検索する
        private static readonly Dictionary<RoleType, string> RoleType2Name = new Dictionary<RoleType, string>()
        {
            {RoleType.NONE, "ー"},
            {RoleType.VILLAGE, "村人"},
            {RoleType.WAREWOLF, "人狼"},
            {RoleType.FORTUNE_TELLER, "占い師"},
            {RoleType.PSYCHIC, "霊媒師"},
            {RoleType.KNIGHT, "騎士"},
            {RoleType.FOX, "妖狐"},
            {RoleType.MADMAN, "狂人"}
        };

        // 表示名から役職を表す列挙型を検索する
        private static readonly Dictionary<string, RoleType> Name2RoleType = Utility.SwitchKeyAndValue<RoleType, string>(RoleType2Name);

        // 役職の人数内訳を管理する辞書
        private static Dictionary<RoleType, int> BrakeDownOfRole = new Dictionary<RoleType, int>()
        {
            {RoleType.VILLAGE, 0},
            {RoleType.WAREWOLF, 0},
            {RoleType.FORTUNE_TELLER, 0},
            {RoleType.PSYCHIC, 0},
            {RoleType.KNIGHT, 0},
            {RoleType.FOX, 0},
            {RoleType.MADMAN, 0}
        };

        // RoleTypeとIRoleのインスタンスを結びつける辞書
        private static readonly Dictionary<RoleType, IRole> RoleType2Instance = new Dictionary<RoleType, IRole>()
        {
            {RoleType.VILLAGE, null},
            {RoleType.WAREWOLF, null},
            {RoleType.FORTUNE_TELLER, null},
            {RoleType.PSYCHIC, null},
            {RoleType.KNIGHT, null},
            {RoleType.FOX, null},
            {RoleType.MADMAN, null}
        };

        /// <summary>
        /// 役職の表示名を取得する
        /// </summary>
        /// <param name="type">役職のタイプ</param>
        /// <returns>役職の表示名</returns>
        public static string GetRoleName (RoleType type)
        {
            // 辞書に登録されていないタイプが選択された場合は、nullを返却する。
            if (RoleType2Name.ContainsKey(type))
            {
                return RoleType2Name[type];
            }
            return "ー";
        }

        /// <summary>
        /// 役職のタイプを取得する
        /// </summary>
        /// <param name="role_name">役職の表示名</param>
        /// <returns>役職のタイプ</returns>
        public static RoleType GetRoleType(string role_name)
        {
            // 辞書に登録されていないタイプが選択された場合は、nullを返却する。
            if (Name2RoleType.ContainsKey(role_name))
            {
                return Name2RoleType[role_name];
            }
            return RoleType.NONE;
        }

        /// <summary>
        /// 役職の設定人数を表示する
        /// </summary>
        /// <param name="type">役職のタイプ</param>
        /// <returns>指定した役職の人数</returns>
        public static int GetNumOfRole(RoleType type)
        {
            // 辞書に登録されていないタイプが選択された場合は、nullを返却する。
            if (BrakeDownOfRole.ContainsKey(type))
            {
                return BrakeDownOfRole[type];
            }
            return 0;
        }

        /// <summary>
        /// 役職の人数を設定する
        /// </summary>
        /// <param name="type">役職のタイプ</param>
        /// <param name="num">人数</param>
        public static void SetNumOfRole(RoleType type, int num)
        {
            BrakeDownOfRole.Add(type, num);
        }

        /// <summary>
        /// IRoleのインスタンスを取得する関数
        /// </summary>
        /// <param name="type">役職タイプ</param>
        /// <returns>指定したタイプのインスタンス</returns>
        public static IRole GetRoleInstance(RoleType type)
        {
            // 辞書に登録されていないタイプが選択された場合は、nullを返却する。
            if (RoleType2Instance.ContainsKey(type))
            {
                return RoleType2Instance[type];
            }
            return null;
        }
    }
}
