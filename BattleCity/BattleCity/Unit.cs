using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace BattleCity
{
    class Unit
    {
        private float x;
        private float y;
        public float dx;
        public float dy;
        public float width;
        public float height;
        public float speed;
        public int dir;
        private Image image;
        private Texture texture;
        public Sprite sprite;

        public Unit(string name, float x, float y, float s = 10)
        {
            dx = 0;
            dy = 0;
            speed = s;
            dir = 0;
            width = 32;
            height = 32;

            image = new Image("..\\Source\\Textures\\" + name);
            texture = new Texture(image);
            sprite = new Sprite(texture);

            this.x = x;
            this.y = y;

            sprite.TextureRect = new IntRect(0, 0, 32, 32);
        }

        public void update(float time, int[,] tileMap)
        {
            switch (dir)
            {
                case 0:
                    dx = speed;
                    dy = 0;
                    break;
                case 1:
                    dx = -speed;
                    dy = 0;
                    break;
                case 2:
                    dx = 0;
                    dy = speed;
                    break;
                case 3:
                    dx = 0;
                    dy = -speed;
                    break;
                default:
                    break;
            }

            x += dx * time;
            y += dy * time;

            speed = 0;

            sprite.Position = new Vector2f(x, y);
            interactionWithMap(tileMap);
        }

        public void interactionWithMap(int[,] tileMap)
        {
            for (int i = (int)y / 32; i < (y + height) / 32; i++)
                for (int j = (int)x / 32; j < (x + width) / 32; j++)
                {
                    if (tileMap[i, j] == 1)
                    {
                        if (dy > 0)
                        {
                            y = i * 32 - height;
                        }
                        if (dy < 0)
                        {
                            y = i * 32 + 32;
                        }
                        if (dx > 0)
                        {
                            x = j * 32 - width;
                        }
                        if (dx < 0)
                        {
                            x = j * 32 + 32;
                        }
                    }
                }
        }

    }
}
