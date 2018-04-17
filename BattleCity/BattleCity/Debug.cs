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
    class Debug
    {
        static RenderWindow window;
        public Text console;
        private List<Text> arrTexts;

        public Debug()
        {
            window = new RenderWindow(new VideoMode(500, 300), "DebuggingVindow");
            window.SetVerticalSyncEnabled(true);
            window.Closed += WinClosed;

            Image icon = new Image("..\\Source\\Textures\\terminal.png");
            window.SetIcon(512, 512, icon.Pixels);

            console = new Text("", new Font("..\\Source\\Fonts\\11747.otf"), 20);
            console.Color = Color.White;

            arrTexts = new List<Text>();

            window.Position = new Vector2i(10,20);
        }

        public void DConsole(int a)
        {
            console.DisplayedString = a.ToString();
            arrTexts.Add(console);
        }

        public void DConsole(float a)
        {
            console.DisplayedString = a.ToString();
            arrTexts.Add(console);
        }

        public void DConsole(char a)
        {
            console.DisplayedString = a.ToString();
            arrTexts.Add(console);
        }

        public void DConsole(string a)
        {
            console.DisplayedString = a;
            arrTexts.Add(console);
        }

        public void Print(Text a)
        {

            window.DispatchEvents();

            window.Clear(Color.Black);

            window.Draw(a);

            window.Display();
        }

        public void Print()
        {

            window.DispatchEvents();

            window.Clear(Color.Black);


            for (int i = 0; i < arrTexts.Count; i++)
                window.Draw(arrTexts[i]);

            window.Display();
        }


        public static void WinClosed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
