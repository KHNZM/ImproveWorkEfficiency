using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace ImproveWorkEfficiency
{
    public partial class MainForm : Form
    {
        Process myProcess = new Process();

        /// <summary>
        /// 各ソフトウェア/フォルダのショートカットを置いているフォルダ：IWE_AdminForRemoconへのパス
        /// </summary>
        readonly string AdminPath = "C:\\IWE_Admin\\";
        /// <summary>
        /// 定期的な予定はここへ格納する。RegularSchedule
        /// </summary>
        List<DateTime> listRegularDateTime = new List<DateTime>();
        //List<DateTime[]> listRegularSche;    // 今後定期的な予定をユーザ登録したい場合はこれを使う。
        /// <summary>
        /// アラームメッセージ表示時刻をここに格納する。
        /// </summary>
        List<DateTime> listDateTime = new List<DateTime>();
        /// <summary>
        /// アラームメッセージ表示時、ここに内容が記載されていれば同時に表示する。
        /// </summary>
        List<string> listAlarmText = new List<string>();
        /// <summary>
        /// 定例イベントのテキスト情報をここに格納する。
        /// </summary>
        List<string> listRegularDateText = new List<string>();

        string strTmpAlarmTxt;

        DialogResult judge;

        bool bShuttingDwn = false;
        /// <summary>
        /// 再ログインフォームが閉じられるとき、メインフォームも閉じるためのフラグ
        /// irregular closing
        /// </summary>
        private static bool birregClosing = false;
        /// <summary>
        /// bClosingのプロパティ
        /// irregular closing
        /// </summary>
        public bool bPropirregClosing
        {
            set { birregClosing = value; }
            get { return birregClosing; }
        }
        /// <summary>
        /// トグルスイッチクラスのインスタンス
        /// </summary>
        TglSwitch SC_TglSw;

        public MainForm()
        {
            InitializeComponent();
            toolTip1                = new ToolTip();
            toolTip1.ShowAlways     = true;
            // .csvを読み込んで、今日鳴らすアラームはコンボボックスに追加し、古いスケジュールは削除する。
            EditSchedl();
            // トグルスイッチについての設定
            SC_TglSw                = new TglSwitch();
            SC_TglSw.Location       = new Point(10, 17);
            SC_TglSw.Size           = new Size(38, 20);
            SC_TglSw.Cursor         = Cursors.Hand;
            Controls.Add(SC_TglSw);
            SC_TglSw.Checked        = true;
            SC_TglSw.BringToFront();

            Load        += MainForm_Load;
            KeyPreview  = true;
            KeyDown     += Form_KeyDown;
            FormClosing += MainForm_Closing;
        }
        public MainForm(bool bRelogin)
        {

        }
        /// <summary>
        /// 時刻をメインフォームのラベル「TimeDisplay」に書き込む。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //時計を動かす
            timer.Interval = 1000;
            timer.Enabled = true;

            //ラベル「TimeDisplay」に現在の時間をとって書き込む
            TimeDisplay.Text = DateTime.Now.ToLongTimeString();//time.ToString();
        }
        /// <summary>
        /// ウィンドウクローズ時確認メッセージ出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!bPropirregClosing && !bShuttingDwn)
            {
                if (MessageBox.Show( "本当に終了しますか？", "確認",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question)
                                     == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            toolTip1.Show(strTmpAlarmTxt, alarmlist, 75, 20, 3000);
        }
        /// <summary>
        /// Schedule.csvファイルを読み込む。
        /// </summary>
        private void EditSchedl()
        {
            try
            {
                int ic = 0;
                int jc;
                int findPos = 0;
                List<string> strSchedlList = new List<string>();
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("C:\\IWE_Admin\\Schedule.csv", System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    int nHour, nMinute;
                    string line;

                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        // 空っぽの改行や、予定の項目のみ削除して",,"のみ残っている項目は読みとばす。
                        if (line.Contains(",,") || line == "") continue;
                        // 読み飛ばさなかった行をAddしておいて、この後のstreamWriterでSchedule.csvを上書きする。
                        strSchedlList.Add(line);
                        // 一行目は読まないので飛ばす。
                        if (line.Substring(0, 2) == "日付") continue;
                        // 初めの","までの文字数を取得する。
                        findPos = line.IndexOf(",");
                        if (line.Substring(0, 2).All(char.IsDigit)) // 読み取った文字列の初めの2文字が数値である場合はListDateTimeにAddする。
                        {
                            // 最初に記述されている日付が、今日の日付と合ってなかったらcontinue;
                            if (DateTime.Today.ToShortDateString()
                                != DateTime.Parse(line.Substring(0, findPos)).ToShortDateString()) continue;
                            
                            // 残りの文字列の日付部分を切り取る。
                            line = line.Substring(findPos + 1, line.Length - findPos - 1);
                            // ":"までの文字数を取得する。
                            findPos = line.IndexOf(":");
                            // 何時なのか取得する。
                            int.TryParse(line.Substring(0, findPos), out nHour);
                            // 何分なのか取得する。
                            int.TryParse(line.Substring(findPos + 1, 2), out nMinute);
                            // 現在時刻が取得した時刻より後の時間であればcontinue;
                            if (DateTime.Now > DateTime.Parse(nHour + ":" + nMinute)) continue;
                            // 取得した時刻をセットする。
                            listDateTime.Add(setTime(nHour, nMinute)[0]);
                            listDateTime.Add(setTime(nHour, nMinute)[1]);
                            // 二つ目の","までの文字数を取得する。
                            findPos = line.IndexOf(",");
                            // 残りの文字列の時刻部分を切り取る。
                            line = line.Substring(findPos + 1, line.Length - findPos - 1);

                            // 最後の内容がアラームテキストになるので、listAlarmTextにAddして、コンボボックスにも追加する。
                            if (line.Contains("webex" + " ") && !IsFulLetrs(line.Substring(6, line.Length - 6)))
                            {
                                string webexURL = "https://webex.com/meet/";
                                webexURL += line.Substring(6, line.Length - 6);
                                listAlarmText.Add(webexURL);
                            }
                            else
                            {
                                listAlarmText.Add(line);
                            }
                            alarmlist.Items.Add(setTime(nHour, nMinute)[0].ToShortTimeString() + "   " + line);
                            // コンボボックスに値が入っているなら、ツールチップをセットする。
                            if (alarmlist.Items.Count != 0)
                            {
                                strTmpAlarmTxt = "";
                                for (jc = 0; jc < alarmlist.Items.Count; jc++)
                                {
                                    strTmpAlarmTxt += alarmlist.Items[jc] + "\n";
                                }
                                toolTip1.SetToolTip(alarmlist, strTmpAlarmTxt);
                            }
                        }
                        else // 読み取った文字列の初めの2文字が数値でない場合はRegularDateTimeにAddする。
                        {
                            // 上記以外の記述の場合は対象外なのでcontinue;
                            if (   line.Substring(0, 3) != "Mon" && line.Substring(0, 3) != "Tue"
                                && line.Substring(0, 3) != "Wed" && line.Substring(0, 3) != "Thu"
                                && line.Substring(0, 3) != "Fri" && line.Substring(0, 3) != "eve") continue;
                            // 月曜と書かれているが、今日が月曜でないならcontinue;
                            else if (line.Substring(0, 3) == "Mon"
                                && DateTime.Today.DayOfWeek != DayOfWeek.Monday) continue;
                            // 火曜と書かれているが、今日が火曜でないならcontinue;
                            else if (line.Substring(0, 3) == "Tue"
                                && DateTime.Today.DayOfWeek != DayOfWeek.Tuesday) continue;
                            // 水曜と書かれているが、今日が水曜でないならcontinue;
                            else if (line.Substring(0, 3) == "Wed"
                                && DateTime.Today.DayOfWeek != DayOfWeek.Wednesday) continue;
                            // 木曜と書かれているが、今日が木曜でないならcontinue;
                            else if (line.Substring(0, 3) == "Thu"
                                && DateTime.Today.DayOfWeek != DayOfWeek.Thursday) continue;
                            // 金曜と書かれているが、今日が金曜でないならcontinue;
                            else if (line.Substring(0, 3) == "Fri"
                                && DateTime.Today.DayOfWeek != DayOfWeek.Friday) continue;
                            
                            // 残りの文字列の曜日部分を切り取る。
                            line = line.Substring(findPos + 1, line.Length - findPos - 1);
                            // ":"までの文字数を取得する。
                            findPos = line.IndexOf(":");
                            // 何時なのか取得する。
                            int.TryParse(line.Substring(0, findPos), out nHour);
                            // 何分なのか取得する。
                            int.TryParse(line.Substring(findPos + 1, 2), out nMinute);
                            // 一つ目から二つ目までの文字列が時刻なので、これをRegularDateTimeに格納する。(エラーハンドリングは未実施)
                            listRegularDateTime.Add(setTime(nHour, nMinute)[0]);
                            listRegularDateTime.Add(setTime(nHour, nMinute)[1]);
                            // 二つ目の","までの文字数を取得する。
                            findPos = line.IndexOf(",");
                            // 残りの文字列の時刻部分を切り取る。
                            line = line.Substring(findPos + 1, line.Length - findPos - 1);
                            // 一応、listAlarmTextにAddする。
                            listRegularDateText.Add(line);
                            ic += 1;    // カウンタを進めるのを忘れずに
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter(AdminPath + "Schedule.csv", false, System.Text.Encoding.GetEncoding("Shift_JIS")))
                {
                    for (ic = 0; ic < strSchedlList.Count; ic++)
                    {
                        // 初めの","までの文字数を取得する。
                        findPos = strSchedlList[ic].IndexOf(",");
                        // 最初に記述されている日付が、今日の日付より前だったらいらないのでcontinue;
                        if (strSchedlList[ic].Substring(0, 2).All(char.IsDigit)
                            && DateTime.Today > DateTime.Parse(strSchedlList[ic].Substring(0, findPos))) continue;
                        //strSchedlList[ic].Substring(findPos + 1, strSchedlList[ic].Length - findPos - 1).IndexOf("\t");
                        // streamReaderのときにAddした文字列たちを書き込む。
                        sw.Write(strSchedlList[ic]);
                        // 最後の行でなければ改行する。
                        if (ic < strSchedlList.Count - 1)
                                sw.Write(Environment.NewLine);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
