using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity
{

    class State
    {
        public float x;
        public float y;
        public float dx;
        public float dy;
        public float width;
        public float height;
        public float currentSpeed;
        public int dir;
        public bool isShoot;
    }

    class Memento
    {
        public State state;

        public Memento(State states)
        {
            state = new State();
            state = states;
        }
    }

    class GameHistory
    {
        public Stack<Memento> History { get; private set; }

        public GameHistory()
        {
            History = new Stack<Memento>();
        }

        public void AddHistory(Memento memento)
        {
            History.Push(memento);
        }

        public Memento GetHistory()
        {
            return History.Pop();
        }
    }
}
