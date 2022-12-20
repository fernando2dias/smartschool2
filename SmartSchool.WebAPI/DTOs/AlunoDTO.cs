namespace SmartSchool.WebAPI.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; }
        public bool Ativo { get; set; }
    }
}