namespace Core.Utilities
{
    public class SuccessfulDataResult<T> : DataResult<T>
    {
        public SuccessfulDataResult(T data) : base(data, true) { }
        public SuccessfulDataResult(T data, string message) : base(data, true, message) { }
        public SuccessfulDataResult(string message) : base(default, true, message) { }
        public SuccessfulDataResult() : base(default, true) { }
    }
}
