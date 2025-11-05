namespace GameCaro
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
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.pnlPicture = new System.Windows.Forms.Panel();
            this.ptrbAvatar = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.prcbCoolDown = new System.Windows.Forms.ProgressBar();
            this.lblGame = new System.Windows.Forms.Label();
            this.btnLan = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.pctbMark = new System.Windows.Forms.PictureBox();
            this.txbPlayerName = new System.Windows.Forms.TextBox();
            this.tmCoolDown = new System.Windows.Forms.Timer(this.components);
            this.pnlPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptrbAvatar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChessBoard.Location = new System.Drawing.Point(3, 6);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(800, 745);
            this.pnlChessBoard.TabIndex = 0;
            // 
            // pnlPicture
            // 
            this.pnlPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPicture.Controls.Add(this.ptrbAvatar);
            this.pnlPicture.Location = new System.Drawing.Point(809, 6);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(379, 385);
            this.pnlPicture.TabIndex = 1;
            // 
            // ptrbAvatar
            // 
            this.ptrbAvatar.BackColor = System.Drawing.SystemColors.Control;
            this.ptrbAvatar.BackgroundImage = global::GameCaro.Properties.Resources.game_caro_image;
            this.ptrbAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptrbAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptrbAvatar.Image = global::GameCaro.Properties.Resources.game_caro_image;
            this.ptrbAvatar.Location = new System.Drawing.Point(0, 0);
            this.ptrbAvatar.Name = "ptrbAvatar";
            this.ptrbAvatar.Size = new System.Drawing.Size(379, 385);
            this.ptrbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptrbAvatar.TabIndex = 0;
            this.ptrbAvatar.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.prcbCoolDown);
            this.panel3.Controls.Add(this.lblGame);
            this.panel3.Controls.Add(this.btnLan);
            this.panel3.Controls.Add(this.txtIP);
            this.panel3.Controls.Add(this.pctbMark);
            this.panel3.Controls.Add(this.txbPlayerName);
            this.panel3.Location = new System.Drawing.Point(809, 397);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 258);
            this.panel3.TabIndex = 2;
            // 
            // prcbCoolDown
            // 
            this.prcbCoolDown.Location = new System.Drawing.Point(4, 44);
            this.prcbCoolDown.Name = "prcbCoolDown";
            this.prcbCoolDown.Size = new System.Drawing.Size(202, 23);
            this.prcbCoolDown.TabIndex = 6;
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Font = new System.Drawing.Font("Impact", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGame.Location = new System.Drawing.Point(58, 185);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(268, 41);
            this.lblGame.TabIndex = 5;
            this.lblGame.Text = "5 in a line to Win!";
            // 
            // btnLan
            // 
            this.btnLan.Location = new System.Drawing.Point(3, 119);
            this.btnLan.Name = "btnLan";
            this.btnLan.Size = new System.Drawing.Size(203, 23);
            this.btnLan.TabIndex = 4;
            this.btnLan.Text = "LAN";
            this.btnLan.UseVisualStyleBackColor = true;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(0, 83);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(206, 22);
            this.txtIP.TabIndex = 3;
            this.txtIP.Text = "192.168.2.8";
            // 
            // pctbMark
            // 
            this.pctbMark.BackColor = System.Drawing.SystemColors.Control;
            this.pctbMark.Location = new System.Drawing.Point(224, 3);
            this.pctbMark.Name = "pctbMark";
            this.pctbMark.Size = new System.Drawing.Size(155, 139);
            this.pctbMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbMark.TabIndex = 2;
            this.pctbMark.TabStop = false;
            // 
            // txbPlayerName
            // 
            this.txbPlayerName.Location = new System.Drawing.Point(0, 3);
            this.txbPlayerName.Name = "txbPlayerName";
            this.txbPlayerName.ReadOnly = true;
            this.txbPlayerName.Size = new System.Drawing.Size(206, 22);
            this.txbPlayerName.TabIndex = 0;
            // 
            // tmCoolDown
            // 
            this.tmCoolDown.Tick += new System.EventHandler(this.tmCoolDown_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 753);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlPicture);
            this.Controls.Add(this.pnlChessBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Game Caro LAN";
            this.pnlPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptrbAvatar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.Panel pnlPicture;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLan;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.PictureBox pctbMark;
        private System.Windows.Forms.TextBox txbPlayerName;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.ProgressBar prcbCoolDown;
        private System.Windows.Forms.PictureBox ptrbAvatar;
        private System.Windows.Forms.Timer tmCoolDown;
    }
}

