using System.Drawing;
using System.IO;

namespace LookAtTheSteps
{
    public class Gun
    {
        public Image Image = new Bitmap(Path.Combine(new DirectoryInfo(
            Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\fireball.png"));
        public int X;
        public int Y;
        public int DirX;
        public int DirY;
        
        public int PurposeX;
        public int PurposeY;

        public Gun(int x, int y)
        {
            X = x;
            Y = y;
            DirX = 0;
            DirY = 0;
        }
        
        public void Move()
        {
            X += DirX;
            Y += DirY;
        }
        
    }
}