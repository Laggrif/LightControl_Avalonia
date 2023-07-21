using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LightControl.Views;

public partial class SliderDemo : UserControl
{
    public SliderDemo()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}