﻿namespace VenturaSoftHR.Api.Common;

public class ErrorHandler
{
    public ErrorHandler()
    {

    }

    public ErrorHandler(string errorName, string message) 
    {
        ErrorName = errorName;
        Message = message;
    }

    public string ErrorName { get; set; }
    public string Message { get; set; }
}
