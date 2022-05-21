using System.Drawing;
using System.Windows.Forms;

namespace LookAtTheSteps
{
    public static class Interface
    {
        public static bool PlayerInventoryPressed(int x, int y, MouseButtons button, Player player)
        {
            return button == MouseButtons.Left &&
                   x - Form1.WidthBorder - Map.CellSize * (Map.MapWidth / 2 - 1) > 0
                   && x < Form1.WidthBorder + Map.CellSize * (Map.MapWidth / 2 - 1 + Player.InventorySize) &&
                   y - Form1.HeightBorder - Map.CellSize * (Map.MapHeigh + 1) > 0
                   && y < Form1.HeightBorder + Map.CellSize * (Map.MapHeigh + 2)
                   && !player.IsMoving;
        }
        
        public static void ClickOnInventory(int x, int y, Graphics g, Player player)
        {
            var column = (x - Form1.WidthBorder)/ Map.CellSize;
            var row = (y - Form1.HeightBorder)/ Map.CellSize;
            Drawing.DrawRectangle(row, column, Color.Gold, g);
            player.IsInventoryPressed = true;
            player.PressedInventoryPosition = column - Map.MapWidth/2 + 1;
        }
    }
}