using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damka
{
    class GameMove
    {
        public int fromRow{ get; set; }
        public int toRow{ get; set; }
        public int fromCol{ get; set; }
        public int toCol{ get; set; }
        
        public GameMove() { }

        public GameMove(GameMove move)
        {
            this.fromRow = move.fromRow;
            this.toRow = move.toRow;
            this.fromCol = move.fromCol;
            this.toCol = move.toCol;
        }
    }
}
