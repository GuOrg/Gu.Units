namespace Gu.Units.Generator.Tests
{
    using System;
    using System.Linq;

    internal static class TypeExt
    {
        public static bool IsEquatable(this Type type)
        {
            return type.Implements(typeof(IEquatable<>), type);
        }

        /// <summary>
        /// To check if type implements IEquatable{string}
        /// Call like this type.Implements(typeof(IEquatable{}, typeof(string))
        /// </summary>
        /// <param name="type"></param>
        /// <param name="genericInterface"></param>
        /// <param name="genericArgument"></param>
        /// <returns></returns>
        public static bool Implements(this Type type, Type genericInterface, Type genericArgument)
        {
            if (type.IsInterface &&
                type.IsGenericType(genericInterface, genericArgument))
            {
                return true;
            }

            var interfaces = type.GetInterfaces();
            return interfaces.Any(i => i.IsGenericType(genericInterface, genericArgument));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="genericTypeDefinition"></param>
        /// <param name="genericArgument"></param>
        /// <returns></returns>
        public static bool IsGenericType(this Type type, Type genericTypeDefinition, Type genericArgument)
        {
            //Ensure.IsTrue(genericTypeDefinition.IsGenericType, nameof(genericTypeDefinition), $"{nameof(genericTypeDefinition)}.{nameof(genericTypeDefinition.IsGenericType)} must be true");

            if (!type.IsGenericType)
            {
                return false;
            }

            var gtd = type.GetGenericTypeDefinition();
            if (gtd != genericTypeDefinition)
            {
                return false;
            }

            var genericArguments = type.GetGenericArguments();
            return genericArguments.Length == 1 && genericArguments[0] == genericArgument;
        }
    }
}
