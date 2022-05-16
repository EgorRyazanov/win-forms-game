using System.Drawing;
using System.IO;

namespace LookAtTheSteps
{
    public class Drawing
    {
        public static Image StoneImage = new Bitmap(Path.Combine(new DirectoryInfo(
            Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\Stone.png"));

        public static Image LavaImage = new Bitmap(Path.Combine(new DirectoryInfo(
            Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\Lava.png"));
        
        public static Image Wall = new Bitmap(Path.Combine(new DirectoryInfo(
            Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\Wall.png"));
        public static Image Knight = new Bitmap(Path.Combine(new DirectoryInfo
            (Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\knight.png"));
        public static Image Gun = new Bitmap(Path.Combine(new DirectoryInfo
            (Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\BigGun.png"));
        
        public static void DrawMap(Graphics g, int PointX, int PointY, MapBlocks[,] map, int mapHeigh, int mapWidth)
        {
            var startY = PointY;
            for (var x = 0; x < mapWidth; x++)
            {
                for (var y = 0; y < mapHeigh; y++)
                {
                    if (map[y, x] == MapBlocks.Empty)
                    {
                        g.FillRectangle(new SolidBrush(Color.White),
                            PointX + 1, PointY + 1, Map.CellSize - 2, Map.CellSize - 2);
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    } // пустота

                    if (map[y, x] == MapBlocks.Wall)
                    {
                        g.DrawImage(Wall,  PointX, PointY, 50, 50);
                        // g.FillRectangle(new SolidBrush(Color.DarkGray),
                        //     PointX + 1, PointY + 1, Map.CellSize - 2, Map.CellSize - 2);
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    } // стена
                    
                    if (map[y, x] == MapBlocks.Stone)
                    { 
                        g.FillRectangle(new SolidBrush(Color.White),
                            PointX + 1, PointY + 1, Map.CellSize - 2, Map.CellSize - 2);
                        g.DrawImage(StoneImage,  PointX, PointY, 50, 50);
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    } // камень

                    if (map[y, x] == MapBlocks.Finish)
                    {
                        g.FillRectangle(new SolidBrush(Color.LightGreen),
                            PointX + 1, PointY + 1, Map.CellSize - 2, Map.CellSize - 2);
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    } // финиш

                    if (map[y, x] == MapBlocks.Lava)
                    {
                        g.DrawImage(LavaImage,  PointX, PointY, 50, 50);
                        // g.FillRectangle(new SolidBrush(Color.Red),
                        //     PointX + 1, PointY + 1, Map.CellSize - 2, Map.CellSize - 2);
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    } // Лава

                    if (map[y, x] == MapBlocks.ForcedLava)
                    {
                        g.FillRectangle(new SolidBrush(Color.LightGray),
                            PointX + 1, PointY + 1, Map.CellSize - 2, Map.CellSize - 2);
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    } // Заставленная лава

                    if (map[y, x] == MapBlocks.Gun)
                    {
                        g.FillRectangle(new SolidBrush(Color.White),
                            PointX + 1, PointY + 1, Map.CellSize - 2, Map.CellSize - 2);
                        g.DrawImage(Gun,  PointX, PointY, 50, 50);
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    } // Арбалет
                    
                    PointY += Map.CellSize;
                }

                PointX += Map.CellSize;
                PointY = startY;
            }

        }
        public static void DrawInventory(Graphics g, int PointX, int PointY, int inventorySize, MapBlocks[] inventory, 
            int mapWidth, int mapHeigh)
        {
            PointX += Map.CellSize * (mapWidth / 2 - 1);
            PointY += Map.CellSize * (mapHeigh + 1);
            for (var i = 0; i < inventorySize; i++)
            {
                if (inventory[i] == MapBlocks.Empty)
                {
                    g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    g.FillRectangle(new SolidBrush(Color.Pink),
                        PointX + 1, PointY + 1, Map.CellSize - 2, Map.CellSize - 2);
                }
                if (inventory[i] == MapBlocks.Stone)
                {
                    g.FillRectangle(new SolidBrush(Color.Pink),
                        PointX + 1, PointY + 1, Map.CellSize - 2, Map.CellSize - 2);
                    g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    g.DrawImage(StoneImage,  PointX, PointY, 50, 50);
                };
                PointX += Map.CellSize;
            }
        }
        
        public static void DrawRectangle(int row, int column, Color color, Graphics g)
        {
            g.DrawRectangle(new Pen(color), Form1.WidthBorder + column * Map.CellSize,
                Form1.HeightBorder + row * Map.CellSize, Map.CellSize, Map.CellSize);
        }
    }
}