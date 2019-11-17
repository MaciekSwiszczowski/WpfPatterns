using System.ComponentModel;
using System.Threading;
using NUnit.Framework;
using Shouldly;
using WpfPatterns.Utils;

namespace WpfPatterns.Tests
{
    [Apartment(ApartmentState.STA)]
    public class GridPlusTests
    {

        [Test]
        public void DependencyProperties_ShouldBeCorrect()
        {
            var rowsPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(GridPlus.RowsProperty, typeof(GridPlus));
            var columnsPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(GridPlus.ColumnsProperty, typeof(GridPlus));

            rowsPropertyDescriptor.ShouldNotBeNull();
            columnsPropertyDescriptor.ShouldNotBeNull();
        }
    }
}
