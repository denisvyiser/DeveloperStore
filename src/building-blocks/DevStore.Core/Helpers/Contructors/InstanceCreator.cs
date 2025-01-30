using System.Linq.Expressions;

namespace DevStore.Core.Helpers.Delegate
{
    public static class InstanceCreator
    {
        static public object Create<TArg, TClass>(TArg arg)
        {
            var constructor = typeof(TClass).GetConstructor(new Type[] { typeof(TArg) });

            //constructor.Invoke(new object[] { arg });
            var parameter = Expression.Parameter(typeof(TArg), "p");
            var creatorExpression = Expression.Lambda<Func<TArg, TClass>>(
                Expression.New(constructor, new Expression[] { parameter }), parameter);
            var func = creatorExpression.Compile();

            var creator = func;

            return creator(arg);
        }

    }
}
