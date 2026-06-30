namespace AdventureGuildApi.Validators
{
    public interface IValidator<T>
    {
        List<string> Validate(T model);
    }
}
