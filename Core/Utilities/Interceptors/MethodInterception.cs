using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception exception) { }
        public override void Intercept(IInvocation invocation)
        {
            bool isSuccessful = true;
            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccessful = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccessful)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}