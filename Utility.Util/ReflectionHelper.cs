using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Utility.Util.Exceptions;

namespace Utility.Util
{   
    public static class ReflectionHelper
    {        
        public static void SetPropertyValue(object instance, string propertyName, object value)
        {
            var type = instance.GetType();
            var propertyInfo = type.GetProperty(propertyName);

            if (propertyInfo == null)
                throw new OperationFailedException($"Property not found: '{propertyName}'.");

            propertyInfo.SetValue(instance, value, null);
        }
       
        public static object GetPropertyValue(object instance, string propertyName)
        {
            var type = instance.GetType();
            var propertyInfo = type.GetProperty(propertyName);

            if (propertyInfo == null)
                throw new OperationFailedException($"Property not found: '{propertyName}'.");

            return propertyInfo.GetValue(instance, null);
        }

        public static IEnumerable<Type> GetTypesByNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(x => x.Namespace == nameSpace).ToList();
        }
       
        public static object InvokeMethod(
            object instance,
            string methodName,
            List<MethodParameter> parameters)
        {
            var type = instance.GetType();
            var methodInfo = type.GetMethod(methodName, parameters.Select(x => x.Type).ToArray());

            if (methodInfo == null)
                throw new OperationFailedException($"Method not found.");

            return methodInfo.Invoke(instance, parameters.Select(x => x.Value).ToArray());
        }
       
        public static object InvokeStaticMethod(
            Type type,
            string methodName,
            List<MethodParameter> parameters)
        {
            var methodInfo = type.GetMethod(methodName, parameters.Select(x => x.Type).ToArray());

            if (methodInfo == null)
                throw new OperationFailedException($"Method not found.");

            return methodInfo.Invoke(null, parameters.Select(x => x.Value).ToArray());
        }
    }

    #region Custom Types

    public class MethodParameter
    {
        public Type Type { get; set; } = default!;
        public object Value { get; set; } = default!;
    }

    #endregion
}