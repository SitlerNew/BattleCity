using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using IWshRuntimeLibrary;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace BattleCity
{
    class Program
    {
        static RenderWindow window;
        static Music[] musicThemes;
        

        static void Main(string[] args)
        {
            //------------------------------------------------Bound Code------------------------------------------------//
            window = new RenderWindow(new VideoMode(1280, 800), "Battle City");
            window.SetVerticalSyncEnabled(true);
            window.Closed += WinClosed;

            Image icon = new Image("..\\Source\\Textures\\panzer.png");
            window.SetIcon(64, 64, icon.Pixels);

            musicThemes = new [] { new Music("..\\Source\\Sounds\\theme1.ogg"), new Music("..\\Source\\Sounds\\theme2.ogg") };

            Thread musicThread = new Thread(new ThreadStart(SwitchMusic));
            musicThread.Start();

            GameHistory history = new GameHistory();


            //------------------------------------------------Game Code------------------------------------------------//    

            FieldMap map = new FieldMap("map.png");

            Player1 player1 = new Player1("players1.png", "Vitaliy", true, Color.Green, 544, 732);

            Player2 player2 = new Player2("players1.png", "Davidiy", true, Color.Red, 672, 38);

            Clock clock = new Clock();

            Debug f = new Debug();


            while (window.IsOpen)
            {
                window.DispatchEvents();
                float time = clock.ElapsedTime.AsMicroseconds();
                clock.Restart();
                time = time / 800;


                player1.update(time, map.tileMap, ref window, ref map, player1, player2, history);
                player2.update(time, map.tileMap, ref window, ref map, player1, player2, history);
                if(player1.isShoot)
                    player1.bullet.update(time, map.tileMap, ref window, player1, player2);

                f.FConsole("P1 \n X - " + player1.X + " Y - " + player1.Y + "\n\nP2 \n X - " + player2.X + " Y - " + player2.Y);


                //window.Clear(Color.Black);
                //------------------------------------------------Draw Code------------------------------------------------//

                map.Draw(ref window);
                window.Draw(player1.Sprite);
                window.Draw(player2.Sprite);
                if (player1.isShoot)
                    window.Draw(player1.bullet.Sprite);
                f.Print();

                //------------------------------------------------Show Code------------------------------------------------//
                window.Display();
            }

        }

        

        public static void SwitchMusic()
        {
            musicThemes[1].Play();
            musicThemes[1].Loop = true;
        }

        public static void WinClosed(object sender, EventArgs e)
        {
            window.Close();
        }
    }

}
