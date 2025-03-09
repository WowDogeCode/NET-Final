namespace Core.Utilities
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string? Message { get; }
    }
}
