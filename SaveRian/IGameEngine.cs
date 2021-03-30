namespace SaveRian
{
    public interface IGameEngine
    {
        int LoadUserInput();
        int DesiredPosition(int totalSoldiers);
        void Run();
    }
}