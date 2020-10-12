using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Utility.Util
{
    /// <summary>
    /// Reflection utility methods.
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Sets a value to a property
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(object instance, string propertyName, object value)
        {
            var type = instance.GetType();
            var propertyInfo = type.GetProperty(propertyName);
            propertyInfo.SetValue(instance, value, null);
        }

        /// <summary>
        /// Gets the value from a property
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetPropertyValue(object instance, string propertyName)
        {
            var type = instance.GetType();
            var propertyInfo = type.GetProperty(propertyName);
            return propertyInfo.GetValue(instance, null);
        }

        /// <summary>
        /// Get all types in the specified assembly and namespace
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesByNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(x => x.Namespace == nameSpace).ToList();
        }

        /// <summary>
        /// Invokes an instance method
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object InvokeMethod(
            object instance,
            string methodName,
            List<MethodParameter> parameters)
        {
            var type = instance.GetType();
            var methodInfo = type.GetMethod(methodName, parameters.Select(x => x.Type).ToArray());
            return methodInfo.Invoke(instance, parameters.Select(x => x.Value).ToArray());
        }

        /// <summary>
        /// Invokes an static method
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object InvokeStaticMethod(
            Type type,
            string methodName,
            List<MethodParameter> parameters)
        {
            var methodInfo = type.GetMethod(methodName, parameters.Select(x => x.Type).ToArray());
            return methodInfo.Invoke(null, parameters.Select(x => x.Value).ToArray());
        }        
    }

    #region Custom Types

    public class MethodParameter
    {
        public Type Type { get; set; }
        public object Value { get; set; }
    }

    #endregion
}
