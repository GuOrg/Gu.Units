namespace Gu.Units.Wpf.Tests
{
    using System;
    using System.Windows.Data;
    using System.Windows.Markup;
    using Moq;

    public class ServiceProviderMock : Mock<IServiceProvider>
    {
        private readonly Binding binding;

        public ServiceProviderMock()
            : base(MockBehavior.Strict)
        {
            this.binding = new Binding();
            this.Setup(x => x.GetService(typeof(IProvideValueTarget)))
                .Returns(this.ProvideValueTargetMock.Object);

            this.ProvideValueTargetMock.SetupGet(x => x.TargetObject).Returns(this.binding);
        }

#pragma warning disable CA1044 // Properties should not be write only
        public string BindingStringFormat
#pragma warning restore CA1044 // Properties should not be write only
        {
            set => this.binding.StringFormat = value;
        }

        internal Mock<IProvideValueTarget> ProvideValueTargetMock { get; } = new Mock<IProvideValueTarget>(MockBehavior.Strict);
    }
}
