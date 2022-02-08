using FluentValidation;
public class FilmeListaInputPutDTO
{

    public string Titulo { get; set; }
    public FilmeListaInputPutDTO(string titulo)
    {
        Titulo = titulo;
    }
}

public class FilmeListaInputPutDTOValidator : AbstractValidator<FilmeInputPutDTO>
{
    public FilmeListaInputPutDTOValidator()
    {
        RuleFor(filme => filme.Id).NotNull();
        RuleFor(filme => filme.Titulo).NotNull();
        RuleFor(filme => filme.Titulo).Length(2, 250).WithMessage("Tamanho {TotalLength} inválido");
        RuleFor(filme => filme.DiretorId).NotNull();
    }
}