using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class SettingWindowListener : MonoBehaviour, IEventListener, IAnySettingValuesListener
{
    private GameEntity _entity;
    private GameContext _context;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;
        _entity = (GameEntity)entity;
        _context = Contexts.sharedInstance.game;
        _entity.AddAnySettingValuesListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnySettingValuesListener(this);
    }

    public void OnAnySettingValues(GameEntity entity, List<Resolution> resolutions, Resolution currentResolution, bool isFullScreen)
    {
        var resolutionDropdown = transform.Find("SettingWindowResolution/SettingWindowResolutionDropdown").GetComponent<Dropdown>();
        var fullScreenToggle = transform.Find("SettingWindowFullScreen/SettingWindowFullScreenToggle").GetComponent<Toggle>();
        var stringList = new List<string>();
        var selectIndex = 0;
        resolutionDropdown.ClearOptions();
        for (var index = 0; index < resolutions.Count; index++)
        {
            var resolution = resolutions[index];
            if (Equals(resolution, currentResolution))
            {
                selectIndex = index;
            }
            stringList.Add(resolution.x + " x " + resolution.y);
        }
        resolutionDropdown.AddOptions(stringList);
        resolutionDropdown.value = selectIndex;
        fullScreenToggle.isOn = isFullScreen;
    }
}