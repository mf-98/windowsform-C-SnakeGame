namespace Game
{
    partial class GameBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            this.sprites = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gameScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // sprites
            // 
            this.sprites.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sprites.ImageStream")));
            this.sprites.TransparentColor = System.Drawing.Color.Transparent;
            this.sprites.Images.SetKeyName(0, "Retro-Block-icon.png");
            this.sprites.Images.SetKeyName(1, "images.png");
            this.sprites.Images.SetKeyName(2, "NSLU_Snake_Block_unused.png");
            this.sprites.Images.SetKeyName(3, "unnamed (2).png");
            this.sprites.Images.SetKeyName(4, "images.jpg");
            this.sprites.Images.SetKeyName(5, "cf4b85ba4900ee1d74a020abc297e5e6.png");
            this.sprites.Images.SetKeyName(6, "tile_brick.png");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gameScreen
            // 
            this.gameScreen.BackColor = System.Drawing.Color.LimeGreen;
            this.gameScreen.Location = new System.Drawing.Point(25, 6);
            this.gameScreen.Name = "gameScreen";
            this.gameScreen.Size = new System.Drawing.Size(420, 420);
            this.gameScreen.TabIndex = 0;
            this.gameScreen.TabStop = false;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 438);
            this.Controls.Add(this.gameScreen);
            this.Name = "GameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome!";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.snake_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList sprites;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox gameScreen;
    }
}

