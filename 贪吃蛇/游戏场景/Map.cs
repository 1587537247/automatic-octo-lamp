using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.游戏场景
{
    internal class Map : IPrint
    {
        public Wall[] walls;
        public Map()
        {
            walls = new Wall[Game.w + (Game.h - 2)*2 ];
            int index = 0;
            for (int i = 0; i < Game.w ; i += 2)
            {
                walls[index] = new Wall(i, 0);
                index++;
                walls[index] = new Wall(i, Game.h - 1);
                index++;
            }
            for (int i = 1; i < Game.h - 1; i++)
            {
                walls[index] = new Wall(0,i);
                index++;
                walls[index] = new Wall(Game.w - 2, i);
                index++;
            }
        }

        public void Print()
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].Print();
            }
        }
    }
}
