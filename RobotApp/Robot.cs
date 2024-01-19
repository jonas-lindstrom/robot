namespace Jli.RobotApp
{
    public class Robot
    {
        private int posX = 2;
        private int posY = 2;
        private Direction direction = Direction.North;

        public enum Direction
        {
            North,
            East,
            South,
            West
        }

        public void ProcessCommand(RobotRunner.Command command)
        {
            if (direction == Direction.North)
            {
                if (command == RobotRunner.Command.Forward)
                {
                    posY--;
                }
                if (command == RobotRunner.Command.Backward)
                {
                    posY++;
                }
                if (command == RobotRunner.Command.Clockwise)
                {
                    direction = Direction.East;
                }
                if (command == RobotRunner.Command.CounterClockwise)
                {
                    direction = Direction.West;
                }
            }
            else if (direction == Direction.East)
            {
                if (command == RobotRunner.Command.Forward)
                {
                    posX++;
                }
                if (command == RobotRunner.Command.Backward)
                {
                    posX--;
                }
                if (command == RobotRunner.Command.Clockwise)
                {
                    direction = Direction.South;
                }
                if (command == RobotRunner.Command.CounterClockwise)
                {
                    direction = Direction.North;
                }
            }
            else if (direction == Direction.South)
            {
                if (command == RobotRunner.Command.Forward)
                {
                    posY++;
                }
                if (command == RobotRunner.Command.Backward)
                {
                    posY--;
                }
                if (command == RobotRunner.Command.Clockwise)
                {
                    direction = Direction.West;
                }
                if (command == RobotRunner.Command.CounterClockwise)
                {
                    direction = Direction.East;
                }
            }
            else if (direction == Direction.West)
            {
                if (command == RobotRunner.Command.Forward)
                {
                    posX--;
                }
                if (command == RobotRunner.Command.Backward)
                {
                    posX++;
                }
                if (command == RobotRunner.Command.Clockwise)
                {
                    direction = Direction.North;
                }
                if (command == RobotRunner.Command.CounterClockwise)
                {
                    direction = Direction.South;
                }
            }
        }

        public void Crash ()
        {
            posX = -1;
            posY = -1;
        }

        public bool HasCrashed ()
        {
            return posX == -1 && posY == -1;
        }

        public Robot SetUpRobot(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Robot: Given coordinates are invalid.");
            }

            posX = x;
            posY = y;

            return this;
        }

        public Direction GetDirection()
        {
            return direction;
        }

        public int GetXPosition()
        {
            return posX;
        }

        public int GetYPosition()
        {
            return posY;
        }
    }
}