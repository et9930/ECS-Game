using System.Collections.Generic;

public interface ISettingService
{
    List<Resolution> GetSupportedResolutions();
    Resolution GetCurrentResolution();
    void SetResolution(Resolution resolution, bool fullScreen);
    bool isFullScreen { get; set; }
}