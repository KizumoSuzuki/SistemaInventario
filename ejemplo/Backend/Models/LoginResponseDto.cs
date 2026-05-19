namespace CRUD.Models
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
