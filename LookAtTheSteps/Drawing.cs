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
        
        public static void DrawMap(Graphics g, int PointX, int PointY, MapBlocks[,] map, int mapHeigh, int mapWidth)
        {
            // g.FillRectangle(new SolidBrush(Color.DimGray), 0, 0, 2000, 2000);
            var startY = PointY;
            for (var x = 0; x < mapWidth; x++)
            {
                for (var y = 0; y < mapHeigh; y++)
                {
                    if (map[y, x] == MapBlocks.Empty) // пустота
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    if (map[y, x] == MapBlocks.Wall) // стена
                        g.FillRectangle(new SolidBrush(Color.Gray),
                            PointX, PointY, Map.CellSize - 1, Map.CellSize - 1);
                    if (map[y, x] == MapBlocks.Stone)
                    {
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                        g.DrawImage(StoneImage,  PointX, PointY, 50, 50);
                    } // камень
                    if (map[y, x] == MapBlocks.Finish) // финиш
                        g.FillRectangle(new SolidBrush(Color.Green),
                            PointX, PointY, Map.CellSize - 1, Map.CellSize - 1);
                    if (map[y, x] == MapBlocks.Lava) // финиш
                        g.DrawImage(LavaImage,  PointX, PointY, 50, 50);
                    if (map[y, x] == MapBlocks.ForcedLava) // Заставленная лава
                        g.FillRectangle(new SolidBrush(Color.LightGray),
                            PointX, PointY, Map.CellSize - 1, Map.CellSize - 1);
                    if (map[y, x] == MapBlocks.Crossbow) // Арбалет
                        g.FillRectangle(new SolidBrush(Color.Aqua),
                            PointX, PointY, Map.CellSize - 1, Map.CellSize - 1);
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
                        PointX, PointY, Map.CellSize, Map.CellSize);
                }
                if (inventory[i] == MapBlocks.Stone)
                {
                    g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    g.DrawImage(StoneImage,  PointX, PointY, 50, 50);
                };
                PointX += Map.CellSize;
            }
        }
        
        public static void DrawRectangle(int row, int column, Color color, Graphics g)
        {
            g.DrawRectangle(new Pen(color), 100 + column * Map.CellSize,
                100 + row * Map.CellSize, Map.CellSize, Map.CellSize);
        }
    }
}