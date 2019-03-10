using System;
using Business.Businesses;

namespace ConsoleUIApp
{
    class Program
    {
        public static BusinessActors businessActors = new BusinessActors();

        static void Main(string[] args)
        {
            Console.WriteLine(businessActors.getActor(1).firstName);
        }
    }
}
