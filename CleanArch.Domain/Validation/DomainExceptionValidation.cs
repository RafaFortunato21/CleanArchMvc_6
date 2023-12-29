namespace CleanArchMvc.Domain.Validation;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base(error)
    {

    }
    public static void when(bool hasError, string error)
    {
        if (hasError)
        {
            throw new DomainExceptionValidation(error);
        }
    }

}
