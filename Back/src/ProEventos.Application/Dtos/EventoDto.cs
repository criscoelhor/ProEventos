using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório."),
        StringLength(50, MinimumLength = 3, ErrorMessage = "Tema deve ter no mínimo 3 e no máximo 50 caracteres.")]
        public string Tema { get; set; }

        [Display(Name ="Qtd de pessoas"),
        Range(1, 1200, ErrorMessage ="Quantidade de pessoas deve ser ebtre 1 e 1200.")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
        ErrorMessage ="Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage ="O {0} é obrigatório."),
        Phone(ErrorMessage ="O {0} é inválido.")]
        public string Telefone { get; set; }

        [Display(Name ="E-mail"),
        Required(ErrorMessage = "O campo {0} é obrigatório."),
        EmailAddress(ErrorMessage = "O campo {0} precisa ser um e-mail válido.")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}