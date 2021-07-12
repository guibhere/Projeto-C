using FluentValidation;

public class FilmeInputPostDTO {
     public string Titulo { get; set; }
     public long DiretorID { get; set; }

     public FilmeInputPostDTO(string titulo,long id){
          Titulo = titulo;
          DiretorID = id;
     }
     
}

public class MovieInputPostDTOValidator : AbstractValidator<FilmeInputPostDTO> {
    public MovieInputPostDTOValidator() {
        RuleFor(f=> f.Titulo).NotNull().NotEmpty();
        RuleFor(f => f.Titulo).Length(2, 250).WithMessage("Tamanho {TotalLength} é inválido");
        RuleFor(f=> f.DiretorID).NotNull().NotEmpty();

    }
}