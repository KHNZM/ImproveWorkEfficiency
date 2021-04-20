using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace ImproveWorkEfficiency
{
    /// <summary>
    /// ボタンクリック関係の機能についてのパーシャルクラス
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        /// メモ帳ボタン押下時アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteBtn_Click(object sender, EventArgs e)
        {
            ExecuteOutPG("notepad.exe");
        }
        /// <summary>
        /// 電卓ボタン押下時アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorBtn_Click(object sender, EventArgs e)
        {
            ExecuteOutPG("calc.exe");
        }
        /// <summary>
        /// WebMeetingURLボタン押下時アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebMeetingURLBtn_Click(object sender, EventArgs e)
        {
            // テキストボックスに"webex"と記入されてたら、WebMeetingURLフォルダの.txtファイルたちを検索して選択画面に表示し、選ばれた.txtファイルに記載のURLをテキストボックスに入力する。(近日リリース)
            //string[] s = System.IO.Directory.GetFiles("C:\\IWE_Admin\\WebMeetingURL");
            ExplrDsigntdPath(@"C:\IWE_Admin\WebMeetingURL");
        }
        /// <summary>
        /// Adminボタン押下時アクション
        /// IWE_Adminフォルダにアクセスする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminButton_Click(object sender, EventArgs e)
        {
            ExplrDsigntdPath(AdminPath);
        }
        /// <summary>
        /// タスクマネージャボタン押下時アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskMgrBtn_Click(object sender, EventArgs e)
        {
            ExecuteOutPG("taskmgr.exe");
        }
        /// <summary>
        /// コマンドプロンプトボタン押下時アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBtn_Click(object sender, EventArgs e)
        {
            ExecuteOutPG("cmd.exe");
        }
        /// <summary>
        /// ペイントボタン押下時アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaintBtn_Click(object sender, EventArgs e)
        {
            ExecuteOutPG("mspaint.exe");
        }
        /// <summary>
        /// Excelボタン押下時アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelBtn_Click(object sender, EventArgs e)
        {
            ExecuteOutPG("excel.exe");
        }
        /// <summary>
        /// Wordボタン押下時アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WordBtn_Click(object sender, EventArgs e)
        {
            ExecuteOutPG("winword.exe");
        }
        /// <summary>
        /// PowerPointボタン押下時アクション
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PowerPntBtn_Click(object sender, EventArgs e)
        {
            ExecuteOutPG("powerpnt.exe");
        }
        /// <summary>
        /// SetAlarmボタン押下時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetAlarm_Click(object sender, EventArgs e)
        {
            int ic;
            int nHour = (int)hour.Value;
            int nMinute = (int)minute.Value;
            string strRecord = "";

            if (SelectedDate.Value.Date > DateTime.Today)
            {
                string strTxt = alarmtext.Text;
                if (strTxt.Contains("webex" + " "))
                {
                    // "webex "の後の文字列が半角である場合
                    if (!IsFulLetrs(strTxt.Substring(6, strTxt.Length - 6)))
                    {
                        // webexURLを生成して登録する文字列に代入する。
                        strTxt = "https://webex.com/meet/" + strTxt.Substring(6, alarmtext.Text.Length - 6);
                    }
                    // "webex "の後の文字列が全角である場合
                    else
                    {
                        // アラームテキストのリストにAddする。
                        listAlarmText.Add(alarmtext.Text);
                        // テキストボックスに入力した内容はもういらないので消す。
                        TextAllDelete.PerformClick();
                    }
                }
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(AdminPath + "Schedule.csv", true, System.Text.Encoding.GetEncoding("Shift_JIS")))
                {
                    sw.Write("\n" + SelectedDate.Value.ToShortDateString() + "," + hour.Value + ":" + minute.Value + "," + strTxt);
                }
                MessageBox.Show( "スケジュール登録しました。" + 
                    "\n\n" + "登録内容 : " + strTxt, 
                                 "登録完了",
                                 MessageBoxButtons.OK );
                alarmtext.Text = "";
                // ショートカットのトグルスイッチをオンにする。
                SC_TglSw.Checked = true;
                // 選択値を今日に戻す。
                SelectedDate.Value = DateTime.Today;
                return;
            }
            if (SelectedDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show( "過去をスケジューリングすることはできません。",
                                 "登録不能",
                                 MessageBoxButtons.OK );
                alarmtext.Text = "";
                return;
            }
            for (ic = 0; ic < listDateTime.Count; ic += 2)
            {
                if (DateTime.Parse(hour.Value.ToString() + ":" + minute.Value.ToString())
                    == listDateTime[ic])
                {
                    judge = MessageBox.Show( "その時刻さっき入力しましたね。",
                                             "重複してますよ。",
                                             MessageBoxButtons.OK);
                    return;
                }
            }

            listDateTime.Add(setTime(nHour, nMinute)[0]);
            listDateTime.Add(setTime(nHour, nMinute)[1]);
            if (alarmtext.Text != "")
            {
                alarmlist.Items.Add(setTime(nHour, nMinute)[0].ToShortTimeString() + "   " + alarmtext.Text);
            }
            else
            {
                alarmlist.Items.Add(setTime(nHour, nMinute)[0].ToShortTimeString());
            }

            for (ic = 0; ic < listDateTime.Count; ic += 2)
            {
                strRecord += "\n " + listDateTime[ic].ToShortTimeString();
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // ↓下記、"webex ××"の仕様は、アラームセットのタイミングではなく、アラーム時刻のときにURL生成等することにする。(近日リリース)//
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 例えば、テキストボックスにwebex tokugawaと入力してセットアラームすればその時間に徳川さんの会議室にアクセスする。
            if (alarmtext.Text.Contains("webex" + " "))
            {
                // "webex "の後の文字列が半角である場合
                if (!IsFulLetrs(alarmtext.Text.Substring(6, alarmtext.Text.Length - 6)))
                {
                    string webexURL = "https://webex.com/meet/";
                    // "webex ××"の"××"の部分のみ取り出してURLを作成する。("××"が"tokugawa"だったらURLはhttps://webex.com/meet/tokugawa)
                    webexURL += alarmtext.Text.Substring(6, alarmtext.Text.Length - 6);
                    // アラームテキストのリストにAddする。
                    listAlarmText.Add(webexURL);
                    // テキストボックスに入力した内容はもういらないので消す。
                    TextAllDelete.PerformClick();
                }
                // "webex "の後の文字列が全角である場合
                else
                {
                    // アラームテキストのリストにAddする。
                    listAlarmText.Add(alarmtext.Text);
                    // テキストボックスに入力した内容はもういらないので消す。
                    TextAllDelete.PerformClick();
                }
            }
            else
            {
                // アラームテキストのリストにAddする。
                listAlarmText.Add(alarmtext.Text);
            }
            if (alarmtext.Text.Contains("webex"))
            {
                // テキストボックスに入力したURLはもういらないので消す。
                TextAllDelete.PerformClick();
            }
            MessageBox.Show( "時間になったらメッセージでお知らせします！！！" + 
                             "\nセットしたテキスト：" + listAlarmText[listDateTime.Count / 2 - 1] + 
                             "\n\nアラームセット履歴" + strRecord,
                             "アラームセットしました！！！",
                             MessageBoxButtons.OK);

            SC_TglSw.Checked = true;
            // コンボボックスに値が入っているなら、ツールチップをセットする。
            if (alarmlist.Items.Count != 0)
            {
                strTmpAlarmTxt = "";
                for (ic = 0; ic < alarmlist.Items.Count; ic++)
                {
                    strTmpAlarmTxt += alarmlist.Items[ic] + "\n";
                }
                toolTip1.SetToolTip(alarmlist, strTmpAlarmTxt);
            }
        }
        /// <summary>
        /// CancelAllAlarmボタン押下時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCancel_Click(object sender, EventArgs e)
        {
            if (listDateTime.Count == 0)
            {
                judge = MessageBox.Show( "アラームセットしてませんね。",
                                         "アラームなし",
                                         MessageBoxButtons.OK);
                return;
            }
            judge = MessageBox.Show( "本当に全部消しちゃって大丈夫ですか？",
                                     "確認",
                                     MessageBoxButtons.YesNo);
            if (judge == DialogResult.Yes)
            {
                GC.Collect();
                listDateTime = new List<DateTime>();
                listAlarmText = new List<string>();
                alarmlist.Items.Clear();
                toolTip1.RemoveAll();
                judge = MessageBox.Show( "これまでのアラームを全部キャンセルしました！！！",
                                         "アラーム全キャンセル",
                                         MessageBoxButtons.OK);
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// CancelAlarmボタン押下時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelAlarm_Click(object sender, EventArgs e)
        {
            if (alarmlist.SelectedItem == null)
            {
                judge = MessageBox.Show( "キャンセルする時刻をプルダウンから選択してください。",
                                         "キャンセル時刻未選択",
                                         MessageBoxButtons.OK);
                return;
            }
            string strCancelTime = alarmlist.SelectedItem.ToString();
            DateTime cancelDateTime;
            // SelectedItemの初めの5文字 "〇〇:〇〇"をcancelDateTimeに適用する。
            if (strCancelTime.Length >= 5)
                cancelDateTime = DateTime.Parse(strCancelTime.Substring(0, 5));
            else
                cancelDateTime = DateTime.Parse(strCancelTime.Substring(0, 4));

            for (int ic = 0; ic < listDateTime.Count; ic += 2)
            {
                if (listDateTime[ic] == cancelDateTime)
                {
                    judge = MessageBox.Show( cancelDateTime.ToShortTimeString() + "のアラームをキャンセルしますよ？",
                                             "確認",
                                             MessageBoxButtons.YesNo);
                    if (judge == DialogResult.Yes)
                    {
                        listDateTime.RemoveAt(ic);
                        listDateTime.RemoveAt(ic);  // RemoveAtしてインデックスがひとつずれるので、カウンタそのままで指定時刻の1秒後のDateTimeを削除できる。
                        listAlarmText.RemoveAt(ic / 2);
                        alarmlist.Items.RemoveAt(ic / 2);

                        judge = MessageBox.Show( cancelDateTime.ToShortTimeString() + "のアラームをキャンセルしました。",
                                                 "指定時刻キャンセル完了",
                                                 MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            judge = MessageBox.Show( cancelDateTime.ToShortTimeString() + "のアラームはセットされてませんよ。",
                                     "セットされていないアラーム",
                                     MessageBoxButtons.OK);
            return;
        }
        /// <summary>
        /// テキストボックス右端の×ボタン押下時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextAllDelete_Click(object sender, EventArgs e)
        {
            if (alarmtext.Text != "")
            {
                alarmtext.Text = "";
            }
            SC_TglSw.Checked = true;
        }
    }
}
