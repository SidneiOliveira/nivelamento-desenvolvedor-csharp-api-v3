using Newtonsoft.Json;

namespace Questao2
{
    public class Program
    {
        private static readonly string HTTP_GET = "football_matches";
        private static readonly string BASE_URL = "https://jsonmock.hackerrank.com/api/";
        public static void Main()
        {
            var footballRequest = new FootballRequest("Paris Saint-Germain", 2013);
            Console.WriteLine($"Team {footballRequest.TeamName} scored {GetTotalScoredGoals(footballRequest)} goals in {footballRequest.Year}");

            footballRequest = new FootballRequest("Chelsea", 2014);
            Console.WriteLine($"Team {footballRequest.TeamName} scored {GetTotalScoredGoals(footballRequest)} goals in {footballRequest.Year}");
        }

        public static int GetTotalScoredGoals(FootballRequest footballRequest)
        {
            using HttpClient httpClient = new();
            var rotaGet = HTTP_GET;
            httpClient.BaseAddress = new Uri(BASE_URL);
            var totalScoredGoals = 0;

            if (footballRequest.Year > 0)
            {
                rotaGet += $"?year={footballRequest.Year}";

                if (!string.IsNullOrEmpty(footballRequest.TeamName))
                {
                    rotaGet += $"&team1={footballRequest.TeamName}";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(footballRequest.TeamName))
                {
                    rotaGet += $"?team1={footballRequest.TeamName}";
                }
            }

            var response = httpClient.GetAsync(rotaGet).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<FootballDto> results = new();
                var footballResponse = JsonConvert.DeserializeObject<FootballResponse>(response.Content.ReadAsStringAsync().Result);

                var footballTeamData = footballResponse?.Data;
                var totalPages = footballResponse?.Total_pages;

                if (footballTeamData is not null)
                {
                    results.AddRange(footballTeamData);
                }

                for (int i = 2; i <= totalPages; i++)
                {
                    response = httpClient.GetAsync($"{rotaGet}&page={i}").Result;
                    footballResponse = JsonConvert.DeserializeObject<FootballResponse>(response.Content.ReadAsStringAsync().Result);

                    if (footballResponse?.Data is not null)
                    {
                        results.AddRange(footballResponse.Data);
                    }
                }
                foreach (var football in results)
                {
                    if (football != null)
                    {
                        totalScoredGoals += int.Parse(football.Team1goals);
                    }
                }
            }

            rotaGet = HTTP_GET;

            if (footballRequest.Year > 0)
            {
                rotaGet += $"?year={footballRequest.Year}";

                if (!string.IsNullOrEmpty(footballRequest.TeamName))
                {
                    rotaGet += $"&team2={footballRequest.TeamName}";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(footballRequest.TeamName))
                {
                    rotaGet += $"?team2={footballRequest.TeamName}";
                }
            }

            response = httpClient.GetAsync(rotaGet).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<FootballDto> results = new();
                var footballResponse = JsonConvert.DeserializeObject<FootballResponse>(response.Content.ReadAsStringAsync().Result);

                var footballTeamData = footballResponse?.Data;
                var totalPages = footballResponse?.Total_pages;

                if (footballTeamData is not null)
                {
                    results.AddRange(footballTeamData);
                }

                for (int i = 2; i <= totalPages; i++)
                {
                    response = httpClient.GetAsync($"{rotaGet}&page={i}").Result;
                    footballResponse = JsonConvert.DeserializeObject<FootballResponse>(response.Content.ReadAsStringAsync().Result);

                    if (footballResponse?.Data is not null)
                    {
                        results.AddRange(footballResponse.Data);
                    }
                }

                foreach (var football in results)
                {
                    if (football != null)
                    {
                        totalScoredGoals += int.Parse(football.Team2goals);
                    }
                }

                return totalScoredGoals;
            }
            return 0;
        }
    }
}