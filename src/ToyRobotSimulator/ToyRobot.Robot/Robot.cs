using ToyRobot.Interfaces;
using ToyRobot.Domain;

namespace ToyRobot.Builder
{
    public class Robot : IRobot
    {
        private Position? _position;
        private Direction _direction;
        private readonly Tabletop _tabletop;
        private bool _isPlaced;
        public Robot(Tabletop tabletop)
        {
            _tabletop = tabletop;
        }
        public bool Move()
        {
            if (!_isPlaced || _position == null)
                return false;
            bool isMoved = false;
            switch (_direction)
            {
                case Direction.NORTH:
                    if (_position.Y < _tabletop.Rows - 1)
                    {
                        _position.Y++;
                        isMoved = true;
                    }
                    break;
                case Direction.SOUTH:
                    if (_position.Y > 0)
                    {
                        _position.Y--;
                        isMoved = true;
                    }
                    break;
                case Direction.EAST:
                    if (_position.X < _tabletop.Cols - 1)
                    {
                        _position.X++;
                        isMoved = true;
                    }
                    break;
                case Direction.WEST:
                    if (_position.X > 0)
                    {
                        _position.X--;
                        isMoved = true;
                    }
                    break;
            }
            return isMoved;
        }
        public string Report()
        {
            var report = "Place me on table top";
            if (_isPlaced)
                report = $"{_position},{_direction}";
            Console.WriteLine(report);
            return report;
        }
        public bool Left()
        {
            //ignore
            if (!_isPlaced)
                return false;

            switch (_direction)
            {
                case Direction.NORTH:
                    _direction = Direction.WEST;
                    break;
                case Direction.SOUTH:
                    _direction = Direction.EAST;
                    break;
                case Direction.EAST:
                    _direction = Direction.NORTH;
                    break;
                case Direction.WEST:
                    _direction = Direction.SOUTH;
                    break;
            }
            return true;
        }
        public bool Right()
        {
            //ignore
            if (!_isPlaced)
                return false;
            switch (_direction)
            {
                case Direction.NORTH:
                    _direction = Direction.EAST;
                    break;
                case Direction.SOUTH:
                    _direction = Direction.WEST;
                    break;
                case Direction.EAST:
                    _direction = Direction.SOUTH;
                    break;
                case Direction.WEST:
                    _direction = Direction.NORTH;
                    break;
            }
            return true;
        }
        public bool Place(string param)
        {
            if (string.IsNullOrEmpty(param))
                throw new ArgumentException("Place params are not valid");

            var _param = param.Trim().Split(",");
            if (_param.Length < 2)
                throw new ArgumentException("Place params are not valid");

            if (!ushort.TryParse(_param[0], out var _x) ||
                !ushort.TryParse(_param[1], out var _y))
                throw new ArgumentException("Position is not valid");

            if (_x > _tabletop.Cols || _y > _tabletop.Rows)
                throw new ArgumentException("Position is out of table");
            _position = new Position(_x, _y);
            if (_param.Length == 3 && _param[2] != null)
            {
                if (!Enum.TryParse(_param[2].ToUpper(), out _direction))
                    throw new ArgumentException("Direction is not valid");
            }
            else
                if (!_isPlaced)
                  throw new ArgumentException("Direction is not specified");

            _isPlaced = true;
            return true;
        }
    }
}
