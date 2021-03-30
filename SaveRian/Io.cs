using System;

namespace SaveRian
{
    public class Io : IIo
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}