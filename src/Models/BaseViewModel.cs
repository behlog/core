using System.Text;
using Behlog.Extensions;

namespace Behlog.Core.Models;

/// <summary>
/// BaseClass for Web ViewModels.
/// </summary>
public abstract class BaseViewModel
{
    private int _errorIndex = 0;
    
    public BaseViewModel()
    {
        Errors = new Dictionary<string, string>();
    }
    
    public string ModelMessage { get; set; }
    
    public string ErrorFieldName { get; set; }
    
    public bool HasError { get; set; }
    
    public bool Success { get; set; }

    public Dictionary<string, string> Errors { get; protected set; }

    public void WithError(string message, string filedName = "")
    {
        ErrorFieldName = filedName;
        ModelMessage = message;
        HasError = true;
        
        AddError(message, filedName);
    }

    public void AddError(string message, string fieldName)
    {
        string key = fieldName;
        _errorIndex++;
        if (key.IsNullOrEmptySpace())
        {
            key = $"_{_errorIndex}";
        }
        if (Errors.ContainsKey(key))
        {
            key = $"{key}_{_errorIndex}";
        }
        
        Errors.Add(key, message);
    }

    public string ErrorMessages
    {
        get
        {
            var sb = new StringBuilder();
            foreach (var err in Errors)
            {
                sb.AppendLine(err.Value);
            }

            return sb.ToString();
        }
    }
}
