using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Threading;

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
        private Debug console;

        public Unit(string name, float x, float y, float s = 0.1f)
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
            console = new Debug();
        }

        public void update(float time, int[,] tileMap, ref RenderWindow a, ref FieldMap h)
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

            if (dir == 0 || dir == 1)
                MultiplePos();


            console.DConsole("X " + x + "\n Y " + y);
            console.Print();


            sprite.Position = new Vector2f (x,y);
            interactionWithMap(tileMap, ref a, ref h);
        }

        public void MultiplePos()
        {
            int tmp = 32;

            int tmpX = (int)x;
            int tmpY = (int)y;

            x = tmpX;
            y = tmpY;


            if (dir == 2)
            {
                var result = y % tmp;
                if (result < 0)
                    result += tmp;

                y += result;
            }

            if (dir == 3)
            {
                var result = y % tmp;
                if (result < 0)
                    result += tmp;

                y -= result;
            }

            if (dir == 0)
            {
                var result = x % tmp;
                if (result < 0)
                    result += tmp;

                x += result;
            }

            if (dir == 1)
            {
                var result = x % tmp;
                if (result < 0)
                    result += tmp;

                x -= result;
            }
        }

        public void interactionWithMap(int[,] tileMap, ref RenderWindow window, ref FieldMap map)
        {
            for (int i = (int)y / 32; i < (y + height) / 32; i++)
                for (int j = (int)x / 32; j < (x + width) / 32; j++)
                {
                    if (tileMap[i, j] == 1 || tileMap[i, j] == 3)
                    {
                        if (dy > 0)
                        {
                            y = i * 32 - height;
                            sprite.Position = new Vector2f(x, y);
                        }
                        if (dy < 0)
                        {
                            y = i * 32 + 32;
                            sprite.Position = new Vector2f(x, y);
                        }
                        if (dx > 0)
                        {
                            x = j * 32 - width;
                            sprite.Position = new Vector2f(x, y);
                        }
                        if (dx < 0)
                        {
                            x = j * 32 + 32;
                            sprite.Position = new Vector2f(x, y);
                        }
                    }

                    if (tileMap[i, j] == 2)
                    {
                        sprite.Position = new Vector2f(x, y);
                        map.Draw(ref window);
                        window.Display();

                        window.Draw(sprite);
                    }
                }
        }
    }
}
