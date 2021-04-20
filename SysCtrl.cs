using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImproveWorkEfficiency
{
    /// <summary>
    /// 外部システムを制御するためのパーシャルクラス
    /// </summary>
    public partial class MainForm
    {
        private void OpenURL(string URL)
        {
            try
            {
                System.Diagnostics.Process.Start(URL);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
        /// <summary>
        /// 外部プログラムを実行する。
        /// Execute Outer Program
        /// </summary>
        /// <param name="strPGPath">実行するプログラムのパス</param>
        private int ExecuteOutPG(string strPGPath)
        {
            try
            {
                myProcess.StartInfo.FileName = strPGPath;
                myProcess.Start();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message,
                                 "例外発生",
                                 MessageBoxButtons.OK);

                return -1;
            }

            return 0;
        }
        /// <summary>
        /// テレワークに使うシステムを制御する
        /// Control TeleWork System
        /// </summary>
        /// <param name="strSysName">システム名称</param>
        /// <param name="strID">ID</param>
        /// <param name="BYTE_INFO">バイト情報</param>
        /// <param name="URL">URL</param>
        private void CtrlTWSys(string strSysName, string strID, byte[] BYTE_INFO, string URL)
        {
            SC_TglSw.Checked = false;
            if (URL != null) OpenURL(URL);
            System.Threading.Thread.Sleep(2000);
            Check_SysStrted(strSysName);
            AutoInput(strSysName, strID, BYTE_INFO);
            SC_TglSw.Checked = true;
        }
        /// <summary>
        /// システムが起動したか確認する。
        /// Check System Started
        /// </summary>
        /// <param name="strSysName">システム名称 : string System Name</param>
        private void Check_SysStrted(string strSysName)
        {
            while (true)
            {
                using (Form dummyForm = new Form())
                {
                    judge = MessageBox.Show(strSysName + "は起動しましたか？",
                                             "起動確認",
                                             MessageBoxButtons.YesNo);
                }
                if (judge == DialogResult.Yes) return;
            }
        }
        /// <summary>
        /// 情報を自動入力する。
        /// </summary>
        /// <param name="strSysName">ソフトウェア名称</param>
        /// <param name="strID">ID</param>
        /// <param name="BYTE">BYTE情報</param>
        private void AutoInput(string strSysName, string strID, byte[] BYTE)
        {
            using (WaitForm wait = new WaitForm())
            {
                MessageBox.Show(wait,
                                 strSysName + "画面の任意の部分(テキストボックス以外)をクリックしてください。",
                                 "このメッセージは" + (wait.WaitTimer.Interval * 0.001).ToString() + "秒後に自動で終了します。");
            }
            if (strID != "")
            {
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(strID);
                SendKeys.SendWait("{TAB}");
            }
            SendKeys.SendWait(WriteInfo(BYTE));
            SendKeys.SendWait("{ENTER}");
        }
        /// <summary>
        /// バイナリで指定した文字列を書き込む。
        /// </summary>
        /// <param name="bytestring"></param>
        private string WriteInfo(byte[] bytestring)
        {
            string strInfo = System.Text.Encoding.GetEncoding("shift_jis").GetString(bytestring);
            return strInfo;
        }
        /// <summary>
        /// 引数文字列の全角チェックを行う。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool IsFulLetrs(string s)
        {
            Encoding Enc = Encoding.GetEncoding("Shift-JIS");

            // 全角文字列が含まれている場合、文字数よりもバイト数の方が大きくなる。
            if (Enc.GetByteCount(s) > s.Length)
                return true;
            // 全て半角文字列の場合、文字数とバイト数は一致する。
            else
                return false;
        }
        /// <summary>
        /// プロセスを終了する。
        /// Terminate Process
        /// </summary>
        /// <param name="strPrcsName">終了させたいプロセスの名称 : Process Name</param>
        private void TrmntPrcs(string strPrcsName)
        {
            System.Diagnostics.Process[] Prcs = System.Diagnostics.Process.GetProcessesByName(strPrcsName);
            if (Prcs.Count() != 0) Prcs[0].Kill();
        }
        /// <summary>
        /// 指定されたパスをエクスプローラで開く。
        /// Explore Designated Path
        /// </summary>
        /// <param name="strPath">指定パス名</param>
        private void ExplrDsigntdPath(string strPath)
        {
            try
            {
                System.Diagnostics.Process.Start("Explorer.exe", strPath);
                TextAllDelete.PerformClick();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message,
                                 "例外発生",
                                 MessageBoxButtons.OK);
            }
        }
        private void FolderCopy(string src_str, string dest_str)
        {
            string path;
            System.IO.DirectoryInfo src_info = new System.IO.DirectoryInfo(src_str);

            // コピー元の存在をチェックする。
            if (!src_info.Exists)
            {
                MessageBox.Show("ディレクトリ" + src_str + "が存在しません。",
                                 "存在しないディレクトリ",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                return;
            }
            // コピー先のフォルダを作成する。
            System.IO.Directory.CreateDirectory(dest_str);

            // コピー元のフォルダとファイル情報を取得する。
            System.IO.DirectoryInfo[] src_folders = src_info.GetDirectories();
            System.IO.FileInfo[] src_files = src_info.GetFiles();

            // コピー元のファイルを全てコピー先のフォルダに上書きコピーする。
            foreach (System.IO.FileInfo file in src_files)
            {
                path = System.IO.Path.Combine(dest_str, file.Name);
                file.CopyTo(path, true);
            }

            // 再起呼び出しによりコピー元のフォルダを全てコピー先のフォルダにコピーする。
            foreach (System.IO.DirectoryInfo subfolder in src_folders)
            {
                path = System.IO.Path.Combine(dest_str, subfolder.Name);
                FolderCopy(subfolder.FullName, path);
            }
        }
        /// <summary>
        /// シャットダウン or 再起動のバッチファイルを作って実行する。
        /// 実行後、バッチファイルを完全に削除する。
        /// </summary>
        /// <param name="strPower">"s":シャットダウン、"r":再起動</param>
        private void ExecutePowerSourceBat(string strPower)
        {
            if (strPower == "s")
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(AdminPath + "ShutDown.bat", false, System.Text.Encoding.GetEncoding("Shift_JIS")))
                {
                    sw.Write("shutdown -s -t 0");
                }
                ExecuteOutPG(AdminPath + "ShutDown.bat");
                System.Threading.Thread.Sleep(500);
                System.IO.File.Delete(AdminPath + "ShutDown.bat");
            }
            if (strPower == "r")
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(AdminPath + "Reboot.bat", false, System.Text.Encoding.GetEncoding("Shift_JIS")))
                {
                    sw.Write("shutdown -r -t 0");
                }
                ExecuteOutPG(AdminPath + "Reboot.bat");
                System.Threading.Thread.Sleep(500);
                System.IO.File.Delete(AdminPath + "Reboot.bat");
            }
        }
        /// <summary>
        /// 予測変換でテキスト入力する。
        /// Write Predictive Transform Text
        /// </summary>
        /// <param name="strInpTxt">インプットする文字列の値</param>
        private void Write_PT_Txt(string strInpTxt)
        {
            using (WaitForm wait = new WaitForm())
            {
                judge = MessageBox.Show( wait,
                                 "テキスト入力部分をクリックしてください。",
                                 (wait.WaitTimer.Interval * 0.001).ToString() + "秒後にこのメッセージは自動終了します。",
                                 MessageBoxButtons.OKCancel);

                if (judge == DialogResult.Cancel) return;
            }
            if (strInpTxt == "yr")
            {
                SendKeys.SendWait("よろしくお願いいたします。");
            }
            else
            {
                using (Form dummyForm = new Form())
                {
                    dummyForm.TopMost = true;
                    System.Media.SystemSounds.Exclamation.Play();
                    MessageBox.Show( dummyForm,
                                     "どうやら、そのフレーズは私の辞書にはないようです。",
                                     "そのフレーズは知らない。",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                    dummyForm.TopMost = false;
                }
            }
        }
        /// <summary>
        /// 指定文字列の名称のテキストファイルに記載のweb会議室を開く。
        /// </summary>
        /// <param name="strWebMeet">web会議室名</param>
        private void OpenWebexURLFromTxt(string strWebMeet)
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("C:\\IWE_Admin\\WebMeetingURL" + "\\" + strWebMeet + ".txt", System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    string WebexURL = sr.ReadLine();
                    OpenURL(WebexURL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 定例イベント時刻通知のメッセージを表示する。
        /// Show Regular DateTime Message
        /// </summary>
        /// <param name="strScheName">定例イベント名称string Schedule Name</param>
        private void ShowRglrDTMsg(string strScheName)
        {
            string strCap = "";
            string strText = "";

            if (strScheName == "お昼休み")
            {
                strCap  = strScheName + "の時間です!!!";
                strText = strScheName + "の時間です!!!" + "\n親が死んでも食休み！" + "\nさぁさぁごはんをゆっくり食べてゆっくり休みましょう！！！";
            }
            else if (strScheName == "定時")
            {
                strCap  = strScheName + "です!!!";
                strText = strScheName + "です!!!" + "\n残業はほどほどに！" + "\nさぁ、キリのいいところで退勤してごはんを食べて寝ましょう！！！";
            }
            else
            {
                strCap  = strScheName + "の時間です!!!";
                strText = strScheName + "の時間です!!!";
            }
            using (Form dummyForm = new Form())
            {
                dummyForm.TopMost = true;
                MessageBox.Show(dummyForm,
                                 strText,
                                 strCap,
                                 MessageBoxButtons.OK);
                dummyForm.TopMost = false;
            }
        }
        /// <summary>
        /// 指定されたWebex会議室を開く。
        /// </summary>
        /// <param name="WebexInfo">URLが記載された.txtファイル名またはパーソナル会議室の個人名("h-toyotomi"や"tokugawa"等)
        ///                         必ず"webex ××"の形で受け取ることにする。</param>
        private void OpenWebex(string WebexInfo)
        {
            // "webex ××"の"××"の一部が全角である場合
            if (IsFulLetrs(WebexInfo.Substring(6, WebexInfo.Length - 6)))
            {
                // "webex ××"の"××"の部分のみ取り出し××.txtに書かれたURLを開く。
                OpenWebexURLFromTxt(WebexInfo.Substring(6, WebexInfo.Length - 6));
            }
            // webexURLが半角で直書きされている(パーソナル会議室である)場合
            else
            {
                string webexURL = "https://webex.com/meet/";
                webexURL += WebexInfo.Substring(6, WebexInfo.Length - 6);
                OpenURL(webexURL);
            }
        }
    }
}
