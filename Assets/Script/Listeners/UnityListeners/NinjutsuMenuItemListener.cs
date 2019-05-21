using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class NinjutsuMenuItemListener : MonoBehaviour, IEventListener, INinjutsuNameListener
{
    private GameEntity _entity;
    private GameContext _context;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddNinjutsuNameListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveNinjutsuNameListener(this);
    }

    public void OnNinjutsuName(GameEntity entity, string value)
    {
        var ninjutsuMenuItemBackground = transform.Find("NinjutsuMenuItemBackground").GetComponent<Image>();
        var ninjutsuMenuItemIcon = transform.Find("NinjutsuMenuItemIcon").GetComponent<Image>();

        switch (_context.ninjutsuAttributes.dic[value].ninjutsuClass)
        {
            case NinjutsuClass.S:
                ninjutsuMenuItemBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassSBg");
                break;
            case NinjutsuClass.A:
                ninjutsuMenuItemBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassABg");
                break;
            case NinjutsuClass.B:
                ninjutsuMenuItemBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassBBg");
                break;
            case NinjutsuClass.C:
                ninjutsuMenuItemBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassCBg");
                break;
            case NinjutsuClass.D:
                ninjutsuMenuItemBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassDBg");
                break;
            case NinjutsuClass.E:
                ninjutsuMenuItemBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassEBg");
                break;
            default:
                ninjutsuMenuItemBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassEBg");
                break;
        }

        ninjutsuMenuItemIcon.sprite = Resources.Load<Sprite>("Image/UI/JutsuIcon/" + value);
    }
}