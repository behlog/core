using System;

namespace Behlog.Core;

public class BehlogRequiredFieldException : DomainException 
{

    public BehlogRequiredFieldException(string fieldName)
        : base(message: $"[Behlog] Required field : '{fieldName}! plese set the value of the field.'")
    {
        RequiredFieldName = fieldName;
    }

    public string RequiredFieldName { get; }
}