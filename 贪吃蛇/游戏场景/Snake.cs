using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.游戏场景
{
    /// <summary>
    /// 蛇移动方向枚举
    /// </summary>
    enum E_MoveDir
    {
        /// <summary>
        /// 上
        /// </summary>
        w,
        /// <summary>
        /// 左
        /// </summary>
        a,
        /// <summary>
        /// 下
        /// </summary>
        s,
        /// <summary>
        /// 右
        /// </summary>
        d,
    }

    /// <summary>
    /// 蛇类
    /// </summary>
    internal class Snake : IPrint
    {
        SnakeBody[] bodys;
        //记录当前蛇的长度
        private int nowLength;
        //当前移动的方向
        E_MoveDir dir;
        
        public Snake(int x , int y)
        {
            bodys = new SnakeBody[200];

            bodys[0] = new SnakeBody(E_BodyType.head , x, y);
            nowLength = 1;

            dir = E_MoveDir.d;
        }
        public void Print()
        {
            for (int i = 0; i < nowLength; i++)
            {
                bodys[i].Print();
            }
        }
        // 蛇移动
        public void Move()
        {
            //擦屁股
            SnakeBody lastBody = bodys[nowLength - 1];
            Console.SetCursorPosition(lastBody.pos.x, lastBody.pos.y);
            Console.Write("  ");

            for (int i = nowLength - 1; i > 0; i--)
            {
                bodys[i].pos = bodys[i - 1].pos;
            }
            switch (dir)
            {
                case E_MoveDir.w:
                    bodys[0].pos.y -= 1;
                    break;
                case E_MoveDir.a:
                    bodys[0].pos.x -= 2;
                    break;
                case E_MoveDir.s:
                    bodys[0].pos.y += 1;
                    break;
                case E_MoveDir.d:
                    bodys[0].pos.x += 2;
                    break;
            }
        }
        // 蛇转向
        public void ChangeDir(E_MoveDir dir)
        {
            //方向相同不动
            //相反也不动
            if (this.dir == dir ||
                nowLength > 1 && 
                (this.dir == E_MoveDir.w && dir == E_MoveDir.s ||
                 this.dir == E_MoveDir.a && dir == E_MoveDir.d ||
                 this.dir == E_MoveDir.s && dir == E_MoveDir.w ||
                 this.dir == E_MoveDir.d && dir == E_MoveDir.a))
            {
                return;
            }
            else
            {
                this.dir = dir;
            }
        }

        //撞墙撞身体
        public bool CheckEnd(Map map)
        {
            //是否和墙重合
            for (int i = 0; i < map.walls.Length; i++)
            {
                if (bodys[0].pos == map.walls[i].pos)
                {
                    return true;

                }
            }

            for (int i = 1; i < nowLength; i++)
            {
                if (bodys[0].pos == bodys[i].pos)
                {
                    return true;
                }
            }
            return false;

        }

        //吃事物相关 
        //随机食物
        public bool CheckSamePos(Position pos)
        {
            for(int i = 0;i < nowLength; i++)
            {
                if (bodys[i].pos == pos)
                {
                    return true;
                }
            }
            return false;
        }

        //吃食物
        public void EatFood(Food food ,ref int score)
        {
            if (bodys[0].pos == food.pos)
            {
                food.RandomPos(this);

                //长身体
                AddBody();
                //加分
                score += 5;
            }
        }

        private void AddBody()
        {
            SnakeBody frontBody = bodys[nowLength - 1];
            //长身体
            bodys[nowLength] = new SnakeBody(E_BodyType.body, frontBody.pos.x, frontBody.pos.y);
            //加长度
            nowLength++;
        }
    }
}
