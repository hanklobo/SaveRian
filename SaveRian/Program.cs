namespace SaveRian
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameEngine(new Io());
            game.Run();
        }
    }
}