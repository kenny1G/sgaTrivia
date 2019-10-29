using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using bc_awareness.Models;
using ChoETL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace bc_awareness.Services
{
    public class JsonFileLeaderboardCreatorService
    {
        private string file { get; set; }
        public JsonFileLeaderboardCreatorService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string CsvFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "leaderboard.csv"); }
        }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "leaderboard.json"); }
        }

        public void CreateJson()
        {
            string csv = System.IO.File.ReadAllText(CsvFileName);

            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(csv)
                .WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }
            var JsonString = sb.ToString();
            System.IO.File.WriteAllText(JsonFileName, JsonString);

        }

        // method to shuffle the json, this method is currently not being used
        private string ShuffleJson(string jsonAsString)
        {
            var JsonAsString = jsonAsString.Substring(1, jsonAsString.Length - 5);
            List<string> JsonsList = JsonAsString.Split("},").ToList();
            Random rnd = new Random();
            List<string> ShuffledQuestions = JsonsList.OrderBy(i => rnd.Next()).ToList();
            var ShuffledJsonAsString = String.Join("},", ShuffledQuestions);
            return "[" + ShuffledJsonAsString.Substring(0, ShuffledJsonAsString.Length - 1) + "}]";
        }

    }

}