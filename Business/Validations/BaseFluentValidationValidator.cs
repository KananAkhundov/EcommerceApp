using Core.Entities;
using FluentValidation;
using System.Linq.Expressions;

namespace Business.Validations
{
    public abstract class BaseFluentValidationValidator<T> : AbstractValidator<T> where T : IEntity
    {
        protected bool BeAValidDate(DateTime date)
        {
            return date < DateTime.Now;
        }

        protected bool BeAValidTimeSpan(TimeSpan timeSpan)
        {
            return timeSpan > TimeSpan.Zero && timeSpan < TimeSpan.FromHours(5);
        }

        protected string NotEmptyFieldMessageGenerator(in string entity, in string propertyName)
        {
            return $"{propertyName} of {entity} model can not be empty";
        }

        protected string LengthValidationMessageGenerator(in string entity, in string propertyName, in int min, in int max)
        {
            return $"{propertyName} of {entity} model's length must be between {min} and {max}";
        }

        protected string MustBeSelectedMessageGenerator(in string entity, in string propertyName)
        {
            return $"{propertyName} of {entity} model must be selected";
        }

        protected string MustBeEqualOrGreaterThanZero(in string entity, in string propertyName)
        {
            return $"{propertyName} of {entity} model must be greater than or equal to zero";
        }

        protected string GetPropertyName<TEntity>(Expression<Func<TEntity>> expression)
        {
            var me = expression.Body as MemberExpression;

            if (me is null)
            {
                throw new ArgumentException("Pass a lambda expression for getting property name");
            }

            return me.Member.Name;

        }
    }
}
