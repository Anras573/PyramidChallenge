namespace PyramidChallenge.Domain.Acquaintances
{
    public interface IParser<TInput, TOutput>
    {
        TOutput Parse(TInput input);
    }
}
