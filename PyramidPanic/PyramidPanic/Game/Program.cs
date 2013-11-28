using System;

namespace PyramidPanic
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (PyramidPanic game = new PyramidPanic())
            {
                game.Run();
            }
        }
    }
#endif
}

