using System.Text.Json.Serialization;

namespace AgroSimply.Models
{
    public class ProdutorModels
    {
        public int IdProdutor { get; set; }
        public string? Nome { get; set; }
        public string? Email{ get; set; }
        public string? Senha { get; set; }
        public double CPF { get; set; }
        public double CNPJ { get; set; }
        public double Telefone { get; set; }   
        public string? Atividade { get; set; }

       // [JsonIgnore]
      ///  public IList<PropriedadeModels> Propriedades { get; set; } // Propriedade de navegação para as Propriedades

    }
}
