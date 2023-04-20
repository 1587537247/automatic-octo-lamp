using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    /// <summary>
    /// 开始和结束场景基类
    /// </summary>
    abstract class BeginBase : ISenceUpdate
    {
        protected string strTitle;
        protected string strOne;
        protected int nowIndex = 0;

        public abstract void EnterJDO();
        
        public virtual void Update()
        {
            //显示标题
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Game.w / 2 - strTitle.Length, 5);
            Console.Write(strTitle);
            //显示下方逻辑
            Console.SetCursorPosition(Game.w / 2 - strOne.Length, 9);
            Console.ForegroundColor = (nowIndex == 0) ? ConsoleColor.Green : ConsoleColor.White;
            Console.Write(strOne);
            Console.SetCursorPosition(Game.w / 2 - 4, 11);
            Console.ForegroundColor = (nowIndex == 1) ? ConsoleColor.Green : ConsoleColor.White;
            Console.Write("结束游戏");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    nowIndex--;
                    if (nowIndex < 0)
                    {
                        nowIndex = 0;
                    }
                    break;
                case ConsoleKey.S:
                    nowIndex++;
                    if (nowIndex > 1)
                    {
                        nowIndex = 1;
                    }
                    break;
                case ConsoleKey.J:
                    if (nowIndex == 0)
                    {
                        EnterJDO();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                    break;
            }
        }
    }
}
