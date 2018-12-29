public interface IImageController : IBaseComponentController
{
    string SourceImage { get; set; }
    int ImageType { get; set; }
    int FillMethod { get; set; }
    int FillOrigin { get; set; }
    float FillAmount { get; set; }
}