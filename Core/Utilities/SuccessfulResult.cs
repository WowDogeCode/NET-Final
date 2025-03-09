namespace Core.Utilities
{
    public class SuccessfulResult : Result
    {
        public SuccessfulResult() : base(true) { }
        public SuccessfulResult(string message) : base(true, message) { }
    }
}
