using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace SpaceShooterGame
{
    public partial class Form1 : Form
    {
        PictureBox pShipPic;
        PictureBox enemy1;
        PictureBox enemy2;
        PictureBox enemy3;
        /*List<PictureBox> Enemies = new List<PictureBox>();*/
        List<PictureBox> playerBullets = new List<PictureBox>();
        List<PictureBox> enemiesBullets = new List<PictureBox>();
        string E1Dir;
        string E2Dir;
        string E3Dir;


        int Counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreatePlayerShip();
            CreateEnemyShips();



        }
        private void CreatePlayerShip()
        {
            pShipPic = new PictureBox();
            Image img = Properties.Resources.Ship2;
            pShipPic.Image = img;

            pShipPic.Width = img.Width;
            pShipPic.Height = img.Height;

            pShipPic.Left = 20;
            pShipPic.Top = (this.Height/2) - ( img.Height/2);

            pShipPic.BackColor = Color.Transparent;
            this.Controls.Add(pShipPic);

        }

        private void CreateEnemyShips()
        {
            enemy1 = new PictureBox();
            Image img1 = Properties.Resources.Ship1;
            enemy1.Image = img1;
            E1Dir = "Up";

            enemy1.Width = img1.Width;
            enemy1.Height = img1.Height;

            enemy1.Left = this.Width - img1.Width - 20;
            enemy1.Top = (this.Height / 2) - (img1.Height / 2);

            enemy1.BackColor = Color.Transparent;
            this.Controls.Add(enemy1);
            /*Enemies.Add(enemy1);*/


            enemy2 = new PictureBox();
            Image img2 = Properties.Resources.Ship4;
            enemy2.Image = img2;
            E2Dir = "Down";

            enemy2.Width = img2.Width;
            enemy2.Height = img2.Height;

            enemy2.Left = this.Width - img2.Width - 20;
            enemy2.Top = (this.Height / 4) - (img2.Height / 2);

            enemy2.BackColor = Color.Transparent;
            this.Controls.Add(enemy2);
            /*Enemies.Add(enemy2);*/


            enemy3 = new PictureBox();
            Image img3 = Properties.Resources.Ship5;
            enemy3.Image = img3;
            E3Dir = "Up";

            enemy3.Width = img3.Width;
            enemy3.Height = img3.Height;
            Random random = new Random();
            enemy3.Left = this.Width - img3.Width - 20;
            enemy3.Top = random.Next(0, this.Height - img3.Height);

            enemy3.BackColor = Color.Transparent;
            this.Controls.Add(enemy3);
           /* Enemies.Add(enemy3);*/

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                pShipPic.Top -= 10;
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                pShipPic.Top += 10;
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pShipPic.Left -= 10;
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                pShipPic.Left += 10;
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                FireBullets();
            }



            if (enemy1.Top <= 0)
            {
                E1Dir = "Down";
            }
            if (enemy1.Top >= this.Height - enemy1.Image.Height)
            {
                E1Dir = "Up";
            }
            if (enemy2.Top <= 0)
            {
                E2Dir = "Down";
            }
            if (enemy2.Top >= this.Height - enemy2.Image.Height)
            {
                E2Dir = "Up";
            }
            if (enemy3.Top <= 0)
            {
                E2Dir = "Down";
            }
            if (enemy3.Top >= this.Height - enemy3.Image.Height)
            {
                E2Dir = "Up";
            }



            if (E1Dir == "Up")
            {
                enemy1.Top -= 10;
            }
            if (E1Dir == "Down")
            {
                enemy1.Top += 10;
            }
            if (E2Dir == "Up")
            {
                enemy2.Top -= 10;
            }
            if (E2Dir == "Down")
            {
                enemy2.Top += 10;
            }
            if (E3Dir == "Up")
            {
                enemy3.Top -= 10;
            }
            if (E3Dir == "Down")
            {
                enemy3.Top += 10;
            }

            foreach(PictureBox bullets in playerBullets)
            {
                bullets.Left += 10;
            }










            Counter++;
        }
        private void FireBullets()
        {
            PictureBox bullet = new PictureBox();
            Image img = Properties.Resources.shot6_1;
            bullet.Image = img;

            bullet.Height = img.Height;
            bullet.Width = img.Width;

            bullet.BackColor = Color.Transparent;

            bullet.Left = pShipPic.Right + 10;
            bullet.Top = pShipPic.Top + (pShipPic.Height / 2);

            playerBullets.Add(bullet);
            this.Controls.Add(bullet);
        }
    }
}
