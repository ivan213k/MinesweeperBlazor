namespace MinesweeperServer.Models
{
    public class ComplexityLevel
    {
        public ComplexityLevel()
        {

        }

        public ComplexityLevel(int id, string complexity)
        {
            Id = id;
            Complexity = complexity;
        }

        public int Id { get; set; }
        public string Complexity { get; set; }
    }
}
