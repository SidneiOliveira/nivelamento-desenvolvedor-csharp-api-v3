namespace Questao2
{
    public class FootballResponse
    {
        public int Page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<FootballDto>? Data { get; set; }

    }
}
