
using System.Numerics;

public interface ITextController : IBaseComponentController
{
    string Text { get; set; }
    int FontSize { get; set; }
    Vector4 Color { get; set; }
    int FontStyle { get; set; }
}

