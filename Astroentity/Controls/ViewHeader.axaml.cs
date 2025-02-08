using Avalonia;
using Avalonia.Controls;

namespace Astroentity.Controls;

public partial class ViewHeader : UserControl
{
    /////////////////////////////////////////////////////////
    #region Properties

    public static readonly StyledProperty<string> BitmapSourceProperty =
        AvaloniaProperty.Register<ViewHeader, string>(nameof(BitmapSource));

    public string BitmapSource
    {
        get => GetValue(BitmapSourceProperty);
        set => SetValue(BitmapSourceProperty, value);
    }

    public static readonly StyledProperty<string> PageTitleProperty =
        AvaloniaProperty.Register<ViewHeader, string>(nameof(PageTitle));

    public string PageTitle
    {
        get => GetValue(PageTitleProperty);
        set => SetValue(PageTitleProperty, value);
    }

    #endregion Properties
    /////////////////////////////////////////////////////////




    /////////////////////////////////////////////////////////
    #region Interface

    public ViewHeader()
    {
        InitializeComponent();
    }

    public ViewHeader(string bitmapSource, string pageTitle)
    {
        BitmapSource = bitmapSource;
        PageTitle = pageTitle;
        InitializeComponent();
    }


    #endregion Interface
    /////////////////////////////////////////////////////////


}