using System.Drawing;

namespace Jli.RobotApp
{
    public sealed class RobotRunner
    {
        private GameArea myGameArea;
        private Robot[] myRobots;
        private static RobotRunner? instance;

        public enum Command
        {
            Quit = 0,
            Forward = 1,
            Backward = 2,
            Clockwise = 3,
            CounterClockwise = 4
        }

        private RobotRunner()
        {
            myGameArea = new GameArea();
            myRobots = [new Robot()];
        }

        public void ProcessCommand(Command command, int robot)
        {
            myRobots[robot].ProcessCommand(command);
            if (myGameArea.IsOutsideBorders(myRobots[robot].GetXPosition(), myRobots[robot].GetYPosition()))
            {
                myRobots[robot].Crash();
                // Since we do not allow a robot to reenter the area I would like to stop the program here
                // But if we allow several robots that is not a correct solution.
            }
        }

        #region GameArea

        // GameAreaType Rectangle only existing for now
        public void SetUpGameArea(int[] areaMatrix)
        {
            myGameArea = new GameArea().SetUpGameArea(GameArea.GameAreaType.Rectangle, areaMatrix);
        }

        public GameArea GetGameArea()
        {
            return myGameArea;
        }

        #endregion

        #region Robot

        public void SetUpRobots(Point[] startingPoints)
        {
            if (startingPoints.Length < 1)
            {
                throw new ArgumentException("RobotRunner: At least one point has to be given.");
            }

            myRobots = new Robot[startingPoints.Length];
            for (int i = 0; i < startingPoints.Length; i++)
            {
                myRobots[i] = new Robot().SetUpRobot(startingPoints[i].X, startingPoints[i].Y);
            }
        }

        public Robot GetRobot(int index)
        {
            return myRobots[index];
        }

        #endregion        

        //Not thread-safe
        public static RobotRunner GetInstance()
        {
            if (instance == null)
            {
                instance = new RobotRunner();
            }

            return instance;
        }
    }
}