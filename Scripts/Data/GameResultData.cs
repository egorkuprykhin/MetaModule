namespace Infrastructure.Data
{
    public class GameResultData
    {
        public GameResult Result = GameResult.Undefined;
        public int Stars = 0;

        public bool IsWin() => Result == GameResult.Win;
        public bool IsLose() => Result == GameResult.Lose;
    }
}