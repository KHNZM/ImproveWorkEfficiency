using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace ImproveWorkEfficiency
{
    /// <summary>
    /// 時間を扱う機能についてのパーシャルクラス
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        /// タイマーカウント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            //TimeDisplayで常に時間を表示する
            TimeDisplay.Text = DateTime.Now.ToLongTimeString();
            TimeDisplay.Width = 24;

            for (int ic = 0; ic < listRegularDateText.Count; ic++)
            {
                if (DateTime.Now >= listRegularDateTime[2 * ic]
                    && DateTime.Now < listRegularDateTime[2 * ic + 1])
                {
                    if (listRegularDateText[ic].Contains("webex"))
                    {
                        // "webex ××"の"××"の部分のみ取り出し××.txtに書かれたURLを開く。
                        OpenWebexURLFromTxt(listRegularDateText[ic].Substring(6, listRegularDateText[ic].Length - 6));
                    }
                    // スケジューリングされた時間であることをお知らせする。
                    ShowRglrDTMsg(listRegularDateText[ic]);
                }
            }
            // 指定アラーム時刻
            if (listDateTime.Count > 0)
            {
                for (int ic = 0; ic < listDateTime.Count; ic += 2)
                {
                    if (listDateTime.Count > 0
                        && DateTime.Now >= listDateTime[ic]
                        && DateTime.Now < listDateTime[ic + 1])
                    {
                        using (Form dummyForm = new Form())
                        {
                            dummyForm.TopMost = true;
                            if (listAlarmText[ic / 2].Contains("webex"))  // webexのURLが入力されている場合は、そのURLをブラウザで開く。
                            {
                                // "webex ××"の"××"の一部が全角である場合
                                if (IsFulLetrs(listAlarmText[ic / 2].Substring(6, listAlarmText[ic / 2].Length - 6)))
                                {
                                    // "webex ××"の"××"の部分のみ取り出し××.txtに書かれたURLを開く。
                                    OpenWebexURLFromTxt(listAlarmText[ic / 2].Substring(6, listAlarmText[ic / 2].Length - 6));
                                }
                                // webexURLが半角で直書きされている(パーソナル会議室である)場合
                                else
                                {
                                    OpenURL(listAlarmText[ic / 2]);
                                }
                            }
                            System.Media.SystemSounds.Asterisk.Play();
                            MessageBox.Show( dummyForm,
                                             "時間です！！！" + "\n\n" + listAlarmText[ic / 2],
                                             "時間です！！！",
                                             MessageBoxButtons.OK);
                            dummyForm.TopMost = false;
                        }
                        listDateTime.RemoveAt(ic);
                        listDateTime.RemoveAt(ic);
                        listAlarmText.RemoveAt(ic / 2);
                        alarmlist.Items.RemoveAt(ic / 2);
                    }
                }
            }
        }
        /// <summary>
        /// 予測変換タイマーのカウント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PredictiveTransTimer_Tick(object sender, EventArgs e)
        {
            if (alarmtext.Text != "")
            {
                if (alarmtext.Text == "now")
                {
                    alarmtext.Text = "";
                    SendKeys.SendWait("webex now ");
                }
                else if (alarmtext.Text == "we")
                {
                    alarmtext.Text = "";
                    SendKeys.SendWait("webex ");
                }
            }
            
        }
        /// <summary>
        /// 指定時刻をセットする。
        /// </summary>
        /// <param name="nHour">時</param>
        /// <param name="nMinute">分</param>
        /// <returns></returns>
        private DateTime[] setTime(int nHour, int nMinute)
        {
            string[] strTime = new string[2];
            DateTime[] datetime = new DateTime[2];

            strTime[0] = nHour.ToString() + ":" + nMinute.ToString() + ":" + "00";
            strTime[1] = nHour.ToString() + ":" + nMinute.ToString() + ":" + "01";

            datetime[0] = DateTime.Parse(strTime[0]);
            datetime[1] = DateTime.Parse(strTime[1]);

            return datetime;
        }
    }
}
