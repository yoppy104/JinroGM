using System;
using System.Collections.Generic;
using System.Text;

namespace JinroGM
{
    static class Utility
    {
        // 改行記号
        public static string _newLine = Environment.NewLine;

        // string 結合クラス
        public static StringBuilder _builder = new StringBuilder();

        /// <summary>
        /// ルートディレクトリからの相対パスを返却する
        /// </summary>
        /// <param name="dir_path">指定するディレクトリのルートからのパス</param>
        /// <param name="file_path">指定するファイルの名称（拡張子を含む）</param>
        /// <returns></returns>
        public static string MakePath(string dir_path, string file_name)
        {
            // StringBuilderの初期化
            _builder.Clear();

            // パスをルートから順番に追加
            _builder.Append(ConstValue.ROOT_PATH);
            _builder.Append(dir_path);
            _builder.Append(file_name);

            // stringとして結合して返却
            return _builder.ToString();
        }


        /// <summary>
        /// 辞書のキーと値を入れ替える関数
        /// </summary>
        /// <typeparam name="Key">元の辞書のキーの型</typeparam>
        /// <typeparam name="Value">元の辞書の値の型</typeparam>
        /// <param name="prot_dict">元の辞書</param>
        /// <returns>キーと値を反転させた辞書</returns>
        public static Dictionary<Value, Key> SwitchKeyAndValue<Key, Value> (Dictionary<Key, Value> prot_dict)
        {
            Dictionary<Value, Key> new_dict = new Dictionary<Value, Key>();

            foreach (KeyValuePair<Key, Value> item in prot_dict)
            {
                new_dict.Add(item.Value, item.Key);                
            }

            return new_dict;
        }

    }
}
