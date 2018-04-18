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
            Player1 player1 = new Player1("players1.png","Vitaliy",true,Color.Green, 300, 700);
            Player2 player2 = new Player2("players1.png", "Davidiy", true, new Color(255,0,0), 250, 700);

            Clock clock = new Clock();

            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                float time = clock.ElapsedTime.AsMicroseconds();
                clock.Restart();
                time = time / 800;


                player1.move(time, map.tileMap, ref window, ref map);
                player2.move(time, map.tileMap, ref window, ref map);

                //window.Clear(Color.Black);
                //------------------------------------------------Draw Code------------------------------------------------//

                map.Draw(ref window);
                window.Draw(player1.Sprite);
                window.Draw(player2.Sprite);


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
