namespace PizzaMaker.Code.Services.GameFinishDetector
{
    public struct GameResult
    {
        public readonly bool IsWin;
        
        public static GameResult Won => new(true);
        public static GameResult Lost => new(false);

        private GameResult(bool isWin) => IsWin = isWin;
    }
}