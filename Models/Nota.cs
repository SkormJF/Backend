namespace Backend.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? Title { get; set; }
        public string? Estado { get; set; } 
        public string? User_Id { get; set; }

    }
}