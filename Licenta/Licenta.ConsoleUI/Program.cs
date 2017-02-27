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

        static void GetAllSymptoms()
        {
            using (LicentaEntities ctx = new LicentaEntities())
            {
                foreach (var symptom in ctx.Symptoms)
                    Console.WriteLine(symptom.name + " " + symptom.Id);
            }
        }

        static void GetAllConditions()
        {
            using (LicentaEntities context = new LicentaEntities())
            {
                foreach (Condition c in context.Conditions)
                    Console.WriteLine(c.medical_name + "///" + c.popular_name);
            }
        }
    }
}
