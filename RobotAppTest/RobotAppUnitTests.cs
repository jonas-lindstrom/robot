namespace Jli.RobotAppTest
{
    using System.Drawing;
    using Jli.RobotApp;

    public class Tests
    {
        RobotRunner runner;

        [SetUp]
        public void Setup()
        {
            runner = RobotRunner.GetInstance();
        }

        [Test]
        public void TestGameArea()
        {
            // No negative areas            
            Assert.Throws<ArgumentException>(() => runner.SetUpGameArea([-1, 4]));
            Assert.Throws<ArgumentException>(() => runner.SetUpGameArea([4, -1]));

            // No empty areas            
            Assert.Throws<ArgumentException>(() => runner.SetUpGameArea([0, 4]));
            Assert.Throws<ArgumentException>(() => runner.SetUpGameArea([4, 0]));

            // Validate set up            
            runner.SetUpGameArea([4, 4]);
            var myGameArea = runner.GetGameArea();

            bool isOutside = myGameArea.IsOutsideBorders(4, 4); // The matrix is 4 x 4, so correct coordinates are 0-3.
            Assert.IsTrue(isOutside);
            isOutside = myGameArea.IsOutsideBorders(3, 3);
            Assert.IsFalse(isOutside);
            var areaType = myGameArea.GetGameAreaType();
            Assert.That(areaType, Is.EqualTo(GameArea.GameAreaType.Rectangle));
        }

        [Test]
        public void TestRobot()
        {
            // No negative coordinates            
            Assert.Throws<ArgumentException>(() => runner.SetUpRobots([new Point(-1, 4)]));
            Assert.Throws<ArgumentException>(() => runner.SetUpRobots([new Point(4, -1)]));

            // Validate set up
            Point[] points = [new Point(2, 2)];
            runner.SetUpRobots(points);
            var myRobot = runner.GetRobot(0);

            Assert.That(myRobot.GetXPosition(), Is.EqualTo(points[0].X));
            Assert.That(myRobot.GetYPosition(), Is.EqualTo(points[0].Y));
            Assert.That(myRobot.GetDirection(), Is.EqualTo(Robot.Direction.North));
        }

        [Test]
        public void TestGame()
        {
            // Run a positive game
            Point[] points = [new Point(2, 2)];
            int[] commands = [1, 4, 1, 3, 2, 3, 2, 4, 1, 0];
            runner.SetUpGameArea([4, 4]);
            runner.SetUpRobots(points);

            int index = 0;            
            while (index < commands.Length && commands[index] != 0)            
            {
                runner.ProcessCommand((RobotRunner.Command)commands[index], 0); // We only have one robot in this test
                index++;
            }

            Robot myRobot = runner.GetRobot(0);
            Assert.That(myRobot.GetXPosition(), Is.EqualTo(0));
            Assert.That(myRobot.GetYPosition(), Is.EqualTo(1));
            // Alternatively
            Assert.IsFalse(myRobot.HasCrashed());

            // Run a negative game
            points = [new Point(4, 1)];
            commands = [1, 1, 0];
            runner.SetUpGameArea([5, 3]);
            runner.SetUpRobots(points);
            
            index = 0;            
            while (index < commands.Length && commands[index] != 0)            
            {
                runner.ProcessCommand((RobotRunner.Command)commands[index], 0); // We only have one robot in this test
                index++;
            }
            
            myRobot = runner.GetRobot(0);
            Assert.That(myRobot.GetXPosition(), Is.EqualTo(-1));
            Assert.That(myRobot.GetYPosition(), Is.EqualTo(-1));
            // Alternatively
            Assert.IsTrue(myRobot.HasCrashed());
        }    
    }
}