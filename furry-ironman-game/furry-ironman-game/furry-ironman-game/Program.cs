using System;

namespace furry_ironman_game
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FurryGame game = new FurryGame())
            {
                game.Run();
            }
        }
    }
#endif
}

