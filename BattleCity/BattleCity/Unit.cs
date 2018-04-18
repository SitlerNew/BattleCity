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
    abstract class Unit
    {
        protected float x;
        protected float y;
        protected float dx;
        protected float dy;
        protected float width;
        protected float height;
        protected float speed;
        protected bool isLife;
        protected int dir;
        protected Image image;
        protected Texture texture;
        protected Sprite sprite;
       // protected Debug console;

        public Unit(string fileName, float x, float y)
        {
            dx = 0;
            dy = 0;
            speed = 0;
            dir = 0;
            width = 32;
            height = 32;

            image = new Image("..\\Source\\Textures\\" + fileName);
            texture = new Texture(image);
            sprite = new Sprite(texture);

            this.x = x;
            this.y = y;

            sprite.TextureRect = new IntRect(0, 0, 32, 32);
            //console = new Debug();
        }

        public virtual void move(float time, int[,] tileMap, ref RenderWindow a, ref FieldMap h)
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                dir = 3;
                speed = 0.07f;
                   //p.MultiplePos();
                sprite.TextureRect = new IntRect(0, 0, 32, 32);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                dir = 2;
                speed = 0.1f;
                  //p.MultiplePos();
                sprite.TextureRect = new IntRect(32, 0, 32, 32);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                dir = 0;
                speed = 0.1f;

                sprite.TextureRect = new IntRect(96, 0, 32, 32);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                dir = 1;
                speed = 0.07f;

                sprite.TextureRect = new IntRect(64, 0, 32, 32);
            }

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


            MultiplePos();

            //console.DConsole("X " + x + "\n Y " + y);
            //console.Print();


            sprite.Position = new Vector2f (x,y);
            interactionWithMap(tileMap, ref a, ref h);
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

        public void MultiplePos()
        {
            int tmp = 2;

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

        public Sprite Sprite
        {
            get { return sprite; }

            protected set { }
        }
    }

    class Player1 : Unit
    {
        private bool isAlly;
        private int score;
        private Color color;
        private int healt;
        private string name;

        public Player1(string fileName, string playerName, bool isAlly, Color color, float x, float y) : base(fileName,x,y)
        {
            this.isAlly = isAlly;
            score = 0;
            this.color = color;
            healt = 3;
            name = playerName;

            sprite.Color = color;
        }

        

    }

    class Player2 : Unit
    {
        private bool isAlly;
        private int score;
        private Color color;
        private int healt;
        private string name;

        public Player2(string fileName, string playerName, bool isAlly, Color color, float x, float y) : base(fileName, x, y)
        {
            this.isAlly = isAlly;
            score = 0;
            this.color = color;
            healt = 3;
            name = playerName;

            sprite.Color = color;
        }

        public override void move(float time, int[,] tileMap, ref RenderWindow a, ref FieldMap h)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                dir = 3;
                speed = 0.07f;
                //p.MultiplePos();
                sprite.TextureRect = new IntRect(0, 0, 32, 32);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                dir = 2;
                speed = 0.1f;
                //p.MultiplePos();
                sprite.TextureRect = new IntRect(32, 0, 32, 32);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                dir = 0;
                speed = 0.1f;

                sprite.TextureRect = new IntRect(96, 0, 32, 32);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                dir = 1;
                speed = 0.07f;

                sprite.TextureRect = new IntRect(64, 0, 32, 32);
            }

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


            MultiplePos();

            //console.DConsole("X " + x + "\n Y " + y);
            //console.Print();


            sprite.Position = new Vector2f(x, y);
            interactionWithMap(tileMap, ref a, ref h);

        }
    }




    class Enemy : Unit
    {
        public Enemy(string fileName, string enemyName, int dificult, Color color, float x, float y) : base(fileName, x, y)
        {

        }    
    }



}
