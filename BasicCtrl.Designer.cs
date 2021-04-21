namespace ImproveWorkEfficiency
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ExcelBtn = new System.Windows.Forms.Button();
            this.NoteBtn = new System.Windows.Forms.Button();
            this.CalculatorBtn = new System.Windows.Forms.Button();
            this.TaskMgrBtn = new System.Windows.Forms.Button();
            this.cmdBtn = new System.Windows.Forms.Button();
            this.WordBtn = new System.Windows.Forms.Button();
            this.PaintBtn = new System.Windows.Forms.Button();
            this.PowerPntBtn = new System.Windows.Forms.Button();
            this.WebMeetingURLBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.TimeDisplay = new System.Windows.Forms.Label();
            this.hour = new System.Windows.Forms.NumericUpDown();
            this.minute = new System.Windows.Forms.NumericUpDown();
            this.SetAlarm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelAlarm = new System.Windows.Forms.Button();
            this.AllCancel = new System.Windows.Forms.Button();
            this.alarmlist = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.alarmtext = new System.Windows.Forms.TextBox();
            this.TextAllDelete = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SelectedDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.AdminBtn = new System.Windows.Forms.Button();
            this.PredictiveTransTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minute)).BeginInit();
            this.SuspendLayout();
            // 
            // ExcelBtn
            // 
            this.ExcelBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExcelBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.ExcelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExcelBtn.Font = new System.Drawing.Font("游明朝 Demibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.ExcelBtn.ForeColor = System.Drawing.Color.Black;
            this.ExcelBtn.Location = new System.Drawing.Point(21, 238);
            this.ExcelBtn.Name = "ExcelBtn";
            this.ExcelBtn.Size = new System.Drawing.Size(111, 43);
            this.ExcelBtn.TabIndex = 0;
            this.ExcelBtn.Text = "Excel (X)";
            this.ExcelBtn.UseVisualStyleBackColor = false;
            this.ExcelBtn.Click += new System.EventHandler(this.ExcelBtn_Click);
            // 
            // NoteBtn
            // 
            this.NoteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoteBtn.BackColor = System.Drawing.Color.White;
            this.NoteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NoteBtn.Font = new System.Drawing.Font("游明朝 Demibold", 10F, System.Drawing.FontStyle.Bold);
            this.NoteBtn.Location = new System.Drawing.Point(21, 141);
            this.NoteBtn.Name = "NoteBtn";
            this.NoteBtn.Size = new System.Drawing.Size(111, 43);
            this.NoteBtn.TabIndex = 1;
            this.NoteBtn.Text = "NotePad (N)";
            this.NoteBtn.UseVisualStyleBackColor = false;
            this.NoteBtn.Click += new System.EventHandler(this.NoteBtn_Click);
            // 
            // CalculatorBtn
            // 
            this.CalculatorBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CalculatorBtn.BackColor = System.Drawing.Color.LightSalmon;
            this.CalculatorBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CalculatorBtn.Font = new System.Drawing.Font("游明朝 Demibold", 10F, System.Drawing.FontStyle.Bold);
            this.CalculatorBtn.Location = new System.Drawing.Point(149, 141);
            this.CalculatorBtn.Name = "CalculatorBtn";
            this.CalculatorBtn.Size = new System.Drawing.Size(111, 43);
            this.CalculatorBtn.TabIndex = 2;
            this.CalculatorBtn.Text = "Calculator (C)";
            this.CalculatorBtn.UseVisualStyleBackColor = false;
            this.CalculatorBtn.Click += new System.EventHandler(this.CalculatorBtn_Click);
            // 
            // TaskMgrBtn
            // 
            this.TaskMgrBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TaskMgrBtn.BackColor = System.Drawing.Color.Bisque;
            this.TaskMgrBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TaskMgrBtn.Font = new System.Drawing.Font("游明朝 Demibold", 10F, System.Drawing.FontStyle.Bold);
            this.TaskMgrBtn.ForeColor = System.Drawing.Color.Black;
            this.TaskMgrBtn.Location = new System.Drawing.Point(275, 141);
            this.TaskMgrBtn.Name = "TaskMgrBtn";
            this.TaskMgrBtn.Size = new System.Drawing.Size(111, 43);
            this.TaskMgrBtn.TabIndex = 3;
            this.TaskMgrBtn.Text = "TaskMgr (T)";
            this.TaskMgrBtn.UseVisualStyleBackColor = false;
            this.TaskMgrBtn.Click += new System.EventHandler(this.TaskMgrBtn_Click);
            // 
            // cmdBtn
            // 
            this.cmdBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdBtn.BackColor = System.Drawing.Color.Black;
            this.cmdBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdBtn.Font = new System.Drawing.Font("游明朝 Demibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmdBtn.ForeColor = System.Drawing.Color.White;
            this.cmdBtn.Location = new System.Drawing.Point(21, 190);
            this.cmdBtn.Name = "cmdBtn";
            this.cmdBtn.Size = new System.Drawing.Size(111, 43);
            this.cmdBtn.TabIndex = 4;
            this.cmdBtn.Text = "CMD (Alt + C)";
            this.cmdBtn.UseVisualStyleBackColor = false;
            this.cmdBtn.Click += new System.EventHandler(this.cmdBtn_Click);
            // 
            // WordBtn
            // 
            this.WordBtn.BackColor = System.Drawing.Color.Blue;
            this.WordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WordBtn.Font = new System.Drawing.Font("游明朝 Demibold", 10F, System.Drawing.FontStyle.Bold);
            this.WordBtn.ForeColor = System.Drawing.Color.White;
            this.WordBtn.Location = new System.Drawing.Point(149, 238);
            this.WordBtn.Name = "WordBtn";
            this.WordBtn.Size = new System.Drawing.Size(111, 43);
            this.WordBtn.TabIndex = 5;
            this.WordBtn.Text = "Word (W)";
            this.WordBtn.UseVisualStyleBackColor = false;
            this.WordBtn.Click += new System.EventHandler(this.WordBtn_Click);
            // 
            // PaintBtn
            // 
            this.PaintBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PaintBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PaintBtn.Font = new System.Drawing.Font("游明朝 Demibold", 10F, System.Drawing.FontStyle.Bold);
            this.PaintBtn.ForeColor = System.Drawing.Color.Black;
            this.PaintBtn.Location = new System.Drawing.Point(149, 190);
            this.PaintBtn.Name = "PaintBtn";
            this.PaintBtn.Size = new System.Drawing.Size(111, 43);
            this.PaintBtn.TabIndex = 6;
            this.PaintBtn.Text = "Paint (D)";
            this.PaintBtn.UseVisualStyleBackColor = false;
            this.PaintBtn.Click += new System.EventHandler(this.PaintBtn_Click);
            // 
            // PowerPntBtn
            // 
            this.PowerPntBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(105)))), ((int)(((byte)(74)))));
            this.PowerPntBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PowerPntBtn.Font = new System.Drawing.Font("游明朝 Demibold", 10F, System.Drawing.FontStyle.Bold);
            this.PowerPntBtn.Location = new System.Drawing.Point(275, 238);
            this.PowerPntBtn.Name = "PowerPntBtn";
            this.PowerPntBtn.Size = new System.Drawing.Size(111, 43);
            this.PowerPntBtn.TabIndex = 7;
            this.PowerPntBtn.Text = "PowerPnt (P)";
            this.PowerPntBtn.UseVisualStyleBackColor = false;
            this.PowerPntBtn.Click += new System.EventHandler(this.PowerPntBtn_Click);
            // 
            // WebMeetingURLBtn
            // 
            this.WebMeetingURLBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.WebMeetingURLBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WebMeetingURLBtn.Font = new System.Drawing.Font("游明朝 Demibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.WebMeetingURLBtn.Location = new System.Drawing.Point(275, 190);
            this.WebMeetingURLBtn.Name = "WebMeetingURLBtn";
            this.WebMeetingURLBtn.Size = new System.Drawing.Size(111, 43);
            this.WebMeetingURLBtn.TabIndex = 8;
            this.WebMeetingURLBtn.Text = "WebMeeting\r\nURL (M)";
            this.WebMeetingURLBtn.UseVisualStyleBackColor = false;
            this.WebMeetingURLBtn.Click += new System.EventHandler(this.WebMeetingURLBtn_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // TimeDisplay
            // 
            this.TimeDisplay.AutoSize = true;
            this.TimeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Italic);
            this.TimeDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TimeDisplay.Location = new System.Drawing.Point(-4, 42);
            this.TimeDisplay.Name = "TimeDisplay";
            this.TimeDisplay.Size = new System.Drawing.Size(168, 44);
            this.TimeDisplay.TabIndex = 9;
            this.TimeDisplay.Text = "10:45:37";
            // 
            // hour
            // 
            this.hour.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.hour.Location = new System.Drawing.Point(259, 20);
            this.hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hour.Name = "hour";
            this.hour.Size = new System.Drawing.Size(37, 21);
            this.hour.TabIndex = 10;
            // 
            // minute
            // 
            this.minute.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.minute.Location = new System.Drawing.Point(311, 20);
            this.minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minute.Name = "minute";
            this.minute.Size = new System.Drawing.Size(37, 21);
            this.minute.TabIndex = 11;
            // 
            // SetAlarm
            // 
            this.SetAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.SetAlarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetAlarm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SetAlarm.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SetAlarm.Location = new System.Drawing.Point(308, 79);
            this.SetAlarm.Name = "SetAlarm";
            this.SetAlarm.Size = new System.Drawing.Size(68, 25);
            this.SetAlarm.TabIndex = 12;
            this.SetAlarm.Text = "SetAlarm";
            this.SetAlarm.UseVisualStyleBackColor = false;
            this.SetAlarm.Click += new System.EventHandler(this.SetAlarm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9.5F);
            this.label2.Location = new System.Drawing.Point(296, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 9.5F);
            this.label3.Location = new System.Drawing.Point(245, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "/";
            // 
            // CancelAlarm
            // 
            this.CancelAlarm.BackColor = System.Drawing.Color.Lime;
            this.CancelAlarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelAlarm.Font = new System.Drawing.Font("游明朝 Demibold", 9F, System.Drawing.FontStyle.Bold);
            this.CancelAlarm.Location = new System.Drawing.Point(149, 110);
            this.CancelAlarm.Name = "CancelAlarm";
            this.CancelAlarm.Size = new System.Drawing.Size(111, 25);
            this.CancelAlarm.TabIndex = 14;
            this.CancelAlarm.Text = "CancelAlarm";
            this.CancelAlarm.UseVisualStyleBackColor = false;
            this.CancelAlarm.Click += new System.EventHandler(this.CancelAlarm_Click);
            // 
            // AllCancel
            // 
            this.AllCancel.BackColor = System.Drawing.Color.Red;
            this.AllCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AllCancel.Font = new System.Drawing.Font("游明朝 Demibold", 9F, System.Drawing.FontStyle.Bold);
            this.AllCancel.ForeColor = System.Drawing.Color.Yellow;
            this.AllCancel.Location = new System.Drawing.Point(275, 111);
            this.AllCancel.Name = "AllCancel";
            this.AllCancel.Size = new System.Drawing.Size(111, 25);
            this.AllCancel.TabIndex = 15;
            this.AllCancel.Text = "CancelAllAlarm";
            this.AllCancel.UseVisualStyleBackColor = false;
            this.AllCancel.Click += new System.EventHandler(this.AllCancel_Click);
            // 
            // alarmlist
            // 
            this.alarmlist.BackColor = System.Drawing.Color.White;
            this.alarmlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alarmlist.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.alarmlist.ForeColor = System.Drawing.Color.Black;
            this.alarmlist.FormattingEnabled = true;
            this.alarmlist.Location = new System.Drawing.Point(195, 81);
            this.alarmlist.Name = "alarmlist";
            this.alarmlist.Size = new System.Drawing.Size(102, 21);
            this.alarmlist.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("游明朝 Demibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(136, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "AlarmList";
            // 
            // alarmtext
            // 
            this.alarmtext.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.alarmtext.Location = new System.Drawing.Point(174, 50);
            this.alarmtext.Name = "alarmtext";
            this.alarmtext.Size = new System.Drawing.Size(189, 21);
            this.alarmtext.TabIndex = 20;
            // 
            // TextAllDelete
            // 
            this.TextAllDelete.BackColor = System.Drawing.Color.White;
            this.TextAllDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextAllDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TextAllDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.TextAllDelete.FlatAppearance.BorderSize = 0;
            this.TextAllDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.TextAllDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.TextAllDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextAllDelete.Font = new System.Drawing.Font("HGP明朝E", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextAllDelete.ForeColor = System.Drawing.Color.DarkGray;
            this.TextAllDelete.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.TextAllDelete.Location = new System.Drawing.Point(347, 52);
            this.TextAllDelete.Name = "TextAllDelete";
            this.TextAllDelete.Size = new System.Drawing.Size(13, 17);
            this.TextAllDelete.TabIndex = 22;
            this.TextAllDelete.Text = "×";
            this.TextAllDelete.UseVisualStyleBackColor = false;
            this.TextAllDelete.Click += new System.EventHandler(this.TextAllDelete_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // SelectedDate
            // 
            this.SelectedDate.CalendarFont = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.SelectedDate.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.SelectedDate.Font = new System.Drawing.Font("HGS創英角ｺﾞｼｯｸUB", 10F);
            this.SelectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SelectedDate.Location = new System.Drawing.Point(145, 18);
            this.SelectedDate.Name = "SelectedDate";
            this.SelectedDate.Size = new System.Drawing.Size(100, 21);
            this.SelectedDate.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("游明朝 Demibold", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(56, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "ShortCutKey";
            // 
            // AdminBtn
            // 
            this.AdminBtn.BackColor = System.Drawing.Color.Tomato;
            this.AdminBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdminBtn.Font = new System.Drawing.Font("游明朝 Demibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.AdminBtn.Location = new System.Drawing.Point(21, 94);
            this.AdminBtn.Name = "AdminBtn";
            this.AdminBtn.Size = new System.Drawing.Size(111, 42);
            this.AdminBtn.TabIndex = 26;
            this.AdminBtn.Text = "Admin (Alt+A)";
            this.AdminBtn.UseVisualStyleBackColor = false;
            this.AdminBtn.Click += new System.EventHandler(this.AdminButton_Click);
            // 
            // PredictiveTransTimer
            // 
            this.PredictiveTransTimer.Enabled = true;
            this.PredictiveTransTimer.Tick += new System.EventHandler(this.PredictiveTransTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(408, 299);
            this.Controls.Add(this.AdminBtn);
            this.Controls.Add(this.alarmlist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minute);
            this.Controls.Add(this.hour);
            this.Controls.Add(this.SelectedDate);
            this.Controls.Add(this.TextAllDelete);
            this.Controls.Add(this.alarmtext);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AllCancel);
            this.Controls.Add(this.CancelAlarm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SetAlarm);
            this.Controls.Add(this.WebMeetingURLBtn);
            this.Controls.Add(this.PowerPntBtn);
            this.Controls.Add(this.PaintBtn);
            this.Controls.Add(this.WordBtn);
            this.Controls.Add(this.cmdBtn);
            this.Controls.Add(this.TaskMgrBtn);
            this.Controls.Add(this.CalculatorBtn);
            this.Controls.Add(this.NoteBtn);
            this.Controls.Add(this.ExcelBtn);
            this.Controls.Add(this.TimeDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ImproveWorkEfficiency";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExcelBtn;
        private System.Windows.Forms.Button NoteBtn;
        private System.Windows.Forms.Button CalculatorBtn;
        private System.Windows.Forms.Button TaskMgrBtn;
        private System.Windows.Forms.Button cmdBtn;
        private System.Windows.Forms.Button WordBtn;
        private System.Windows.Forms.Button PaintBtn;
        private System.Windows.Forms.Button PowerPntBtn;
        private System.Windows.Forms.Button WebMeetingURLBtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label TimeDisplay;
        private System.Windows.Forms.NumericUpDown hour;
        private System.Windows.Forms.NumericUpDown minute;
        private System.Windows.Forms.Button SetAlarm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelAlarm;
        private System.Windows.Forms.Button AllCancel;
        private System.Windows.Forms.ComboBox alarmlist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox alarmtext;
        private System.Windows.Forms.Button TextAllDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker SelectedDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AdminBtn;
        private System.Windows.Forms.Timer PredictiveTransTimer;
    }
}

