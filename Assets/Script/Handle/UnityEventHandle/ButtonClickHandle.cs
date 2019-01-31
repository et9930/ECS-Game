using UnityEngine;
using Entitas.Unity;
using UnityEngine.UI;

public class ButtonClickHandle : MonoBehaviour
{
    void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ((GameEntity)gameObject.GetEntityLink().entity).ReplaceButtonClickState(true);
    }
}