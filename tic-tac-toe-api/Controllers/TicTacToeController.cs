using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace tic_tac_toe_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicTacToeController : ControllerBase
    {
        private static Game _game;
        private static int[] _rows;
        private static int[] _cols;

        private static int _diag;
        private static int _antiDiag;

        private readonly ILogger<TicTacToeController> _logger;

        public TicTacToeController(ILogger<TicTacToeController> logger)
        {
            _logger = logger;
        }

        [HttpPost("NewGame")]
        public Game CreateNewGame(Game game)
        {
            int n = game.Size * game.Size;

            game.Board = new string[n];

            _game = game;

            _rows = new int[game.Size];
            _cols = new int[game.Size];
            _diag = 0;
            _antiDiag = 0;

            return _game;
        }

        [HttpPost("Move")]
        public int NextMove(Move move)
        {
            int n = _game.Size;

            int val = (move.Player == 1) ? 1 : -1;
            int target = (move.Player == 1) ? n : -n;

            _rows[move.Row] += val;
            _cols[move.Col] += val;

            if (move.Row == move.Col)
            {
                _diag += val;
            }

            if (move.Row == n - move.Col - 1)
            {
                _antiDiag += val;
            }

            if (_rows[move.Row] == target || _cols[move.Col] == target || _diag == target || _antiDiag == target) 
            {
                return move.Player;
            }

            return 0;
        }
    }
}
