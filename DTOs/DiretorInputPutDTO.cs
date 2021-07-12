using System;
using FluentValidation;

public class DiretorInputPutDTO {
     public string Nome { get; set; }
}
public class DiretorInputPutDTOValidator : AbstractValidator<DiretorInputPutDTO>{

    public DiretorInputPutDTOValidator(){
        RuleFor(diretor => diretor.Nome).NotNull().NotEmpty();
        RuleFor(diretor => diretor.Nome).Length(2,250).WithMessage("Tamanho informado {TotalLength} é Invalido");

    }

    private object RuleFor(Func<object, object> p)
    {
        throw new NotImplementedException();
    }
}
