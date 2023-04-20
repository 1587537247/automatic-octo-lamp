using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.游戏场景
{
    /// <summary>
    /// 游戏对象类
    /// </summary>
    abstract class GameObj : IPrint
    {
        public Position pos;
       //绘制
        public abstract void Print();
    }
}
