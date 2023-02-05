using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTest
{
    public class PlayerInfo
    {
        public string name;
        public float SPM;
        public float SPS;
        public static List<PlayerInfo> players = new List<PlayerInfo>();
        public PlayerInfo(PlayerInfo player)
        {
            this.name = player.name;
            this.SPM = player.SPM;
            this.SPS = player.SPS;
        }
        public PlayerInfo() { }
    }
}
