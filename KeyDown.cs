using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace ImproveWorkEfficiency
{
    /// <summary>
    /// ショートカットキー入力関係の機能についてのパーシャルクラス
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        /// キーダウンイベントメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (alarmtext.Text.Contains("webex now "))
                {
                    OpenWebex(alarmtext.Text.Substring(0, 6) + alarmtext.Text.Substring(10, alarmtext.Text.Length - 10));
                    TextAllDelete.PerformClick();
                }
                else if (alarmtext.Text == "cp")      // テキストボックスに"cp"と入力してEnterキーを押すとフォルダ「編集後、自席PCへコピーする」を開く。
                {
                    cmdBtn.PerformClick();
                }
                // テキストボックスに特に入力がないもしくは、関係のないテキストが入力されている場合にEnterキーを押すと、SetAlarmボタン押下時イベントが発生する。
                else
                {
                    SetAlarm.PerformClick();
                }
            }
            // Ctrlキー押下でショートカットキー有効/無効のチェックボックスを切り替える。
            else if (e.KeyCode == Keys.ControlKey)
            {
                if (SC_TglSw.Checked) SC_TglSw.Checked = false;
                else SC_TglSw.Checked = true;
            }
            // チェックボックスが無効になっていたらキーダウンイベント終了
            else if (!SC_TglSw.Checked) return;
            // Altキー + 'A'キー押下でIWE_Adminフォルダを開く。
            else if (e.Alt && e.KeyCode == Keys.A)
                AdminBtn.PerformClick();
            // 'N'キー押下でメモ帳を起動する。
            else if (e.KeyCode == Keys.N)
                NoteBtn.PerformClick();
            // 'C'キー押下で電卓を起動する。
            else if (e.KeyCode == Keys.C)
                CalculatorBtn.PerformClick();
            // 'O'キー押下でOffice(Excel/Word/PowerPoint)を開く。
            else if (e.KeyCode == Keys.O)
                TaskMgrBtn.PerformClick();
            // 'W'キー押下でWebMeetingURLを開く。
            else if (e.KeyCode == Keys.W)
                WebMeetingURLBtn.PerformClick();
            // 'R'キー押下でリモートデスクトップ接続を行う。
            else if (e.KeyCode == Keys.R)
                ExecuteOutPG("mstsc.exe");
            // 'T'キー押下でタスクマネージャを起動する。
            else if (e.KeyCode == Keys.T)
                ExecuteOutPG("taskmgr.exe");
            // Escapeキー押下で端末をシャットダウンまたは再起動する。
            else if (e.KeyCode == Keys.Escape)
            {
                judge = MessageBox.Show("はい：シャットダウン\nいいえ：再起動\nキャンセル：操作取り消し", "確認",
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question);

                if (judge == DialogResult.Yes)
                {
                    bShuttingDwn = true;
                    ExecutePowerSourceBat("s");
                    Close();
                }
                if (judge == DialogResult.No)
                {
                    bShuttingDwn = true;
                    ExecutePowerSourceBat("r");
                    Close();
                }
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                Write_PT_Txt(alarmtext.Text);
                TextAllDelete.PerformClick();
            }
            else if (e.KeyCode == Keys.Back)
                TextAllDelete.PerformClick();
            // Deleteキー押下でプログラムを終了する。
            else if (e.KeyCode == Keys.Delete) Close();
        }
    }
}
