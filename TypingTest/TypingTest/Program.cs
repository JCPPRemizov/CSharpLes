using System.Text;

namespace TypingTest
{
    internal class Program
    {
        Typing typ = new Typing();
        static void Main(string[] args)
        {
            while (true)
            {
                Typing.TpTest();
            }
        }
    }
}