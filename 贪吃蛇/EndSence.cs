using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    /// <summary>
    /// 结束场景
    /// </summary>
    internal class EndSence : BeginBase
    {
        public EndSence()
        {
            strTitle = "游戏结束";
            strOne = "回到开始界面";
        }
        public override void EnterJDO()
        {
            Game.SenceChange(E_GameSence.begin);
        }
    }
}
