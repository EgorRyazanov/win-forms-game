using System;
using System.Collections.Generic;
using System.Drawing;

namespace LookAtTheSteps
{
    public enum MapBlocks
    {
        Empty,
        Wall,
        Stone,
        Finish,
        Lava,
        ForcedLava,
        Crossbow
    }
    public static class Map
    {
        public static bool isPressed = false;
        public static Tuple<int, int> pressedPosition = new Tuple<int, int>(-1, -1); //Можно добавить класс Point
        
        public const int MapHeigh = 6;
        public const int MapWidth = 6;
        public static MapBlocks[,] map = new MapBlocks[MapHeigh, MapWidth];
        public static int CellSize = 50;
        
        
        public static Dictionary<int, List<int>> CrossbowsColumn = new Dictionary<int, List<int>>();
        public static Dictionary<int, List<int>> CrossbowsRow = new Dictionary<int, List<int>>(); 
        public static bool HaveCrossbow;
        public static bool ArrowIsMoving;

        public static void Init()
        {
            map = GetMap();
            GetCrossbows();
        }

        public static void GetCrossbows()
        {
            for (var x = 0; x < MapWidth; x++)
                CrossbowsColumn[x] = new List<int>();
            for (var y = 0; y < MapWidth; y++)
                CrossbowsRow[y] = new List<int>();

            for (var x = 0; x < MapWidth; x++)
                for (var y = 0; y < MapHeigh; y++)
                    if (map[y, x] == MapBlocks.Crossbow)
                    {
                        CrossbowsRow[y].Add(x);
                        CrossbowsColumn[x].Add(y);
                        HaveCrossbow = true;
                    }
        }

        public static MapBlocks[,] GetMap()
        {
            return new [,] {{MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Crossbow, MapBlocks.Empty}, 
                {MapBlocks.Lava, MapBlocks.Empty , MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Wall , MapBlocks.Wall}, 
                {MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Crossbow, MapBlocks.Wall},
                {MapBlocks.Empty, MapBlocks.Empty , MapBlocks.Crossbow, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall},
                {MapBlocks.Wall, MapBlocks.Crossbow , MapBlocks.Stone, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall},
                {MapBlocks.Empty, MapBlocks.Lava , MapBlocks.Empty, MapBlocks.Crossbow, MapBlocks.Empty, MapBlocks.Stone}
            };
        }

        public static void DrawMap(Graphics g, int PointX, int PointY)
        {
            var startY = PointY;
            for (var x = 0; x < MapWidth; x++)
            {
                for (var y = 0; y < MapHeigh; y++)
                {
                    if (map[y, x] == MapBlocks.Empty) // пустота
                        g.DrawRectangle(new Pen(Color.Black), PointX, PointY, CellSize, CellSize);
                    if (map[y, x] == MapBlocks.Wall) // стена
                        g.FillRectangle(new SolidBrush(Color.Gray),
                            PointX, PointY, CellSize - 1, CellSize - 1);
                    if (map[y, x] == MapBlocks.Stone) // камень
                        g.FillRectangle(new SolidBrush(Color.Lavender),
                            PointX, PointY, CellSize - 1, CellSize - 1);
                    if (map[y, x] == MapBlocks.Finish) // финиш
                        g.FillRectangle(new SolidBrush(Color.Green),
                            PointX, PointY, CellSize - 1, CellSize - 1);
                    if (map[y, x] == MapBlocks.Lava) // финиш
                        g.FillRectangle(new SolidBrush(Color.DarkRed),
                            PointX, PointY, CellSize - 1, CellSize - 1);
                    if (map[y, x] == MapBlocks.ForcedLava) // Заставленная лава
                        g.FillRectangle(new SolidBrush(Color.LightGray),
                            PointX, PointY, CellSize - 1, CellSize - 1);
                    if (map[y, x] == MapBlocks.Crossbow) // Арбалет
                        g.FillRectangle(new SolidBrush(Color.Aqua),
                            PointX, PointY, CellSize - 1, CellSize - 1);
                    PointY += CellSize;
                }

                PointX += CellSize;
                PointY = startY;
            }
        }

        public static int GetWidth()
        {
            return CellSize * MapWidth;
        }

        public static int GetHeigh()
        {
            return CellSize * MapHeigh;
        }
    }
}