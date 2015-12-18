namespace Gu.Units.Wpf
{
    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    internal static class BindingStringFormat
    {
        internal static bool Tryget(IProvideValueTarget provideValueTarget, out string stringFormat)
        {
            if (provideValueTarget == null)
            {
                stringFormat = null;
                return false;
            }

            try // for some reason provideValueTarget.TargetObject can throw
            {
                var target = provideValueTarget.TargetObject as DependencyObject;
                Binding binding = null;
                if (target != null)
                {
                    var targetProperty = provideValueTarget.TargetProperty as DependencyProperty;
                    if (targetProperty != null)
                    {
                        binding = BindingOperations.GetBinding(target, targetProperty);
                    }
                }

                binding = binding ?? provideValueTarget.TargetObject as Binding;
                stringFormat = binding?.StringFormat;
                if (string.IsNullOrWhiteSpace(stringFormat))
                {
                    stringFormat = null;
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                stringFormat = null;
                return false;
            }
        }
    }
}
