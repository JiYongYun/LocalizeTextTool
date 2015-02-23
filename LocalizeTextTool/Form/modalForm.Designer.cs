namespace LocalizeTextTool
{
    partial class ModalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.findBtn = new System.Windows.Forms.Button();
            this.changeBtn = new System.Windows.Forms.Button();
            this.allChangeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.changeTextBox = new System.Windows.Forms.TextBox();
            this.fontTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.cancleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // findBtn
            // 
            this.findBtn.Enabled = false;
            this.findBtn.Location = new System.Drawing.Point(401, 12);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(112, 28);
            this.findBtn.TabIndex = 0;
            this.findBtn.Text = "다음 찾기";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // changeBtn
            // 
            this.changeBtn.Enabled = false;
            this.changeBtn.Location = new System.Drawing.Point(401, 41);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(112, 28);
            this.changeBtn.TabIndex = 1;
            this.changeBtn.Text = "바꾸기";
            this.changeBtn.UseVisualStyleBackColor = true;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // allChangeBtn
            // 
            this.allChangeBtn.Location = new System.Drawing.Point(401, 70);
            this.allChangeBtn.Name = "allChangeBtn";
            this.allChangeBtn.Size = new System.Drawing.Size(112, 28);
            this.allChangeBtn.TabIndex = 2;
            this.allChangeBtn.Text = "모두 바꾸기";
            this.allChangeBtn.UseVisualStyleBackColor = true;
            this.allChangeBtn.Click += new System.EventHandler(this.allChangeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "찾을 내용 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "바꿀 내용 :";
            // 
            // findTextBox
            // 
            this.findTextBox.Location = new System.Drawing.Point(92, 13);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(286, 21);
            this.findTextBox.TabIndex = 5;
            // 
            // changeTextBox
            // 
            this.changeTextBox.Location = new System.Drawing.Point(92, 49);
            this.changeTextBox.Name = "changeTextBox";
            this.changeTextBox.Size = new System.Drawing.Size(286, 21);
            this.changeTextBox.TabIndex = 6;
            // 
            // fontTypeCheckBox
            // 
            this.fontTypeCheckBox.AutoSize = true;
            this.fontTypeCheckBox.Enabled = false;
            this.fontTypeCheckBox.Location = new System.Drawing.Point(19, 99);
            this.fontTypeCheckBox.Name = "fontTypeCheckBox";
            this.fontTypeCheckBox.Size = new System.Drawing.Size(106, 16);
            this.fontTypeCheckBox.TabIndex = 7;
            this.fontTypeCheckBox.Text = "대/소문자 구분";
            this.fontTypeCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancleBtn
            // 
            this.cancleBtn.Location = new System.Drawing.Point(401, 99);
            this.cancleBtn.Name = "cancleBtn";
            this.cancleBtn.Size = new System.Drawing.Size(112, 28);
            this.cancleBtn.TabIndex = 8;
            this.cancleBtn.Text = "취소";
            this.cancleBtn.UseVisualStyleBackColor = true;
            this.cancleBtn.Click += new System.EventHandler(this.cancleBtn_Click);
            // 
            // ModalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 141);
            this.Controls.Add(this.cancleBtn);
            this.Controls.Add(this.fontTypeCheckBox);
            this.Controls.Add(this.changeTextBox);
            this.Controls.Add(this.findTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allChangeBtn);
            this.Controls.Add(this.changeBtn);
            this.Controls.Add(this.findBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModalForm";
            this.Text = "찾기/ 바꾸기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Button changeBtn;
        private System.Windows.Forms.Button allChangeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.TextBox changeTextBox;
        private System.Windows.Forms.CheckBox fontTypeCheckBox;
        private System.Windows.Forms.Button cancleBtn;
    }
}