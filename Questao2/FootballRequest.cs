namespace Questao2
{
    public class FootballRequest
    {
        public string TeamName { get; private set; }
        public int Year { get; private set; }
        public FootballRequest(string teamName, int year)
        {
            TeamName = teamName;
            Year = year;
        }
    }
}
