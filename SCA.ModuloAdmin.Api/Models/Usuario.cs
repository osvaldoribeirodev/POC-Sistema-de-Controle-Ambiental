namespace SCA.ModuloAdmin.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Situacao { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
