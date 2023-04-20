using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    /// <summary>
    /// 开始场景
    /// </summary>
    internal class BeginSence : BeginBase
    {
        public BeginSence()
        {
            strTitle = "贪吃蛇";
            strOne = "开始游戏";
            
        }

        public override void EnterJDO()
        {
            Game.SenceChange(E_GameSence.game);
        }

    }
}
