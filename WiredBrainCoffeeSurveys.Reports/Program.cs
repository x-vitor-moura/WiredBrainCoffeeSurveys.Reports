﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WiredBrainCoffeeSurveys.Reports.Services;

namespace WiredBrainCoffeeSurveys.Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quitApp = false;

            do
            {
                Console.WriteLine("Please specify a report to run (rewards, comments, tasks, quit):");
                var selectedReport = Console.ReadLine();

                Console.WriteLine("Please specify witch quarter of data (q1, q2):");
                var selectedFile = Console.ReadLine();

                var surveyResults = SurveyDataService.GetSurveyDataByFileName(selectedFile);

                switch (selectedReport)
                {
                    case "rewards":
                        RewardReportServices.GenerateWinnerEmails(surveyResults);
                        break;
                    case "comments":
                        CommentsReportService.GenerateCommentsReport(surveyResults);
                        break;
                    case "tasks":
                        TasksReportService.GenerateTasksReport(surveyResults);
                        break;
                    case "quit":
                        quitApp = true;
                        break;
                    default:
                        Console.WriteLine("Sorry, that's not a valid option.");
                        break;
                }

                Console.WriteLine();

            } while (!quitApp);
        }
    }
}
