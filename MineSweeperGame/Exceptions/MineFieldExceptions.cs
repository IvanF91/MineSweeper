using System;

namespace MineSweeperGame.Exceptions
{
    public class GameException : Exception
    {
        public GameException(string message)
            :base(message) { }
    }

    public class NullMineFieldException : GameException
    {
        public NullMineFieldException(string message)
            :base(message) { }
    }

    public class InvalidRowNumberException : GameException
    {
        public InvalidRowNumberException(string message)
            :base(message) { }
    }

    public class InvalidColumnNumberException : GameException
    {
        public InvalidColumnNumberException(string message)
            : base(message) { }
    }
}
