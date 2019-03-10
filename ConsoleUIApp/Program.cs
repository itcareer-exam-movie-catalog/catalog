using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
