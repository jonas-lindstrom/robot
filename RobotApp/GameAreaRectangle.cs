namespace Jli.RobotApp
{
    public class GameAreaRectangle : GameArea
    {
        private int xMax = 0;
        private int yMax = 0;

        public GameAreaRectangle (int[] areaMatrix)
        {
            if (areaMatrix.Length != 2)
            {
                throw new ArgumentException("GameAreaRectangle: Incorrect amount of values in area matrix.");
            }
            //Assumtion: we always get positiv numbers describing the area
            if (areaMatrix[0] < 1 || areaMatrix[1] < 1)
            {
                throw new ArgumentException("GameAreaRectangle: Illegal value in area matrix. Use positive integers larger than 0.");
            }

            // According to spec. we get width then height
            xMax = areaMatrix[0] - 1; // An area is defined as eg. 4x4 which gives us coordinates 0-3
            yMax = areaMatrix[1] - 1;
        }

        public override bool IsOutsideBorders (int x, int y) 
        {
            return x < 0 || x > xMax || y < 0 || y > yMax;
        }

        public override GameAreaType GetGameAreaType()
        {
            return GameAreaType.Rectangle;
        }
    }
}