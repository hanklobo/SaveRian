namespace SaveRian
{
    public interface IGameEngine
    {
        int LoadUserInput(string forcedInput = "");
        int DesiredPosition(int totalSoldiers);
        void Run();
    }
}