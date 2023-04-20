using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.游戏场景
{
    /// <summary>
    /// 蛇身体类型枚举
    /// </summary>
    enum E_BodyType
    {
        head,
        body,
    }
    /// <summary>
    /// 蛇身体类
    /// </summary>
    internal class SnakeBody : GameObj
    {
        private E_BodyType bodyType;
        public SnakeBody(E_BodyType type, int x , int y)
        {
            bodyType = type;
            pos = new Position(x, y);
        }
        public override void Print()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = (bodyType == E_BodyType.head) ? ConsoleColor.Yellow : ConsoleColor.Blue;
            Console.Write((bodyType == E_BodyType.head) ? "●" : "◎");
        }
    }
}
