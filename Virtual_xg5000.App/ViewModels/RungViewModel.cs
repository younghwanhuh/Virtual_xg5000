using System.Collections.ObjectModel;

namespace Virtual_xg5000.App.ViewModels;

public sealed class RungViewModel : ViewModelBase
{
    private string _title;

    public RungViewModel(int number)
    {
        Number = number;
        _title = $"Rung {number}";
    }

    public int Number { get; }

    public ObservableCollection<LadderElementViewModel> Elements { get; } = new();

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public void AddElement(LadderElementViewModel element)
    {
        if (element is null)
        {
            return;
        }

        element.Parent = this;
        Elements.Add(element);
    }

    public void RemoveElement(LadderElementViewModel element)
    {
        if (element is null)
        {
            return;
        }

        if (Elements.Remove(element))
        {
            element.Parent = null;
        }
    }
}
