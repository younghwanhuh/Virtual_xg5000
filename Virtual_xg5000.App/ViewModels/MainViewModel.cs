using System.Collections.ObjectModel;
using System.Linq;
using Virtual_xg5000.App.Infrastructure;
using Virtual_xg5000.App.Models;

namespace Virtual_xg5000.App.ViewModels;

public sealed class MainViewModel : ViewModelBase
{
    private readonly ObservableCollection<LadderToolOption> _tools;
    private readonly ReadOnlyObservableCollection<LadderToolOption> _readOnlyTools;
    private LadderToolOption? _selectedTool;
    private int _nextRungNumber = 1;
    private int _nextContactIndex = 1;
    private int _nextCoilIndex = 1;

    public MainViewModel()
    {
        _tools = new ObservableCollection<LadderToolOption>
        {
            new(LadderElementType.NormallyOpenContact, "Normally Open Contact (NO)", "Closes when the input signal is ON."),
            new(LadderElementType.NormallyClosedContact, "Normally Closed Contact (NC)", "Opens when the input signal is ON."),
            new(LadderElementType.Coil, "Coil Output", "Energizes the output coil when the rung conditions are true.")
        };
        _readOnlyTools = new ReadOnlyObservableCollection<LadderToolOption>(_tools);

        _selectedTool = _tools.FirstOrDefault();

        AddRungCommand = new RelayCommand(_ => AddRung());
        AddElementCommand = new RelayCommand(rung => AddElement(rung as RungViewModel));
        RemoveElementCommand = new RelayCommand(element => RemoveElement(element as LadderElementViewModel));

        AddRung();
    }

    public ObservableCollection<RungViewModel> Rungs { get; } = new();

    public ReadOnlyObservableCollection<LadderToolOption> Tools => _readOnlyTools;

    public LadderToolOption? SelectedTool
    {
        get => _selectedTool;
        set => SetProperty(ref _selectedTool, value);
    }

    public RelayCommand AddRungCommand { get; }

    public RelayCommand AddElementCommand { get; }

    public RelayCommand RemoveElementCommand { get; }

    private void AddRung()
    {
        var rung = new RungViewModel(_nextRungNumber++);
        Rungs.Add(rung);
    }

    private void AddElement(RungViewModel? rung)
    {
        if (rung is null)
        {
            return;
        }

        var tool = SelectedTool;
        if (tool is null || tool.ElementType == LadderElementType.None)
        {
            return;
        }

        var element = CreateElement(tool.ElementType);
        rung.AddElement(element);
    }

    private LadderElementViewModel CreateElement(LadderElementType elementType) =>
        elementType switch
        {
            LadderElementType.NormallyOpenContact => new LadderElementViewModel(elementType, $"X{_nextContactIndex++:D3}"),
            LadderElementType.NormallyClosedContact => new LadderElementViewModel(elementType, $"XN{_nextContactIndex++:D3}"),
            LadderElementType.Coil => new LadderElementViewModel(elementType, $"Y{_nextCoilIndex++:D3}"),
            _ => new LadderElementViewModel(LadderElementType.None, string.Empty)
        };

    private void RemoveElement(LadderElementViewModel? element)
    {
        if (element?.Parent is null)
        {
            return;
        }

        element.Parent.RemoveElement(element);
    }

    public sealed record LadderToolOption(LadderElementType ElementType, string Name, string Description);
}
