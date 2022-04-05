﻿namespace VenturaSoftHR.Api.Docs.Filters;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class OperationOrderAttribute : Attribute
{
    public int Order { get; }

    public OperationOrderAttribute(int order)
    {
        this.Order = order;
    }
}
