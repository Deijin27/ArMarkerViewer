using System;
using System.Windows;
using System.Linq.Expressions;

namespace ArMarkerViewer
{
    public static class Extensions
    {
        public static DependencyProperty RegisterDependencyProperty<TView, TProperty>(
            Expression<Func<TView, TProperty>> property,
            TProperty defaultValue = default)
            where TView : DependencyObject
        {
            var expression = (MemberExpression)property.Body;
            var propertyName = expression.Member.Name;

            return DependencyProperty.Register(
                propertyName,
                typeof(TProperty),
                typeof(TView),
                new PropertyMetadata(defaultValue)
                );
        }
    }
}
