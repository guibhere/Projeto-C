using FluentValidation;
using System.Collections.Generic;

public class DiretorFilmesInputPostDTO
{
    public string Nome { get; set; }
    public List<FilmeListaInputPutDTO> Filmes{get;set;}
}

public class DiretorFilmesInputPostDTOValidator : AbstractValidator<DiretorInputPostDTO> 
{ 
public DiretorFilmesInputPostDTOValidator(){
     RuleFor(d => d.Nome).NotNull();
     RuleFor(d => d.Nome).Length(2,255).WithMessage("Tamanho {TotalLength} inválido!");
}


}