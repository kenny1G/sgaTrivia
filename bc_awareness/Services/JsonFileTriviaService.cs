using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using bc_awareness.Models;
using Microsoft.AspNetCore.Hosting;

namespace bc_awareness.Services
{
    public class JsonFileTriviaService
    {
        public JsonFileTriviaService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "questions.json"); }
        }

        public IEnumerable<Trivia> GetQuestions()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Trivia[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }

}