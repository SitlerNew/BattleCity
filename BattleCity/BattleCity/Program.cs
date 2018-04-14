using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace BattleCity
{
    class Program
    {
        static RenderWindow window;

        static void Main(string[] args)
        {
            window = new RenderWindow(new VideoMode(1280,800),"Battle City");
            window.SetVerticalSyncEnabled(true);
            window.Closed += WinClosed;

            FieldMap map = new FieldMap("map.png");

            Unit p = new Unit("players.png", 300,700,10);

            Clock clock = new Clock();

            float currentFrame = 0;

            while (window.IsOpen)
            {
                window.DispatchEvents();
                float time = clock.ElapsedTime.AsMicroseconds();
                clock.Restart();
                time = time / 800;

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    p.dir = 3;
                    p.speed = 0.1f;
                    currentFrame += 0.005f * time;

                    if (currentFrame > 3)
                        currentFrame -= 3;
                    p.sprite.TextureRect = new IntRect(0, 0, 32, 32);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    p.dir = 2;
                    p.speed = 0.1f;
                    currentFrame += 0.005f * time;

                    if (currentFrame > 3)
                        currentFrame -= 3;
                    p.sprite.TextureRect = new IntRect(32,0, 32, 32);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    p.dir = 0;
                    p.speed = 0.1f;
                    currentFrame += 0.005f * time;

                    if (currentFrame > 3)
                        currentFrame -= 3;

                    p.sprite.TextureRect = new IntRect(96, 0, 32, 32);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    p.dir = 1;
                    p.speed = 0.1f;
                    currentFrame += 0.005f * time;

                    if (currentFrame > 3)
                        currentFrame -= 3;

                    p.sprite.TextureRect = new IntRect(64,0, 32, 32);
                }

                p.update(time,map.tileMap);

                window.Clear(Color.Black);

                map.Draw(ref window);
                window.Draw(p.sprite);

                window.Display();
            }

        }

        public static void WinClosed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
