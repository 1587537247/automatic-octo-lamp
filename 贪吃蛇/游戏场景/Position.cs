using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.游戏场景
{

    /// <summary>
    /// 位置结构体
    /// </summary>
    struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        //运算符重载
        //判断是否碰到
        public static bool operator ==(Position left, Position right)
        {
            if (left.x == right.x && left.y == right.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Position left, Position right)
        {
            if (left.x == right.x && left.y == right.y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
