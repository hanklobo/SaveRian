namespace SaveRian
{
    public interface IIo
    {
        void Clear();
        void Write(string text);
        void WriteLine(string text);
        string Read();
    }
}