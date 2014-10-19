namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class NameOf
    {
        /// <summary>
        /// Returns the name of a property provided as a property expression.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="propertyExpression">Property expression on the the form () => Instance.Property.</param>
        /// <param name="allowNestedProperty">Throw an exception if the provided path is a multi level path (e.g. a.b)</param>
        /// <returns>Returns the simple name of the property.</returns>
        public static string Property<T>(Expression<Func<T>> propertyExpression, bool allowNestedProperty = false)
        {
            var path = PathExpressionVisitor.GetPath(propertyExpression);

            if (path.Length > 1 && !allowNestedProperty)
            {
                throw new Exception("Trying to get the name of a nested property: " + string.Join(".", path.Select(x => x.Member.Name)));
            }

            return path.Last().Member.Name;
        }
    }
}
