using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.游戏场景;

namespace 贪吃蛇
{
    /// <summary>
    /// 游戏场景
    /// </summary>
    internal class GameSence : ISenceUpdate
    {
        Map map;
        Snake snake;
        Food food;
        private int updateIndex1 = 0;
        private int updateIndex2 = 0;
        int score;
        public GameSence()
        {
            map = new Map();
            snake = new Snake(40 ,10);
            food = new Food(snake);
            score = 0;
        }
        //帧更新
        public void Update()
        {
            //降速
            if (updateIndex1 % 4444 == 0)
            {
                if (updateIndex2 % 4 == 0)
                {
                    map.Print();
                    food.Print();

                    //每次移动完画
                    snake.Move();
                    snake.Print();

                    

                    //检测是否撞墙
                    if (snake.CheckEnd(map))
                    {
                        Console.SetCursorPosition(Game.w/2 - 14, Game.h - 2);
                        Console.ForegroundColor = ConsoleColor.Magenta; 
                        Console.Write("你的得分是：{0} 按任意键继续",score);
                        Console.ReadKey(true);
                        Game.SenceChange(E_GameSence.end);
                    }
                    updateIndex1 = 0;
                    updateIndex2 = 0;

                    //判断是否吃到食物
                    snake.EatFood(food ,ref score);
                }
                updateIndex2++;
            }
            updateIndex1++;

            //在控制台中检测玩家输入但程序不卡住
            //判断有没有键盘输入
            //会消耗性能使循环变慢
            if (Console.KeyAvailable)
            {
                //在间隔帧外检测输入
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDir(E_MoveDir.w);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDir(E_MoveDir.s);
                        break;
                    case ConsoleKey.A:
                        snake.ChangeDir(E_MoveDir.a);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDir(E_MoveDir.d);
                        break;
                }
            }
        }
    }
}
