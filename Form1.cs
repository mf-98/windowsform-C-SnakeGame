using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class GameBoard : Form
    {
        
        struct SnakePosition
        {
            public int XPOS;
            public int YPOS;
        }

        enum TileType
        {
            EMPTY,
            SNAKE,
            TREAT
        };

        enum Directions
        {
            Up,
            Down,
            Left,
            Right
        };
        

        SnakePosition[] snakeArray;
        Random rand;
        int bodyLength; 
        Directions movementDir;
        TileType[,] tileArray;
        Graphics graphics;

        public GameBoard()
        {
            InitializeComponent();
            tileArray = new TileType[11, 11]; 
            snakeArray = new SnakePosition[100]; 
            rand = new Random();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            gameScreen.Image = new Bitmap(420, 420); 
            graphics = Graphics.FromImage(gameScreen.Image);
            graphics.Clear(Color.White);

            for (int i = 1; i <= 10; i++)
            {
                
                graphics.DrawImage(sprites.Images[6], i * 35, 0);
                graphics.DrawImage(sprites.Images[6], i * 35, 385); 
            }

            for (int i = 0; i <= 11; i++)
            {
                
                graphics.DrawImage(sprites.Images[6], 0, i * 35); 
                graphics.DrawImage(sprites.Images[6], 385, i * 35); 
            }

            
            snakeArray[0].XPOS = 5; 
            snakeArray[0].YPOS = 5;
            snakeArray[1].XPOS = 5;
            snakeArray[1].YPOS = 6;
            snakeArray[2].XPOS = 5;
            snakeArray[2].YPOS = 7;

            graphics.DrawImage(sprites.Images[5], 5 * 35, 5 * 35); 
            graphics.DrawImage(sprites.Images[4], 5 * 35, 6 * 35); 
            graphics.DrawImage(sprites.Images[4], 5 * 35, 7 * 35); 

            tileArray[5, 5] = TileType.SNAKE;
            tileArray[5, 6] = TileType.SNAKE; 
            tileArray[5, 7] = TileType.SNAKE; 

            movementDir = Directions.Up;
            bodyLength = 3;

            for (int i = 0; i < 4; i++)
            {
                Treat();
            }
        }

        private void Treat()
        {
            var imageIndex = rand.Next(0, 4);
            int x;
            int y;
            

            do
            {
                x = rand.Next(1, 10);
                y = rand.Next(1, 10);
            }
            while (tileArray[x, y] != TileType.EMPTY);

            tileArray[x, y] = TileType.TREAT; 
            graphics.DrawImage(sprites.Images[imageIndex], x * 35, y * 35); 
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.FillRectangle(Brushes.White, snakeArray[bodyLength - 1].XPOS * 35,
                snakeArray[bodyLength - 1].YPOS * 35, 35, 35);

            tileArray[snakeArray[bodyLength - 1].XPOS, snakeArray[bodyLength - 1].YPOS] = TileType.EMPTY;


            for (int i = bodyLength; i >= 1; i--)
            {
                snakeArray[i].XPOS = snakeArray[i - 1].XPOS;
                snakeArray[i].YPOS = snakeArray[i - 1].YPOS;
            }

            graphics.DrawImage(sprites.Images[4], snakeArray[0].XPOS * 35, snakeArray[0].YPOS * 35);


            switch (movementDir)
            {
                case Directions.Up:
                    snakeArray[0].YPOS = snakeArray[0].YPOS - 1;
                    break;
                case Directions.Down:
                    snakeArray[0].YPOS = snakeArray[0].YPOS + 1;
                    break;
                case Directions.Left:
                    snakeArray[0].XPOS = snakeArray[0].XPOS - 1;
                    break;
                case Directions.Right:
                    snakeArray[0].XPOS = snakeArray[0].XPOS + 1;
                    break;
            }


            if (snakeArray[0].XPOS < 1 || snakeArray[0].XPOS > 10 || snakeArray[0].YPOS < 1 || snakeArray[0].YPOS > 10)
            {
                GameOver();
                gameScreen.Refresh();
                return;
            }


            if (tileArray[snakeArray[0].XPOS, snakeArray[0].YPOS] == TileType.SNAKE)
            {
                GameOver();
                gameScreen.Refresh();
                return;
            }


            if (tileArray[snakeArray[0].XPOS, snakeArray[0].YPOS] == TileType.TREAT)
            {

                graphics.DrawImage(sprites.Images[4], snakeArray[bodyLength].XPOS * 35,
                    snakeArray[bodyLength].YPOS * 35);

                tileArray[snakeArray[bodyLength].XPOS, snakeArray[bodyLength].YPOS] = TileType.SNAKE;
                bodyLength++;


                if (bodyLength < 96)
                    Treat();

                this.Text = "Snake - score: " + bodyLength;
            }


            graphics.DrawImage(sprites.Images[5], snakeArray[0].XPOS * 35, snakeArray[0].YPOS * 35);

            tileArray[snakeArray[0].XPOS, snakeArray[0].YPOS] = TileType.SNAKE;


            gameScreen.Refresh();
        }

        private void GameOver()
        {
            timer1.Enabled = false;
            MessageBox.Show("YOU LOST", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void snake_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    movementDir = Directions.Up;
                    break;
                case Keys.Down:
                    movementDir = Directions.Down;
                    break;
                case Keys.Left:
                    movementDir = Directions.Left;
                    break;
                case Keys.Right:
                    movementDir = Directions.Right;
                    break;
            }
        }
    }
}
