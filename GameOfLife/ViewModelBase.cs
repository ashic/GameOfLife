using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace GameOfLife
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(Expression<Func<object>> property)
        {
            MemberExpression memberExpression;
            var unaryExpression = property.Body as UnaryExpression;
            if (unaryExpression != null)
                memberExpression = unaryExpression.Operand as MemberExpression;
            else
                memberExpression = property.Body as MemberExpression;

            if (memberExpression != null)
            {
                var propertyInfo = memberExpression.Member as PropertyInfo;
                if (propertyInfo != null)
                {
                    NotifyPropertyChanged(propertyInfo.Name);
                    return;
                }
            }

            throw new ArgumentException(
                "The property is not a Expression with a MemberExpresion with type PropertyInfo", "property");
        }

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}