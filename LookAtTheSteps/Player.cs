using System;
using System.Drawing;

namespace LookAtTheSteps
{
    public class Player
    {
        public int X;
        public int Y;
        public int DirX;
        public int DirY;
        public bool IsMoving = false;
        public Tuple<int, int> Position;
        public bool MadeMove;

        public Image Sprite;
        public int Size;

        public static int Health;
        public static int InventorySize;
        public static MapBlocks[] Inventory;
        public static bool IsInventoryPressed = false;
        public static int PressedInventoryPosition = -1;

        public int PurposeX;
        public int PurposeY;


        public Player(int x, int y, Image sprite, int inventorySize, int health) // инвентарь должен быть меньше ширины карты
        {
            X = x;
            Y = y;
            Sprite = sprite;
            Size = 60;
            Position = new Tuple<int, int>(0, 0);
            InventorySize = inventorySize;
            Inventory = new MapBlocks[InventorySize];
            Health = health;
        }

        
        public static void Init()
        {
            Inventory = GetInventory();
        }

        public bool IsInventoryFull()
        {
            for (var i = 0; i < InventorySize; i++)
                if (Inventory[i] == 0)
                    return false;
            return true;

        }

        public static MapBlocks[] GetInventory()
        {
            MapBlocks[] array = new MapBlocks[InventorySize];
            for (var i = 0; i < InventorySize; i++)
                array[i] = MapBlocks.Empty;
            return array;
        }
        public static void DrawInventory(Graphics g, int PointX, int PointY)
        {
            PointX += Map.CellSize * (Map.MapWidth / 2 - 1);
            PointY += Map.CellSize * (Map.MapHeigh + 1);
            for (var i = 0; i < InventorySize; i++)
            {
                if (Inventory[i] == MapBlocks.Empty)
                {
                    g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    g.FillRectangle(new SolidBrush(Color.Pink),
                        PointX, PointY, Map.CellSize, Map.CellSize);
                }
                if (Inventory[i] == MapBlocks.Stone)
                {
                    g.DrawRectangle(new Pen(Color.Black), PointX, PointY, Map.CellSize, Map.CellSize);
                    g.DrawImage(Map.StoneImage,  PointX, PointY, 50, 50);
                };
                PointX += Map.CellSize;
            }
        }

        public void Move()
        {
            X += DirX;
            Y += DirY;
        }
    }
}