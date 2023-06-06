using System.Text.Json.Serialization;

namespace AgroSimply.Models
{
    public class PropriedadeModels
    {
        public int IdPropriedade { get; set; }
        public  int IdProdutor { get; set; }
        public string? Nome { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
        public string? Endereco { get; set; }
        public float Extensão { get; set; }
        public string? Cultura { get; set; }
        public string? Estado { get; set; }

        //[JsonIgnore]
        //public ProdutorModels Produtor { get; set; }


    }
}
