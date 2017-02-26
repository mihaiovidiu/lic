using Licenta.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllSymptoms();
            Console.ReadLine();
        }

        static void GetAllConditions()
        {
            //
        }

        static void GetAllSymptoms()
        {
            using (LicentaEntities ctx = new LicentaEntities())
            {
                foreach (var symptom in ctx.Symptoms)
                    Console.WriteLine(symptom.nume);
            }
        }
    }
}
