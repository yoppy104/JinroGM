using System;
using System.Collections.Generic;
using System.Text;

namespace JinroGM
{
    static class Utility
    {
        private static StringBuilder _builder = new StringBuilder();

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
    }
}
