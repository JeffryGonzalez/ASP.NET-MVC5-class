using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcUnitTests
{
    public static class Helpers
    {
        private static MethodInfo MethodOf(Expression<Action> expression)
        {
            var body = (MethodCallExpression) expression.Body;
            return body.Method;
        }

        public static bool MethodHasAttribute<TAttribute>(Expression<Action> expression)
        {
            var member = MethodOf(expression);
            return member.GetCustomAttributes(typeof (TAttribute), true).Length > 0;
        }

        public static bool ActionHasGetAttribute(Expression<Action> expression)
        {
            return MethodHasAttribute<HttpGetAttribute>(expression);
        }

        public static bool ActionHasPutAttribute(Expression<Action> expression)
        {
            return MethodHasAttribute<HttpPutAttribute>(expression);
        }

        public static bool ActionHasPostAttribute(Expression<Action> expression)
        {
            return MethodHasAttribute<HttpPostAttribute>(expression);
        }

        public static bool ActionHasDeleteAttribute(Expression<Action> expression)
        {
            return MethodHasAttribute<HttpDeleteAttribute>(expression);
        }

        public class AttributeHelper<T> where T : class
        {
            private Type GivenClass
            {
                get { return typeof (T); }
            }

            public bool HasAnnotation(Type annotation)
            {
                return GivenClass.GetCustomAttributes(annotation, true).Single() != null;
            }

            public bool MethodHasAttribute(Type attribute, string target)
            {
                return GivenClass.GetMethod(target).GetCustomAttributes(attribute, true).Any();
            }

            public bool PropertyHasAttribute(Type attribute, string target)
            {
                return GivenClass.GetProperty(target).GetCustomAttributes(attribute, true).Any();
            }

            public Attribute GetAttributeOnProperty(Type attribute, string target)
            {
                return GivenClass.GetProperty(target).GetCustomAttribute(attribute, true);
            }

            public Attribute GetAttributeOnMethod(Type attribute, string target)
            {
                return GivenClass.GetMethod(target).GetCustomAttribute(attribute, true);
            }
        }
    }
}
