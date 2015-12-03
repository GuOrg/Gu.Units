namespace Gu.Units.Wpf.Tests
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Markup;
    using Moq;

    public class ServiceProviderMock : Mock<IServiceProvider>
    {
        internal readonly Mock<IProvideValueTarget> ProvideValueTargetMock = new Mock<IProvideValueTarget>(MockBehavior.Strict);
        private readonly TextBox textBox = new TextBox();

        public ServiceProviderMock()
            :base(MockBehavior.Strict)
        {
            Setup(x => x.GetService(typeof(IProvideValueTarget)))
                        .Returns(this.ProvideValueTargetMock.Object);

            this.ProvideValueTargetMock.SetupGet(x => x.TargetObject).Returns(this.textBox);
            this.ProvideValueTargetMock.SetupGet(x => x.TargetProperty).Returns(TextBox.TextProperty);
        }

        public string BindingStringFormat
        {
            set
            {
                var binding = new Binding("Foo")
                {
                    StringFormat = value
                };
                BindingOperations.SetBinding(this.textBox, TextBox.TextProperty, binding);
            }
        }
    }
}
