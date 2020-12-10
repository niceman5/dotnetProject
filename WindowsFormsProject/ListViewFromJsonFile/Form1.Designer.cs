namespace ListViewFromJsonFile
{
    partial class frmSP
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "D:\\",
            "aaa.sql",
            "",
            ""}, -1);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comServer = new System.Windows.Forms.ComboBox();
            this.btnSpApply = new System.Windows.Forms.Button();
            this.btnSpAdd = new System.Windows.Forms.Button();
            this.btnFileSave = new System.Windows.Forms.Button();
            this.btnFileload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.GridLines = true;
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup1";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(12, 54);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 347);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "디렉토리명";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SP명";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "적용시간";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "결과";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("나눔고딕코딩", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(684, 423);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 36);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "적용서버 : ";
            // 
            // comServer
            // 
            this.comServer.FormattingEnabled = true;
            this.comServer.Items.AddRange(new object[] {
            "TEST - 서버",
            "DEV - 서버",
            "REAL - 서버"});
            this.comServer.Location = new System.Drawing.Point(92, 17);
            this.comServer.Name = "comServer";
            this.comServer.Size = new System.Drawing.Size(150, 23);
            this.comServer.TabIndex = 3;
            // 
            // btnSpApply
            // 
            this.btnSpApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpApply.Font = new System.Drawing.Font("나눔고딕코딩", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSpApply.Location = new System.Drawing.Point(574, 10);
            this.btnSpApply.Name = "btnSpApply";
            this.btnSpApply.Size = new System.Drawing.Size(104, 36);
            this.btnSpApply.TabIndex = 1;
            this.btnSpApply.Text = "SP 적용";
            this.btnSpApply.UseVisualStyleBackColor = true;
            this.btnSpApply.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSpAdd
            // 
            this.btnSpAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpAdd.Font = new System.Drawing.Font("나눔고딕코딩", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSpAdd.Location = new System.Drawing.Point(684, 10);
            this.btnSpAdd.Name = "btnSpAdd";
            this.btnSpAdd.Size = new System.Drawing.Size(104, 36);
            this.btnSpAdd.TabIndex = 1;
            this.btnSpAdd.Text = "SP 추가";
            this.btnSpAdd.UseVisualStyleBackColor = true;
            this.btnSpAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFileSave
            // 
            this.btnFileSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileSave.Font = new System.Drawing.Font("나눔고딕코딩", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFileSave.Location = new System.Drawing.Point(12, 423);
            this.btnFileSave.Name = "btnFileSave";
            this.btnFileSave.Size = new System.Drawing.Size(104, 36);
            this.btnFileSave.TabIndex = 1;
            this.btnFileSave.Text = "File Save";
            this.btnFileSave.UseVisualStyleBackColor = true;
            this.btnFileSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFileload
            // 
            this.btnFileload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileload.Font = new System.Drawing.Font("나눔고딕코딩", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFileload.Location = new System.Drawing.Point(147, 423);
            this.btnFileload.Name = "btnFileload";
            this.btnFileload.Size = new System.Drawing.Size(104, 36);
            this.btnFileload.TabIndex = 1;
            this.btnFileload.Text = "File Load";
            this.btnFileload.UseVisualStyleBackColor = true;
            this.btnFileload.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.btnFileload);
            this.Controls.Add(this.btnFileSave);
            this.Controls.Add(this.btnSpAdd);
            this.Controls.Add(this.btnSpApply);
            this.Controls.Add(this.comServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("나눔고딕코딩", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmSP";
            this.Text = "적용서버 : ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comServer;
        private System.Windows.Forms.Button btnSpApply;
        private System.Windows.Forms.Button btnSpAdd;
        private System.Windows.Forms.Button btnFileSave;
        private System.Windows.Forms.Button btnFileload;
    }
}

