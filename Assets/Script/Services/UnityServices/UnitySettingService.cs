using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitySettingService : ISettingService
{
    public bool isFullScreen
    {
        get { return Screen.fullScreen; }
        set { Screen.fullScreen = value; }
    }

    public List<Resolution> GetSupportedResolutions()
    {
        return (from resolution in Screen.resolutions where resolution.refreshRate == 59 select new Resolution {x = resolution.width, y = resolution.height}).ToList();
    }

    public Resolution GetCurrentResolution()
    {
        return new Resolution{x = Screen.currentResolution.width, y = Screen.currentResolution.height};
    }

    public void SetResolution(Resolution resolution, bool fullScreen)
    {
        Screen.SetResolution(resolution.x, resolution.y, fullScreen);
    }
}