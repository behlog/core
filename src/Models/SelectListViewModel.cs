namespace Behlog.Core.Models;

/// <summary>
/// Represents a list of text/value pairs to render SelectList in an ASP.NET application.
/// </summary>
public class SelectListViewModel
{
    public SelectListViewModel() { }

    public SelectListViewModel(IEnumerable<SelectListItemViewModel> items)
    {
        Items = items;
    }

    public IEnumerable<SelectListItemViewModel> Items { get; set; }
}

/// <summary>
/// Represents an item which has a displayable text and an associate value.
/// It can be converted to a SelectListItem in ASP.NET CORE
/// </summary>
public class SelectListItemViewModel
{
    public SelectListItemViewModel()
    {
    }

    public SelectListItemViewModel(string text, string value)
    {
        Text = text;
        Value = value;
    }

    public SelectListItemViewModel(string text, string value, bool selected)
    {
        Text = text;
        Value = value;
        Selected = selected;
    }

    public SelectListItemViewModel(string text, string value, bool selected, bool disabled)
    {
        Text = text;
        Value = value;
        Selected = selected;
        Disabled = disabled;
    }
    
    public string Text { get; set; }
    public string Value { get; set; }
    public bool Selected { get; set; }
    public bool Disabled { get; set; }
}