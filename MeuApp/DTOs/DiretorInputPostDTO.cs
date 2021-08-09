using FluentValidation;

public class DiretorInputPostDTO
{
    public string Nome { get; set; }
}

public class DiretorInputPostDTOValidator : AbstractValidator<DiretorInputPostDTO> 
{ 
public DiretorInputPostDTOValidator(){
     RuleFor(d => d.Nome).NotNull();
     RuleFor(d => d.Nome).Length(2,255).WithMessage("Tamanho {TotalLength} inválido!");
}


}