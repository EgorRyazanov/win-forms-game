using System;
using System.Drawing;

namespace LookAtTheSteps
{
    public static class Velocity
    {
        public static void ChangeArrowVelocity(int row, int column, int index, Tuple<int, int> position)
        {
            Map.IsProejectileFlying = true;
            if (position.Item2 - column < 0)
            {
                Form1.Guns[index].DirX = -5;
                Form1.Guns[index].PurposeX = (position.Item2 + 1) * Map.CellSize + Form1.WidthBorder - 25;
                Form1.Guns[index].PurposeY = position.Item1 * Map.CellSize + Form1.HeightBorder;
            }

            else if (position.Item2 - column > 0)
            {
                Form1.Guns[index].DirX = 5;
                Form1.Guns[index].PurposeX = position.Item2 * Map.CellSize + Form1.WidthBorder - 25;
                Form1.Guns[index].PurposeY = position.Item1 * Map.CellSize + Form1.HeightBorder;
                Form1.Guns[index].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            
            else if (position.Item1 - row < 0)
            {
                Form1.Guns[index].DirY = -5;
                Form1.Guns[index].PurposeX = position.Item2 * Map.CellSize + Form1.WidthBorder;
                Form1.Guns[index].PurposeY = (position.Item1 + 1) * Map.CellSize + Form1.HeightBorder - 25;
                Form1.Guns[index].Image.RotateFlip(RotateFlipType.Rotate270FlipY);
            }
            
            else if (position.Item1 - row > 0)
            {
                Form1.Guns[index].DirY = 5;
                Form1.Guns[index].PurposeX = position.Item2  * Map.CellSize + Form1.WidthBorder;
                Form1.Guns[index].PurposeY = position.Item1 * Map.CellSize + Form1.HeightBorder - 25;
                Form1.Guns[index].Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            }
        }
    }
}