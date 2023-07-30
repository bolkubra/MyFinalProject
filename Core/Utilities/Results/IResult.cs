using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç
    // get sadece okunabilir
    public interface IResult
    {
        bool Succes { get; }
        string Message { get; }
    }
}
