using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.游戏场景
{
    /// <summary>
    /// 食物类
    /// </summary>
    internal class Food : GameObj
    {
        public Food(Snake snake)
        {
            RandomPos(snake);
        } 
        public override void Print()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write("◆");
        }
        //随机位置的行为 与蛇位置有关
        public void RandomPos(Snake snake)
        {
            Random r = new Random();
            int x = r.Next(4, Game.w / 2 - 3) * 2;
            int y = r.Next(2, Game.h - 4);
            pos = new Position(x, y);
            if (snake.CheckSamePos(pos))
            {
                RandomPos(snake);
            } 
        }
    }
}
