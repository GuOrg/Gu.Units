using System.Windows;

namespace GeneratorBox.Generator
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _vm = new ViewModel();
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
