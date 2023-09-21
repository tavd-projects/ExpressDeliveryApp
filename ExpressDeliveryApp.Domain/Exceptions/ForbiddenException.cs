﻿namespace ExpressDeliveryApp.Domain.Exceptions;

[Serializable]
public class ForbiddenException : Exception
{
    public ForbiddenException(string message) : base(message)
    {
    }

    public ForbiddenException(string message, Exception inner) : base(message, inner)
    {
    }
}