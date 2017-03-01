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
            GetSymptomsForCondition("Anemie");
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
                    Console.WriteLine("medical name: " +  c.medical_name + "; popular name:" + c.popular_name);
            }
        }

        static void GetSymptomsForCondition(string conditionName)
        {
            bool conditionExists = true;
            using (LicentaEntities ctx = new LicentaEntities())
            {
                Condition c = ctx.Conditions.FirstOrDefault(cond => cond.medical_name.Contains(conditionName));
                if (c != null)
                {
                    foreach (var symptomsCondition in c.symptoms_conditions)
                        Console.WriteLine(symptomsCondition.symptom.name);
                }
                else
                    conditionExists = false;
            }

            if (!conditionExists)
                Console.WriteLine($"Condition '{conditionName}' does not exist in database");
        }
        
    }
}
