using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using AutoFixture;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace WpfPatterns.Tests
{
    public class NotifyPropertyChangedTester<T> where T : INotifyPropertyChanged
    {
        private readonly T _viewModel;
        private readonly Dictionary<string, int> _notifications = new Dictionary<string, int>(); 

        public NotifyPropertyChangedTester(T viewModel)
        {
            _viewModel = viewModel;
            viewModel.PropertyChanged += (sender, args) =>
            {
                var propertyName = args.PropertyName;

                if (_notifications.TryGetValue(propertyName, out var value))
                {
                    _notifications[propertyName] = ++value;
                }
                else
                {
                    _notifications.Add(propertyName, 1);
                }

            };
        }

        public bool PropertyWasCalled<TProperty> (Expression<Func<T, TProperty>> propertyPicker)
        {
            var propertyName = ((MemberExpression)propertyPicker.Body).Member.Name;
            return _notifications.ContainsKey(propertyName);
        }
        public bool PropertyWasNotCalled<TProperty> (Expression<Func<T, TProperty>> propertyPicker)
        {
            var propertyName = ((MemberExpression)propertyPicker.Body).Member.Name;
            return !_notifications.ContainsKey(propertyName);
        }

        public bool PropertyWasCalled (string propertyName) => _notifications.ContainsKey(propertyName);

        public bool PropertyWasNotCalled (string propertyName) => !_notifications.ContainsKey(propertyName);

        //public void UpdateValue(string propertyName)
        //{
        //    var selector = GetPropertySelector(propertyName);
        //    var setter = GetSetter(selector);

            

        //    setter.Invoke(_viewModel, GetValue());
        //}

        private static TProperty GetValue<TProperty> ()
        {
            var fixture = new Fixture();
            return fixture.Create<TProperty>();
        }

        private static Expression<Func<T, object>> GetPropertySelector(string propertyName)
        {
            var arg = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(arg, propertyName);
            var conv = Expression.Convert(property, typeof(object));
            var exp = Expression.Lambda<Func<T, object>>(conv, new[] { arg });

            return exp;
        }


        private Action<T, TProperty> GetSetter<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var memberExpression = (MemberExpression) expression.Body;
            var property = (PropertyInfo) memberExpression.Member;
            var setMethod = property.GetSetMethod();

            var parameterT = Expression.Parameter(typeof(T), "x");
            var parameterTProperty = Expression.Parameter(typeof(TProperty), "y");

            var newExpression =
                Expression.Lambda<Action<T, TProperty>>(
                    Expression.Call(parameterT, setMethod, parameterTProperty),
                    parameterT,
                    parameterTProperty
                );

            return newExpression.Compile();
        }

    }
}