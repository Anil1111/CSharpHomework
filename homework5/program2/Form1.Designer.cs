namespace program2
{
    partial class Form1
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
            this.drawButton = new System.Windows.Forms.Button();
            this.ratioText = new System.Windows.Forms.TextBox();
            this.ratioLabel = new System.Windows.Forms.Label();
            this.th1Label = new System.Windows.Forms.Label();
            this.th1Text = new System.Windows.Forms.TextBox();
            this.th2Text = new System.Windows.Forms.TextBox();
            this.th2Label = new System.Windows.Forms.Label();
            this.per2Text = new System.Windows.Forms.TextBox();
            this.per2Label = new System.Windows.Forms.Label();
            this.per1Text = new System.Windows.Forms.TextBox();
            this.per1Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // drawButton
            // 
            this.drawButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drawButton.AutoSize = true;
            this.drawButton.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.drawButton.Location = new System.Drawing.Point(846, 12);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(100, 39);
            this.drawButton.TabIndex = 0;
            this.drawButton.Text = "draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.StartDrawing);
            // 
            // ratioText
            // 
            this.ratioText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ratioText.Location = new System.Drawing.Point(848, 69);
            this.ratioText.Name = "ratioText";
            this.ratioText.Size = new System.Drawing.Size(100, 25);
            this.ratioText.TabIndex = 1;
            this.ratioText.Text = this.ratio.ToString();
            //this.ratioText.TextChanged += new System.EventHandler(this.ratioText_TextChanged);
            // 
            // ratioLabel
            // 
            this.ratioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ratioLabel.AutoSize = true;
            this.ratioLabel.Location = new System.Drawing.Point(730, 79);
            this.ratioLabel.Name = "ratioLabel";
            this.ratioLabel.Size = new System.Drawing.Size(112, 15);
            this.ratioLabel.TabIndex = 2;
            this.ratioLabel.Text = "输入分支比例：";
            // 
            // th1Label
            // 
            this.th1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.th1Label.AutoSize = true;
            this.th1Label.Location = new System.Drawing.Point(752, 119);
            this.th1Label.Name = "th1Label";
            this.th1Label.Size = new System.Drawing.Size(90, 15);
            this.th1Label.TabIndex = 3;
            this.th1Label.Text = "分支1角度：";
            
            // 
            // th1Text
            // 
            this.th1Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.th1Text.Location = new System.Drawing.Point(848, 109);
            this.th1Text.Name = "th1Text";
            this.th1Text.Text = th1.ToString();
            this.th1Text.Size = new System.Drawing.Size(100, 25);
            this.th1Text.TabIndex = 4;
            //this.th1Text.TextChanged += new System.EventHandler(this.th1Text_TextChanged);
            // 
            // th2Text
            // 
            this.th2Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.th2Text.Location = new System.Drawing.Point(848, 149);
            this.th2Text.Name = "th2Text";
            this.th2Text.Text = th2.ToString();
            this.th2Text.Size = new System.Drawing.Size(100, 25);
            this.th2Text.TabIndex = 6;
            //this.th2Text.TextChanged += new System.EventHandler(this.th2Text_TextChanged);
            // 
            // th2Label
            // 
            this.th2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.th2Label.AutoSize = true;
            this.th2Label.Location = new System.Drawing.Point(752, 159);
            this.th2Label.Name = "th2Label";
            this.th2Label.Size = new System.Drawing.Size(90, 15);
            this.th2Label.TabIndex = 5;
            this.th2Label.Text = "分支2角度：";
           // this.th2Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // per2Text
            // 
            this.per2Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.per2Text.Location = new System.Drawing.Point(848, 234);
            this.per2Text.Name = "per2Text";
            this.per2Text.Text = per2.ToString();
            this.per2Text.Size = new System.Drawing.Size(100, 25);
            this.per2Text.TabIndex = 8;
            //this.per2Text.TextChanged += new System.EventHandler(this.per2Text_TextChanged);
            // 
            // per2Label
            // 
            this.per2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.per2Label.AutoSize = true;
            this.per2Label.Location = new System.Drawing.Point(752, 244);
            this.per2Label.Name = "per2Label";
            this.per2Label.Size = new System.Drawing.Size(90, 15);
            this.per2Label.TabIndex = 7;
            this.per2Label.Text = "分支2衰减：";
            //this.per2Label.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // per1Text
            // 
            this.per1Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.per1Text.Location = new System.Drawing.Point(848, 191);
            this.per1Text.Name = "per1Text";
            this.per1Text.Text = per1.ToString();
            this.per1Text.Size = new System.Drawing.Size(100, 25);
            this.per1Text.TabIndex = 10;
            //this.per1Text.TextChanged += new System.EventHandler(this.per1Text_TextChanged);
            // 
            // per1Label
            // 
            this.per1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.per1Label.AutoSize = true;
            this.per1Label.Location = new System.Drawing.Point(752, 201);
            this.per1Label.Name = "per1Label";
            this.per1Label.Size = new System.Drawing.Size(90, 15);
            this.per1Label.TabIndex = 9;
            this.per1Label.Text = "分支1衰减：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 452);
            this.Controls.Add(this.per1Text);
            this.Controls.Add(this.per1Label);
            this.Controls.Add(this.per2Text);
            this.Controls.Add(this.per2Label);
            this.Controls.Add(this.th2Text);
            this.Controls.Add(this.th2Label);
            this.Controls.Add(this.th1Text);
            this.Controls.Add(this.th1Label);
            this.Controls.Add(this.ratioLabel);
            this.Controls.Add(this.ratioText);
            this.Controls.Add(this.drawButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TextBox ratioText;
        private System.Windows.Forms.Label ratioLabel;
        private System.Windows.Forms.Label th1Label;
        private System.Windows.Forms.TextBox th1Text;
        private System.Windows.Forms.TextBox th2Text;
        private System.Windows.Forms.Label th2Label;
        private System.Windows.Forms.TextBox per2Text;
        private System.Windows.Forms.Label per2Label;
        private System.Windows.Forms.TextBox per1Text;
        private System.Windows.Forms.Label per1Label;
    }
}

