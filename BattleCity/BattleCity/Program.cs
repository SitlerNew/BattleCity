using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
            //------------------------------------------------Bound Code------------------------------------------------//
            window = new RenderWindow(new VideoMode(1280, 800), "Battle City");
            window.SetVerticalSyncEnabled(true);
            window.Closed += WinClosed;

            Image icon = new Image("..\\Source\\Textures\\icon5.png");
            window.SetIcon(64, 64, icon.Pixels);

            //------------------------------------------------Game Code------------------------------------------------//    



            FieldMap map = new FieldMap("map.png");
            Unit p = new Unit("players1.png", 300, 700, 0.1f);

            Clock clock = new Clock();

            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                float time = clock.ElapsedTime.AsMicroseconds();
                clock.Restart();
                time = time / 800;

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    p.dir = 3;
                    p.speed = 0.07f;
                   // p.MultiplePos();
                    p.sprite.TextureRect = new IntRect(0, 0, 32, 32);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    p.dir = 2;
                    p.speed = 0.1f;
                   // p.MultiplePos();
                    p.sprite.TextureRect = new IntRect(32, 0, 32, 32);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    p.dir = 0;
                    p.speed = 0.1f;

                    p.sprite.TextureRect = new IntRect(96, 0, 32, 32);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    p.dir = 1;
                    p.speed = 0.07f;

                    p.sprite.TextureRect = new IntRect(64, 0, 32, 32);
                }

                p.update(time, map.tileMap, ref window, ref map);
                
                //window.Clear(Color.Black);
                //------------------------------------------------Draw Code------------------------------------------------//

                map.Draw(ref window);
                window.Draw(p.sprite);


                //------------------------------------------------Show Code------------------------------------------------//
                window.Display();
            }
        }

        public static void WinClosed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
