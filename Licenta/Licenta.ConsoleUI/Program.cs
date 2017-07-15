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
            //GetConditionsForSymptoms("tahicardie");
            GetAllConditions();
            Console.ReadLine();
        }

        static void GetAllSymptoms()
        {
            using (LicentaEntities ctx = new LicentaEntities())
            {
                foreach (var symptom in ctx.Symptoms)
                    Console.WriteLine(symptom.name + " " + symptom.Id + "; Category = " + symptom.category);
            }
        }

        static void GetAllSymptomCategories()
        {
            using (LicentaEntities ctx = new LicentaEntities())
            {
                foreach (var categoryName in ctx.Symptoms.Select(s => s.category).Distinct())
                    Console.WriteLine(categoryName);
            }
        }

        static void GetSymptomsInCategory(string categoryName)
        {
            using (LicentaEntities ctx = new LicentaEntities())
            {
                var symptomsInCategory = ctx.Symptoms.Where(s => s.category == categoryName);
                Console.WriteLine("Conditions in '" + categoryName + "' category:");
                foreach (Symptom s in symptomsInCategory)
                    Console.WriteLine(s.name);
            }
        }

        static void GetAllConditions()
        {
            using (LicentaEntities ctx = new LicentaEntities())
            {
                foreach (Condition c in ctx.Conditions)
                    Console.WriteLine("medical name: " + c.medical_name + "; popular name:" + c.popular_name);
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
        static void GetConditionsForSymptom(string symptomName)
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

        static void GetConditionsForSymptoms(params string[] symptomNames)
        {
            using (LicentaEntities ctx = new LicentaEntities())
            {
                var conditions = ctx.Conditions.Where(condition =>
                    symptomNames.All(s => condition.symptoms_conditions.Select(sc => sc.symptom.name).Contains(s)));
                
                foreach (Condition c in conditions)
                    Console.WriteLine(c.medical_name + " " + c.popular_name);
            }
        }

        static void GetSymptomsforBodyPart(string bodyPart)
        {
            using (LicentaEntities ctx = new LicentaEntities())
            {
                var symptomsInBodyPart = ctx.Symptoms.Where(s => s.bodyPart == bodyPart);
                Console.WriteLine("Syptoms in '" + bodyPart + "' category:");
                foreach (Symptom s in symptomsInBodyPart)
                    Console.WriteLine(s.name);
            } 
        }

        static void GetAllBodyParts()
        {
            using (LicentaEntities ctx = new LicentaEntities())
            {
                foreach (var bodyPart in ctx.Symptoms.Select(s => s.bodyPart).Distinct())
                    Console.WriteLine(bodyPart);
            }
        }

    }
}
