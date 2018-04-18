using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;

namespace BattleCity
{
    class Bullet : Unit
    {
        private Color color;

        public Bullet(string fileName, Color color, float x, float y, float speed, int dir) : base(fileName, x,y, speed, dir)
        {
            this.color = color;
            Sprite.Color = color;

        }

        public void update(float time, int[,] tileMap, ref RenderWindow a, Player1 tmp1, Player2 tmp2)
        {
            switch (dir)
            {
                case (int)state.right:
                    dx = currentSpeed;
                    dy = 0;
                    break;
                case (int)state.left:
                    dx = -currentSpeed;
                    dy = 0;
                    break;
                case (int)state.down:
                    dx = 0;
                    dy = currentSpeed;
                    break;
                case (int)state.up:
                    dx = 0;
                    dy = -currentSpeed;
                    break;
                default:
                    break;
            }

            x += dx * time;
            y += dy * time;

            if (x < 52)
            {
                //bullet = null;
                isShoot = false;
            }
            
            sprite.Position = new Vector2f(x+width/2, y+height/2);

            //interactionWithMap(tileMap, ref a);
        }

        public override void interactionWithMap(int[,] tileMap, ref RenderWindow window)
        {
            for (int i = (int)y / 32; i < (y + height) / 32; i++)
                for (int j = (int)x / 32; j < (x + width) / 32; j++)
                {
                    if (tileMap[i, j] == 1 || tileMap[i, j] == 3)
                    {

                        //bullet = null;
                        //if (dy > 0)
                        //{
                        //    y = i * 32 - height;
                        //    sprite.Position = new Vector2f(x, y);
                        //}
                        //if (dy < 0)
                        //{
                        //    y = i * 32 + 32;
                        //    sprite.Position = new Vector2f(x, y);
                        //}
                        //if (dx > 0)
                        //{
                        //    x = j * 32 - width;
                        //    sprite.Position = new Vector2f(x, y);
                        //}
                        //if (dx < 0)
                        //{
                        //    x = j * 32 + 32;
                        //    sprite.Position = new Vector2f(x, y);
                        //}
                    }

                    if (tileMap[i, j] == 2)
                        isShoot = false;

                }
        }
    }
}
