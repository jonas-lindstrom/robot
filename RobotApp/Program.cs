using System.Drawing;

namespace Jli.RobotApp
{
    public class Program
    {
        // This method could have more exception-handling and
        // being more robust. There are a lot of assumtions on the input.
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter configuration eg. 4,4,2,2");
            string? input = Console.ReadLine();
            if (input != null && input.Length >= 7)
            {
                // Assumption:
                // One string containing only comma separated integers eg "4,4,2,2"
                int[] configuration = ConvertArgsToInt(input);
                int[] areaMatrix = [configuration[0], configuration[1]];
                Point[] startingPoints = [new Point(configuration[2], configuration[3])];
                var runner = RobotRunner.GetInstance();
                runner.SetUpGameArea(areaMatrix);
                runner.SetUpRobots(startingPoints);
            }
            else
            {
                Console.WriteLine("Running with default values ie a rectangle with 4 x 4 squares. A robot in square 2, 2, facing north.");
                int[] areaMatrix = [4, 4];
                Point[] startingPoints = [new Point(2, 2)];
                var runner = RobotRunner.GetInstance();
                runner.SetUpGameArea(areaMatrix);
                runner.SetUpRobots(startingPoints);
            }

            Console.WriteLine("Enter a command string ending with a 0, eg. 1,4,1,3,2,3,2,4,1,0");
            input = Console.ReadLine();
            if (input != null)
            {
                int[] commands = ConvertArgsToInt(input);
                var runner = RobotRunner.GetInstance();
                int index = 0;
                while (index < commands.Length && commands[index] != 0)
                {
                    runner.ProcessCommand((RobotRunner.Command)commands[index], 0); // We only support input for one robot 
                    index++;
                }

                Console.WriteLine($"[{runner.GetRobot(0).GetXPosition()}, {runner.GetRobot(0).GetYPosition()}]"); // We only support input for one robot 
            }
        }

        // There is a lot to think of here. I choose a simple solution with not much exception handling etc.
        private static int[] ConvertArgsToInt(string input)
        {
            string[] stringValues = input.Split(',');

            int[] intValues = new int[stringValues.Length];
            for (int i = 0; i < stringValues.Length; i++)
            {
                if (int.TryParse(stringValues[i], out int result))
                {
                    intValues[i] = result;
                }
                else
                {
                    Console.WriteLine($"Error converting '{stringValues[i]}' to an integer. Using default value (0).");
                }
            }

            return intValues;
        }
    }
}