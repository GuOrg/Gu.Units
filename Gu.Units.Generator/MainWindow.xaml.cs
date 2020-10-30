﻿namespace Gu.Units.Generator
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, this.Executed));
        }

        private void Executed(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            MainVm.Instance.Save();
        }
    }
}
