using System;
using Animals.Core;
namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();            
        }
    }
}
