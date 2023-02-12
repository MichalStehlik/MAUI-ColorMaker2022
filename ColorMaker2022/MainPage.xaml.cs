using System.Diagnostics;

namespace ColorMaker2022;

public partial class MainPage : ContentPage
{
    private Color _color;
    private string _hexValue;

	public MainPage()
	{
		InitializeComponent();
        _color = Colors.Black;
        SetColor(_color);
	}

    private void sld_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var red = sldRed.Value;
        var green = sldGreen.Value;
        var blue = sldBlue.Value;
        _color = Color.FromRgb(red, green, blue);
        SetColor(_color);
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(_hexValue);
    }

    private void SetColor(Color color)
    {
        Debug.WriteLine(color.ToString());
        Container.BackgroundColor = color;
        lblRed.Text = (Math.Round(color.Red * 100,2)).ToString() + "%";
        lblGreen.Text = (Math.Round(color.Green * 100, 2)).ToString() + "%";
        lblBlue.Text = (Math.Round(color.Blue * 100, 2)).ToString() + "%";
        _hexValue = color.ToHex();
        lblHex.Text = _hexValue;
    }
}

