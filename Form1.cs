using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; //グラフ用
//using System.Runtime.Intrinsics.X86;

/* 参考サイト
 * Chartで散布図かく　https://qiita.com/nekotadon/items/5c0a8ff0260e2d27811e
 */

namespace App2
{

    public partial class Form1 : Form
    {
        //List<string> x_val;
        List<string> yh_val;
        List<string> yl_val;

        public Form1()
        {
            InitializeComponent();

        }


        private void chart1_Click(object sender, EventArgs e)
        {
            //初期化
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Dock = DockStyle.Fill;

            //グラフエリアと凡例を作成
            chart1.ChartAreas.Add(new ChartArea());//グラフエリア
            chart1.Legends.Add(new Legend());//凡例

            Series series1 = new Series();
            Series series2 = new Series();

            //データ系列のグラフの種類を散布図（点のみ）とする
            series1.ChartType = SeriesChartType.Point;
            series2.ChartType = SeriesChartType.Point;

            series1.MarkerStyle = MarkerStyle.Circle;//丸マーカー
            series1.MarkerSize = 6;//マーカーサイズ
            series1.MarkerColor = Color.Red;//マーカーの色
            series1.MarkerBorderColor = Color.Red;//マーカー外枠の色
            series1.MarkerBorderWidth = 1;//マーカー外枠の太さ
            series1.LegendText = "最高気温平均";//凡例文字列の変更

            series2.MarkerStyle = MarkerStyle.Circle;//丸マーカー
            series2.MarkerSize = 6;//マーカーサイズ
            series2.MarkerColor = Color.Blue;//マーカーの色
            series2.MarkerBorderColor = Color.Blue;//マーカー外枠の色
            series2.MarkerBorderWidth = 1;//マーカー外枠の太さ
            series2.LegendText = "最低気温平均";//凡例文字列の変更

            // 読み込みたいCSVファイルのパスを指定して開く
            StreamReader sr = new StreamReader(@"app1out.csv");
            {
                sr.ReadLine(); //ヘッダ削除
                int i = 0;
                // 末尾まで繰り返す
                while (!sr.EndOfStream)
                {
                    // CSVファイルの一行を読み込む
                    string line = sr.ReadLine();
                    // 読み込んだ一行をカンマ毎に分けて配列に格納する
                    string[] values = line.Split(',');

                    series1.Points.AddXY(i + 1, values[1]);
                    series2.Points.AddXY(i + 1, values[2]);
                    i++;
                }
            }

            chart1.Series.Add(series1);
            chart1.Series.Add(series2);

            //コードが長くなるので軸を変数に代入
            Axis AxisX = chart1.ChartAreas[0].AxisX;
            Axis AxisY = chart1.ChartAreas[0].AxisY;

            AxisX.Minimum = 1;//最小値

            //Y軸との交差位置を変更
            AxisX.Crossing = 1;

            //軸のタイトルを設定
            AxisX.Title = "月";
            AxisY.Title = "平均気温[℃]";

            //グラフタイトル
            chart1.Titles.Add("各月の最高気温・最低気温の平均");
        }
    }
}
