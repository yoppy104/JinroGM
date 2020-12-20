using System;
using System.Collections.Generic;
using System.Text;

namespace JinroGM
{
    /// <summary>
    /// 陣営の分類（勝利条件によって分岐)
    /// </summary>
    public enum TeamType
    {
        VILLAGE,         // 村人陣営
        WAREWORF,    // 人狼陣営
        FOX                // 妖狐陣営
    }

    /// <summary>
    /// 役職クラス
    /// </summary>
    public interface IRole
    {
        // 役職の名前
        public string _role_name
        {
            get;
            protected set;
        }

        // 陣営の定義
        public TeamType _team
        {
            get;
            protected set;
        }


        /// <summary>
        /// 初夜の行動
        /// </summary>
        public virtual void ActionFirstNight()
        {

        }

        /// <summary>
        /// 夜の行動
        /// </summary>
        public virtual void ActionNight()
        {

        }


        /// <summary>
        /// 占い・霊媒の結果を返す関数
        /// </summary>
        /// <returns>trueなら人狼陣営、falseなら村人陣営</returns>
        public virtual bool GetDivide()
        {
            return false;
        }
    }
}
