using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damka
{
    public enum PlayerType
    {
        Black,
        White,
        TechnicalBlack,
        TechnicalWhite
    };
    public class GameState
    {
        public PlayerType playTurn { get; set; }
    }
}
