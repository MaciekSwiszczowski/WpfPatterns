using NUnit.Framework;
using WpfPatterns.ViewModels;

namespace WpfPatterns.Tests
{
    [TestFixture]
    public class NotifyPropertyChangedNotificationTests
    {

        [Test]
        public void MyNotificationTest()
        {
            var sut = new TestViewModel();
            var tester = new NotifyPropertyChangedTester<TestViewModel>(sut);

            sut.Name = "Maciek";

            Assert.Multiple(() =>
            {
                Assert.That(tester.PropertyWasCalled(t => t.Name));
                Assert.That(tester.PropertyWasCalled(t => t.NameAndAge));
                Assert.That(tester.PropertyWasNotCalled(t => t.NoNotification));
            });
        }

        [Test]
        [TestCase("Name", true)]
        [TestCase("NameAndAge", true)]
        [TestCase("NoNotification", false)]
        public void MyNotificationTest2(string propertyName, bool wasNotified)
        {
            var sut = new TestViewModel();
            var tester = new NotifyPropertyChangedTester<TestViewModel>(sut);

            sut.Name = "Maciek";


            Assert.IsTrue(tester.PropertyWasCalled(propertyName) == wasNotified);
        }

    }


    internal class TestViewModel : ViewModelBase
    {
        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NameAndAge));
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
            }
        }

        public string NameAndAge => $"{Name}{Age}";

        public double NoNotification { get; set; }
    }
}
