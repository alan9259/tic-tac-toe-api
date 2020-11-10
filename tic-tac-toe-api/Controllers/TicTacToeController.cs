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
        private static int[] _board;
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
        public IEnumerable<int> CreateNewGame(Game game)
        {
            _board = new int[game.size];
            _rows = new int[game.size];
            _cols = new int[game.size];

            return _board;
        }

        [HttpPost("Move")]
        public int NextMove(Move move)
        {
            int n = _board.Length;

            int val = (move.player == 1) ? 1 : -1;
            int target = (move.player == 1) ? n : -n;

            _rows[move.row] += val;
            _cols[move.col] += val;

            if (move.row == move.col)
            {
                _diag += val;
            }

            if (move.row == n - move.col - 1)
            {
                _antiDiag += val;
            }

            if (_rows[move.row] == target || _cols[move.col] == target || _diag == target || _antiDiag == target) 
            {
                return move.player;
            }

            return 0;
        }
    }
}
