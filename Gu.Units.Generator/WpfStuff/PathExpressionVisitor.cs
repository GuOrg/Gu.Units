namespace Gu.Units.Generator.WpfStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class PathExpressionVisitor : ExpressionVisitor
    {
        private readonly List<MemberExpression> _path = new List<MemberExpression>();
        public static MemberExpression[] GetPath<TSource, TResult>(Expression<Func<TSource, TResult>> expression)
        {
            var visitor = new PathExpressionVisitor();
            visitor.Visit(expression.Body);
            return Enumerable.Reverse(visitor._path).ToArray();
        }
        public static MemberExpression[] GetPath<T>(Expression<Func<T>> expression)
        {
            var visitor = new PathExpressionVisitor();
            visitor.Visit(expression.Body);
            return Enumerable.Reverse(visitor._path).ToArray();
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            _path.Add(node);
            return base.VisitMember(node);
        }
    }
}