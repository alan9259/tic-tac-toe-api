using System;

namespace tic_tac_toe_api
{

    public class Game
    {
        public int Size { get; set; }
        public string[] Board { get; set; }
    }

    public class Move
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Player { get; set; }
    }
}
