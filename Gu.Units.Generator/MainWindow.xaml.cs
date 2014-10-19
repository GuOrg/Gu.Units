namespace Gu.Units.Generator
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainVm _vm = new MainVm();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, Executed));
        }

        private void Executed(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            _vm.Save();
        }
    }
}
