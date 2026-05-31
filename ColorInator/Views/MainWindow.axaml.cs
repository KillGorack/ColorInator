using Avalonia.Controls;
using ColorInator.ViewModels;

namespace ColorInator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContextChanged += (_, _) =>
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.SetClipboard(TopLevel.GetTopLevel(this)!.Clipboard!);
                _ = vm.LoadColorsAsync();
            }
        };
    }
}