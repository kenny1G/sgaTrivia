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
    public class JsonCreatorService
    {
        private string file { get; set; }
        public JsonCreatorService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string CsvFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "mockCSV.csv"); }
        }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "questions.json"); }
        }

        public void CreateJson()
        {
            string csv = System.IO.File.ReadAllText(CsvFileName);

            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(csv)
                .WithFirstLineHeader()
                )
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }

            System.IO.File.WriteAllText(JsonFileName, sb.ToString());
        }

    }

}