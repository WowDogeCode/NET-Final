using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        Type _validator;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidatorType);
            }
            _validator = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            IValidator? validator = Activator.CreateInstance(_validator) as IValidator;

            if (validator != null)
            {
                var itemType = _validator?.BaseType?.GetGenericArguments()[0];
                var items = invocation.Arguments.Where(x => x.GetType() == itemType);

                foreach (var item in items)
                {
                    ValidationTool.Validate(validator, item);
                }
            }
        }
    }
}
