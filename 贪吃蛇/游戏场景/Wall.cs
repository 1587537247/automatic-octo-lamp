using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.游戏场景
{
    /// <summary>
    /// 地图墙壁类
    /// </summary>
    internal class Wall : GameObj
    {
        public Wall(int x , int y)
        {
            pos = new Position(x, y);
        }

        public Wall() { }
        public override void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write("■");
        }
    }
}
