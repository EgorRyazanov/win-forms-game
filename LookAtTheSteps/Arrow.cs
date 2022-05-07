using System.Drawing;
using System.IO;

namespace LookAtTheSteps
{
    public class Arrow
    {
        public Image Image = new Bitmap(Path.Combine(new DirectoryInfo(
            Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\fireball.png"));
        public int X;
        public int Y;
        public int DirX;
        public int DirY;
        
        public int PurposeX;
        public int PurposeY;

        public Arrow(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public void Move()
        {
            X += DirX;
            Y += DirY;
        }
        
    }
}