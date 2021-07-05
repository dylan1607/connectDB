namespace Get_Drawing
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cb_Type_Drawing = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chb_Inspec = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.imageBtn = new System.Windows.Forms.ImageList(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.chb_press = new System.Windows.Forms.CheckBox();
            this.chb_mold = new System.Windows.Forms.CheckBox();
            this.chb_guide = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(257, 7);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(277, 44);
            this.txt_Search.TabIndex = 0;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            this.txt_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1148, 480);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cb_Type_Drawing
            // 
            this.cb_Type_Drawing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Type_Drawing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Type_Drawing.FormattingEnabled = true;
            this.cb_Type_Drawing.Location = new System.Drawing.Point(12, 16);
            this.cb_Type_Drawing.Name = "cb_Type_Drawing";
            this.cb_Type_Drawing.Size = new System.Drawing.Size(239, 28);
            this.cb_Type_Drawing.TabIndex = 4;
            this.cb_Type_Drawing.SelectedIndexChanged += new System.EventHandler(this.cb_Type_Drawing_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(1041, 9);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(119, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(540, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "CLEAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            // 
            // chb_Inspec
            // 
            this.chb_Inspec.AutoSize = true;
            this.chb_Inspec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_Inspec.Location = new System.Drawing.Point(640, 33);
            this.chb_Inspec.Name = "chb_Inspec";
            this.chb_Inspec.Size = new System.Drawing.Size(154, 20);
            this.chb_Inspec.TabIndex = 10;
            this.chb_Inspec.Text = "Search INSPECTION";
            this.chb_Inspec.UseVisualStyleBackColor = true;
            this.chb_Inspec.CheckedChanged += new System.EventHandler(this.chb_Inspec_CheckedChanged);
            // 
            // button2
            // 
            this.button2.ImageIndex = 1;
            this.button2.ImageList = this.imageBtn;
            this.button2.Location = new System.Drawing.Point(601, 545);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 20);
            this.button2.TabIndex = 11;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // imageBtn
            // 
            this.imageBtn.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageBtn.ImageStream")));
            this.imageBtn.TransparentColor = System.Drawing.Color.Transparent;
            this.imageBtn.Images.SetKeyName(0, "1494080783_icon-skip-backward.ico");
            this.imageBtn.Images.SetKeyName(1, "1494080804_icon-skip-forward.ico");
            // 
            // button3
            // 
            this.button3.ImageKey = "1494080783_icon-skip-backward.ico";
            this.button3.ImageList = this.imageBtn;
            this.button3.Location = new System.Drawing.Point(545, 545);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 20);
            this.button3.TabIndex = 12;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(877, 7);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.ReadOnly = true;
            this.txtBoxPath.Size = new System.Drawing.Size(283, 20);
            this.txtBoxPath.TabIndex = 13;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(877, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 25);
            this.button4.TabIndex = 14;
            this.button4.Text = "Browse Folder To Copy Image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(1059, 30);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(101, 23);
            this.btnCopyAll.TabIndex = 15;
            this.btnCopyAll.Text = "Copy All";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Visible = false;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // chb_press
            // 
            this.chb_press.AutoSize = true;
            this.chb_press.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_press.Location = new System.Drawing.Point(640, 7);
            this.chb_press.Name = "chb_press";
            this.chb_press.Size = new System.Drawing.Size(73, 20);
            this.chb_press.TabIndex = 16;
            this.chb_press.Text = "PRESS";
            this.chb_press.UseVisualStyleBackColor = true;
            this.chb_press.CheckedChanged += new System.EventHandler(this.chb_press_CheckedChanged);
            // 
            // chb_mold
            // 
            this.chb_mold.AutoSize = true;
            this.chb_mold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_mold.Location = new System.Drawing.Point(724, 7);
            this.chb_mold.Name = "chb_mold";
            this.chb_mold.Size = new System.Drawing.Size(65, 20);
            this.chb_mold.TabIndex = 17;
            this.chb_mold.Text = "MOLD";
            this.chb_mold.UseVisualStyleBackColor = true;
            this.chb_mold.CheckedChanged += new System.EventHandler(this.chb_mold_CheckedChanged);
            // 
            // chb_guide
            // 
            this.chb_guide.AutoSize = true;
            this.chb_guide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_guide.Location = new System.Drawing.Point(803, 7);
            this.chb_guide.Name = "chb_guide";
            this.chb_guide.Size = new System.Drawing.Size(69, 20);
            this.chb_guide.TabIndex = 18;
            this.chb_guide.Text = "GUIDE";
            this.chb_guide.UseVisualStyleBackColor = true;
            this.chb_guide.CheckedChanged += new System.EventHandler(this.chb_guide_CheckedChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(610, 59);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(550, 480);
            this.dataGridView2.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1172, 572);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.chb_guide);
            this.Controls.Add(this.chb_mold);
            this.Controls.Add(this.chb_press);
            this.Controls.Add(this.btnCopyAll);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtBoxPath);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chb_Inspec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_Type_Drawing);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FIND & PRINT SCANNED DRAWING";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cb_Type_Drawing;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chb_Inspec;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList imageBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnCopyAll;
        private System.Windows.Forms.CheckBox chb_press;
        private System.Windows.Forms.CheckBox chb_mold;
        private System.Windows.Forms.CheckBox chb_guide;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}

