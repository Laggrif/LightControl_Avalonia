using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;

namespace LightControl.Views;

public partial class MainView : UserControl
{
    private int R;
    private int G;
    private int B;
    private int W;
    private int A;
    
    public MainView()
    {
        DataContext = this;

        InitializeComponent();

#if DESKTOP
    FileConsole.WriteLine("hi");
    LoadPixels();
#else
    FileConsole.WriteLine("oh no");
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void LoadPixels()
    {
        var parent = this.FindControl<Grid>("MainGrid");
        Button button = new Button
        {
            Content = "Button generated automatically"
        };
        parent.Children.Add(button);
    }

    private async void Red_OnValueChange(object? sender, RangeBaseValueChangedEventArgs e)
    {
        R = (int)e.NewValue;
        await Task.Delay(20);
        await HttpRequest.SendColor(R, G, B, W);
    }

    
    private async void Green_OnValueChange(object? sender, RangeBaseValueChangedEventArgs e)
    {
        G = (int)e.NewValue;
        await Task.Delay(20);
        await HttpRequest.SendColor(R, G, B, W);
    }

    private async void Blue_OnValueChange(object? sender, RangeBaseValueChangedEventArgs e)
    {
        B = (int)e.NewValue;
        await Task.Delay(20);
        await HttpRequest.SendColor(R, G, B, W);
    }

    private async void White_OnValueChange(object? sender, RangeBaseValueChangedEventArgs e)
    {
        W = (int)e.NewValue;
        await Task.Delay(20);
        await HttpRequest.SendColor(R, G, B, W);
    }

    private async void Alpha_OnValueChange(object? sender, RangeBaseValueChangedEventArgs e)
    {
        A = (int)e.NewValue;
        await Task.Delay(100);
        await HttpRequest.SendAlpha(A);
    }
}