using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfPatterns.Utils
{
    public class GridPlus : Grid
    {
        public static readonly DependencyProperty RowsProperty = DependencyProperty.Register(nameof(Rows), typeof(string), typeof(GridPlus), 
            new UIPropertyMetadata(string.Empty, (o, args) => (o as GridPlus)?.OnRowsChanged()));
        
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(nameof(Columns), typeof(string), typeof(GridPlus), 
            new UIPropertyMetadata(string.Empty, (o, args) => (o as GridPlus)?.OnColumnsChanged()));

        private static readonly GridLengthConverter GridLengthConverter = new GridLengthConverter();

        public string Rows
        {
            get => (string)GetValue(RowsProperty);
            set => SetValue(RowsProperty, value);
        }

        public string Columns
        {
            get => (string)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }

        private void OnColumnsChanged()
        {
            var columnLengths =
                Columns
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(GridLengthConverter.ConvertFromInvariantString)
                    .OfType<GridLength>();

            ColumnDefinitions.Clear();

            foreach (var columnLength in columnLengths)
            {
                ColumnDefinitions.Add(new ColumnDefinition {Width = columnLength});
            }
        }

        private void OnRowsChanged()
        {
            var rowLengths =
                Rows
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(GridLengthConverter.ConvertFromInvariantString)
                    .OfType<GridLength>();

            RowDefinitions.Clear();

            foreach (var rowLength in rowLengths)
            {
                RowDefinitions.Add(new RowDefinition {Height = rowLength});
            }
        }
    }
}
