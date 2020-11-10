using System;

namespace tic_tac_toe_api
{

    public class Game
    {
        public int size { get; set; }
    }

    public class Move
    {
        public int row { get; set; }

        public int col { get; set; }

        public int player { get; set; }
    }
}
