using System.ComponentModel.DataAnnotations;

namespace FabricaGestao.Api.Modelos
{
    public class PessoaModelo
    {
        [Key] public int PesId { get; set; }

        public string PesNome { get; set; }

        public string? PesCpf { get; set; } = null;

        public string? PesCnpj { get; set; } = null;

        public string PesNumCelular { get; set; }

        public string? PesNumTelefone { get; set; }

        public string? PesEmail { get; set; }

        public string PesCep { get; set; }

        public string PesRua { get; set; }

        public string PesNumero { get; set; }

        public string PesBairro { get; set; }

        public string PesCidade { get; set; }

        public string PesEstado { get; set; }

        public int PesIncPor { get; set; }

        public DateTime PesIncEm { get; set; } = DateTime.Now;

        public int? PesAltPor { get; set; }

        public DateTime? PesAltEm { get; set; }

        public List<OrcamentoModelo> Orcamentos { get; set; } = new List<OrcamentoModelo>();
    }
}
