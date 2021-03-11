namespace dalanqiu
{
    partial class FrmBlock
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBlock));
            this.TimerRefreshScreen = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TimerRefreshScreen
            // 
            this.TimerRefreshScreen.Interval = 15;
            this.TimerRefreshScreen.Tick += new System.EventHandler(this.TimerRefreshScreen_Tick);
            // 
            // FrmBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 515);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打篮球";
            this.Load += new System.EventHandler(this.FrmBlock_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBlock_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmBlock_KeyPress);
            //this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FrmBlock_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmBlock_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmBlock_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmBlock_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerRefreshScreen;
    }
}

