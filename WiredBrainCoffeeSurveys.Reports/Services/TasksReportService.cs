﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WiredBrainCoffeeSurveys.Reports.Services
{
    public static class TasksReportService
    {
        public static void GenerateTasksReport(SurveyResults results)
        {
            var tasks = new List<string>();

            //Calculated Values
            double responseRate = results.NumberResponded / results.NumberSurveyed; ;
            double overallScore = (results.ServiceScore + results.CoffeeScore + results.FoodScore + results.PriceScore) / 4;

            if (results.CoffeeScore < results.FoodScore)
            {
                tasks.Add("Investigate coffee recipes and ingredients.");
            }


            //if (overallScore > 8)
            //{
            //    tasks.Add("Work with leadership to reward staff.");
            //}
            //else
            //{
            //    tasks.Add("Work with employees for improvements ideas.");
            //}


            //replace if statement above
            tasks.Add(overallScore > 8.0 ? "Work with leadership to reward staff." : "Work with employees for improvements ideas.");


            if (responseRate < .33)
            {
                tasks.Add("Research options to improve response rate.");
            }
            else if (responseRate >= .33 && responseRate < .66)
            {
                tasks.Add("Reward participants with free coffee coupon.");
            }
            else
            {
                tasks.Add("Rewards participants with discount coffee coupon.");
            }

            ////switch case with when (option for if statement above)
            //tasks.Add(responseRate switch
            //{
            //    var rate when rate < .33 => "Research options to improve response rate.",
            //    var rate when rate >= .33 && rate < .66 => "Reward participants with free coffee coupon.",
            //    var rate when rate >= .66 => "Rewards participants with discount coffee coupon."
            //});


            //Advanced Switch statement
            tasks.Add(results.AreaToImprove switch
            {
                "RewardsProgram" => "Revisit the rewards deals.",
                "Cleanliness" => "Contact the cleaning vendor.",
                "MobileApp" => "Contact consulting firm about app.",
                _ => "Investigate individual comments for ideas."
            });


            Console.WriteLine(Environment.NewLine + "Tasks Output:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }

            File.WriteAllLines("TasksReport.csv", tasks);
        }
    }
}
