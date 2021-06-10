using System;

namespace TiledCS.Extensions.MonoGame.Example
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using (Game game = new Game())
                game.Run();
        }
    }
}
