using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 参考サイト
 * GUIアプリでグラフ描画 https://s51517765.hatenadiary.jp/entry/2018/09/10/073000
 * csvデータをチャート表示 https://atosuko.com/c-chart-csv-data/
*/

namespace App2
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

