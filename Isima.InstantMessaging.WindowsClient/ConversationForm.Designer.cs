namespace Isima.InstantMessaging.WindowsClient
{
    partial class ConversationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConversationForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextConv = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sendText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextConv);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.sendText);
            this.splitContainer1.Size = new System.Drawing.Size(284, 262);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 0;
            // 
            // richTextConv
            // 
            this.richTextConv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextConv.BackColor = System.Drawing.SystemColors.Control;
            this.richTextConv.Enabled = false;
            this.richTextConv.Location = new System.Drawing.Point(4, 3);
            this.richTextConv.Name = "richTextConv";
            this.richTextConv.ReadOnly = true;
            this.richTextConv.Size = new System.Drawing.Size(277, 193);
            this.richTextConv.TabIndex = 0;
            this.richTextConv.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(217, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 64);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // sendText
            // 
            this.sendText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendText.Location = new System.Drawing.Point(3, 2);
            this.sendText.Multiline = true;
            this.sendText.Name = "sendText";
            this.sendText.Size = new System.Drawing.Size(214, 61);
            this.sendText.TabIndex = 0;
            // 
            // ConversationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConversationForm";
            this.Text = "ConversationForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox sendText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextConv;
    }
}