using System.ComponentModel.DataAnnotations;

namespace ASP.NET_MVC___C__Portfolio.Models
{

    public class Games
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double Valor { get; set; } // alterar esse decimal para outra coisa pois ele não ta contando nem a Virgula(,) nem o Ponto(.) // ou configurar em alguma pasta global.

        [Required]
        public string Plataformas { get; set; }

        [Required]
        [Display(Name = "Empresa Desenvolvedora")]
        public string EmpresaDesenvolvedora { get; set; }

        [Required]
        [DataType(DataType.Date)] 
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

    }
}
