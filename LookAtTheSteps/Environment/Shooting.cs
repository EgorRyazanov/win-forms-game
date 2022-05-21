using System;

namespace LookAtTheSteps
{
    public static class Shooting
    {
        public static int RowGunsShoot(Player player, Map map, int i, int index)
        {
            Gun gun;
            if (map.ArrowCanShootRow(i, player.Position.Item2, player.Position.Item1))
            {
                if (Math.Abs(i - player.Position.Item2) != 1)
                {
                    if (i > player.Position.Item2)
                        gun = new Gun(i * Map.CellSize + Form1.WidthBorder - 25,
                            player.Position.Item1 * Map.CellSize + Form1.HeightBorder);

                    else
                        gun = new Gun((i + 1) * Map.CellSize + Form1.WidthBorder,
                            player.Position.Item1 * Map.CellSize + Form1.HeightBorder);
                    Form1.Guns.Add(gun);
                    Velocity.ChangeArrowVelocity(player.Position.Item1, i, index, 
                        new Tuple<int, int>(player.Position.Item1, player.Position.Item2));
                    index++;
                }
                else
                {
                    if (player.Health > 0)
                        player.Health -= 1;
                }
            }
            return index; 
        }

        public static void ColumnGunsShoot(Player player, Map map, int i, int index)
        {
            if (map.ArrowCanShootColumn(i, player.Position.Item1, player.Position.Item2))
            {
                Gun gun;
                if (Math.Abs(i - player.Position.Item1) != 1) 
                {
                    if (i > player.Position.Item1)        
                        gun = new Gun(player.Position.Item2 * Map.CellSize + Form1.WidthBorder, i * Map.CellSize + Form1.HeightBorder - 25);
                    else 
                        gun = new Gun(player.Position.Item2 * Map.CellSize + Form1.WidthBorder, (i + 1) * Map.CellSize + Form1.HeightBorder);
                    Form1.Guns.Add(gun);
                    Velocity.ChangeArrowVelocity( i, player.Position.Item2, index, 
                        new Tuple<int, int>(player.Position.Item1, player.Position.Item2));
                    index++;
                }
                else
                {
                    if (player.Health > 0)
                        player.Health -= 1;
                }
            }
        }
    }
}