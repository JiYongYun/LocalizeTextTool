namespace LocalizeTextTool
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.addLocTypeBtn = new System.Windows.Forms.Button();
            this.textClearBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalOpenBtn = new System.Windows.Forms.Button();
            this.totalSaveBtn = new System.Windows.Forms.Button();
            this.allSaveBtn = new System.Windows.Forms.Button();
            this.findBtn = new System.Windows.Forms.Button();
            this.listViewEx1 = new CustomListView.ListViewEx();
            this.Key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 88);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(6, 114);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(120, 23);
            this.openBtn.TabIndex = 3;
            this.openBtn.Text = "열기(O)";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(6, 143);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(120, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "저장(S)";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // addLocTypeBtn
            // 
            this.addLocTypeBtn.Enabled = false;
            this.addLocTypeBtn.Location = new System.Drawing.Point(6, 172);
            this.addLocTypeBtn.Name = "addLocTypeBtn";
            this.addLocTypeBtn.Size = new System.Drawing.Size(120, 23);
            this.addLocTypeBtn.TabIndex = 5;
            this.addLocTypeBtn.Text = "추가";
            this.addLocTypeBtn.UseVisualStyleBackColor = true;
            this.addLocTypeBtn.UseWaitCursor = true;
            this.addLocTypeBtn.Click += new System.EventHandler(this.addLocTypeBtn_Click);
            // 
            // textClearBtn
            // 
            this.textClearBtn.Location = new System.Drawing.Point(18, 345);
            this.textClearBtn.Name = "textClearBtn";
            this.textClearBtn.Size = new System.Drawing.Size(120, 23);
            this.textClearBtn.TabIndex = 6;
            this.textClearBtn.Text = "텍스츠 초기화(R)";
            this.textClearBtn.UseVisualStyleBackColor = true;
            this.textClearBtn.Click += new System.EventHandler(this.delLocalTypeBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.openBtn);
            this.groupBox1.Controls.Add(this.addLocTypeBtn);
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 210);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "국가별";
            // 
            // totalOpenBtn
            // 
            this.totalOpenBtn.Location = new System.Drawing.Point(18, 12);
            this.totalOpenBtn.Name = "totalOpenBtn";
            this.totalOpenBtn.Size = new System.Drawing.Size(120, 23);
            this.totalOpenBtn.TabIndex = 8;
            this.totalOpenBtn.Text = "통합파일 열기(E)";
            this.totalOpenBtn.UseVisualStyleBackColor = true;
            this.totalOpenBtn.Click += new System.EventHandler(this.totalOpenBtn_Click);
            // 
            // totalSaveBtn
            // 
            this.totalSaveBtn.Location = new System.Drawing.Point(18, 41);
            this.totalSaveBtn.Name = "totalSaveBtn";
            this.totalSaveBtn.Size = new System.Drawing.Size(120, 23);
            this.totalSaveBtn.TabIndex = 9;
            this.totalSaveBtn.Text = "통합파일 저장(W)";
            this.totalSaveBtn.UseVisualStyleBackColor = true;
            this.totalSaveBtn.Click += new System.EventHandler(this.totalSaveBtn_Click);
            // 
            // allSaveBtn
            // 
            this.allSaveBtn.Location = new System.Drawing.Point(18, 316);
            this.allSaveBtn.Name = "allSaveBtn";
            this.allSaveBtn.Size = new System.Drawing.Size(120, 23);
            this.allSaveBtn.TabIndex = 6;
            this.allSaveBtn.Text = "모두 저장(A)";
            this.allSaveBtn.UseVisualStyleBackColor = true;
            this.allSaveBtn.Click += new System.EventHandler(this.allSaveBtn_Click);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(18, 396);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(120, 23);
            this.findBtn.TabIndex = 10;
            this.findBtn.Text = "찾기 / 바꾸기(F)";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // listViewEx1
            // 
            this.listViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Key});
            this.listViewEx1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewEx1.FullRowSelect = true;
            this.listViewEx1.GridLines = true;
            this.listViewEx1.LabelEdit = true;
            this.listViewEx1.Location = new System.Drawing.Point(154, 12);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(993, 568);
            this.listViewEx1.TabIndex = 1;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            this.listViewEx1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewEx1_ItemSelectionChanged);
            // 
            // Key
            // 
            this.Key.Text = "Key";
            this.Key.Width = 249;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1159, 592);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.allSaveBtn);
            this.Controls.Add(this.totalSaveBtn);
            this.Controls.Add(this.totalOpenBtn);
            this.Controls.Add(this.listViewEx1);
            this.Controls.Add(this.textClearBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addLocTypeBtn;
        private System.Windows.Forms.Button textClearBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomListView.ListViewEx listViewEx1;
        private System.Windows.Forms.ColumnHeader Key;
        private System.Windows.Forms.Button totalOpenBtn;
        private System.Windows.Forms.Button totalSaveBtn;
        private System.Windows.Forms.Button allSaveBtn;
        private System.Windows.Forms.Button findBtn;
    }
}

