using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    /// <summary>
    /// 游戏场景枚举
    /// </summary>
    enum E_GameSence
    {
        begin,
        game,
        end,
    }
    internal class Game
    {
        //控制台界面尺寸
        public const int w = 100;
        public const int h = 25;
        //当前场景
        public static ISenceUpdate nowSence;
        //初始化控制台
        public Game()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);

            SenceChange(E_GameSence.begin);
        }
        //游戏主循环
        public void GameLoop()
        {
            while (true)
            {
                if(nowSence != null) 
                {
                    nowSence.Update();
                }
            }
        }
        /// <summary>
        /// 场景切换
        /// </summary>
        /// <param name="type"></param>
        public static void SenceChange(E_GameSence type)
        {
            Console.Clear();
            switch (type)
            {
                case E_GameSence.begin:
                    nowSence = new BeginSence();
                    break;
                case E_GameSence.game:
                    nowSence = new GameSence();
                    break;
                case E_GameSence.end:
                    nowSence = new EndSence();
                    break;
            }
        }
    }
}
