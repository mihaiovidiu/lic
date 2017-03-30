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
            GetSymptomsForCondition("APENDICITA ACUTA");
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
            using (LicentaEntities ctx = new LicentaEntities())
            {
                foreach (Condition c in ctx.Conditions)
                    Console.WriteLine("medical name: " +  c.medical_name + "; popular name:" + c.popular_name);
            }
        }

        static void GetSymptomsForCondition(string conditionName)
        {
            bool conditionExists = true;
            using (LicentaEntities ctx = new LicentaEntities())
            {
                //Condition c = ctx.Conditions.FirstOrDefault(cond => cond.medical_name.Contains(conditionName));
                Condition c = ctx.Conditions.FirstOrDefault(cond => cond.medical_name == conditionName);
                if (c != null)
                {
                    foreach (var symptomsCondition in c.symptoms_conditions)
                        Console.WriteLine(symptomsCondition.symptom.name + "-" + symptomsCondition.symptom.comments);
                }
                else
                    conditionExists = false;
            }

            if (!conditionExists)
                Console.WriteLine($"Condition '{conditionName}' does not exist in database");
        }
        static void GetConditionsForSymptoms(string symptomName)
        {
            bool symptomExists = true;
            using (LicentaEntities ctx = new LicentaEntities())
            {
                Symptom s = ctx.Symptoms.FirstOrDefault(symp => symp.name == symptomName);
                if (s != null)
                {
                    foreach (var symptomsCondition in s.symptoms_conditions)
                        Console.WriteLine(symptomsCondition.condition.medical_name + symptomsCondition.condition.popular_name);
                }
                else
                    symptomExists = false;
            }
            if (!symptomExists)
                Console.WriteLine($"Symptom '{symptomName}' does not exist in database");
        }

        
    }
}
