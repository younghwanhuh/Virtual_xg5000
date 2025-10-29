using Virtual_xg5000.App.Models;

namespace Virtual_xg5000.App.ViewModels;

public sealed class LadderElementViewModel : ViewModelBase
{
    private string _label;

    public LadderElementViewModel(LadderElementType elementType, string label)
    {
        ElementType = elementType;
        _label = label;
    }

    public LadderElementType ElementType { get; }

    public string Label
    {
        get => _label;
        set => SetProperty(ref _label, value);
    }

    public RungViewModel? Parent { get; internal set; }

    public string DisplayName => ElementType switch
    {
        LadderElementType.NormallyOpenContact => "NO",
        LadderElementType.NormallyClosedContact => "NC",
        LadderElementType.Coil => "Coil",
        _ => string.Empty
    };
}
