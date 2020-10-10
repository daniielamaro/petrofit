namespace Domain.Entities
{
    public class User : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
    }
}