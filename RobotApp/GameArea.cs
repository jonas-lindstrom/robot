namespace Jli.RobotApp
{
    public class GameArea
    {
        public enum GameAreaType 
        {
            NotDefined,
            Rectangle
        }               

        public GameArea SetUpGameArea(GameAreaType gameAreaType, int[] areaMatrix)
        {
            if (gameAreaType == GameAreaType.Rectangle)
            {
                return new GameAreaRectangle(areaMatrix);
            }
            throw new ArgumentException ("GameArea: Given Game Area Type is not suported yet.");
        }

        // Each Game Area Type has to override these methods
        public virtual bool IsOutsideBorders (int x, int y)
        {
            return false;
        }

        public virtual GameAreaType GetGameAreaType()
        {
            return GameAreaType.NotDefined;
        }
    }
}