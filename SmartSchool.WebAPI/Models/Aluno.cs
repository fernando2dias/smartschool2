namespace SmartSchool.WebAPI.Models
{
    public class Aluno
    {

        public Aluno()
        {


        }

        public Aluno(int id,
                     int matricula,
                     string nome,
                     string sobrenome,
                     string telefone,
                     DateTime dataNascimento
                     )
        {
            this.Id = id;
            this.Matricula = matricula;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DataNascimento = dataNascimento;

        }
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplina?>? AlunosDisciplinas { get; set; }

    }
}