using System.Windows;
using Virtual_xg5000.App.ViewModels;

namespace Virtual_xg5000.App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
