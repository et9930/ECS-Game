using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class NinjutsuMenuInfoListener : MonoBehaviour, IEventListener, IAnyPointNinjutsuMenuItemListener
{
    private GameEntity _entity;
    private GameContext _context;
    
    public void RegisterListeners(IEntity entity)
    {
        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddAnyPointNinjutsuMenuItemListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyPointNinjutsuMenuItemListener(this);
    }

    public void OnAnyPointNinjutsuMenuItem(GameEntity entity, string value)
    {
        var ninjutsuInfo = _context.ninjutsuAttributes.dic[value];

        // Ninjutsu Name
        transform.Find("NinjutsuMenuInfoName").GetComponent<Text>().text = ninjutsuInfo.ninjutsuName;
        // Ninjutsu Icon
        transform.Find("NinjutsuMenuInfoIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/UI/JutsuIcon/" + value);
        // Ninjutsu Class
        var ninjutsuMenuInfoIconBackground = transform.Find("NinjutsuMenuInfoIconBackground").GetComponent<Image>();
        var ninjutsuMenuInfoClass = transform.Find("NinjutsuMenuInfoClass").GetComponent<Image>();
        switch (_context.ninjutsuAttributes.dic[value].ninjutsuClass)
        {
            case NinjutsuClass.S:
                ninjutsuMenuInfoIconBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassSBg");
                ninjutsuMenuInfoClass.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassS");
                break;
            case NinjutsuClass.A:
                ninjutsuMenuInfoIconBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassABg");
                ninjutsuMenuInfoClass.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassA");
                break;
            case NinjutsuClass.B:
                ninjutsuMenuInfoIconBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassBBg");
                ninjutsuMenuInfoClass.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassB");
                break;
            case NinjutsuClass.C:
                ninjutsuMenuInfoIconBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassCBg");
                ninjutsuMenuInfoClass.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassC");
                break;
            case NinjutsuClass.D:
                ninjutsuMenuInfoIconBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassDBg");
                ninjutsuMenuInfoClass.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassD");
                break;
            case NinjutsuClass.E:
                ninjutsuMenuInfoIconBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassEBg");
                ninjutsuMenuInfoClass.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassE");
                break;
            default:
                ninjutsuMenuInfoIconBackground.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassEBg");
                ninjutsuMenuInfoClass.sprite = Resources.Load<Sprite>("Image/UI/Common/JutsuCommon/ClassE");
                break;
        }
        // Ninjutsu Nature
        var ninjutsuMenuInfoNature = transform.Find("NinjutsuMenuInfoNature");
        HideAllChildren(ninjutsuMenuInfoNature);
        foreach (var nature in ninjutsuInfo.ninjutsuNatures)
        {
            ninjutsuMenuInfoNature.GetChild((int)nature - 1).gameObject.SetActive(true);
        }
        // Ninjutsu Type
        var ninjutsuMenuInfoType = transform.Find("NinjutsuMenuInfoLabel/NinjutsuMenuInfoType");
        HideAllChildren(ninjutsuMenuInfoType);
        foreach (var type in ninjutsuInfo.ninjutsuTypes)
        {
            ninjutsuMenuInfoType.GetChild((int)type - 1).gameObject.SetActive(true);
        }
        // Ninjutsu Range
        var ninjutsuMenuInfoRange = transform.Find("NinjutsuMenuInfoLabel/NinjutsuMenuInfoRange");
        HideAllChildren(ninjutsuMenuInfoRange);
        foreach (var range in ninjutsuInfo.ninjutsuRanges)
        {
            ninjutsuMenuInfoRange.GetChild((int)range - 1).gameObject.SetActive(true);
        }
        // Ninjutsu Effect
        var ninjutsuMenuInfoEffect = transform.Find("NinjutsuMenuInfoLabel/NinjutsuMenuInfoEffect");
        HideAllChildren(ninjutsuMenuInfoEffect);
        foreach (var effect in ninjutsuInfo.ninjutsuEffects)
        {
            ninjutsuMenuInfoEffect.GetChild((int)effect - 1).gameObject.SetActive(true);
        }
        // Ninjutsu Describe
        transform.Find("NinjutsuMenuInfoDescribe/NinjutsuMenuInfoDescribeText").GetComponent<Text>().text = ninjutsuInfo.ninjutsuDescribe;
        // Ninjutsu Yin
        var yinText = transform.Find("NinjutsuMenuInfoQTE/NinjutsuMenuInfoQTEText").GetComponent<Text>();
        yinText.text = "";
        foreach (var yin in ninjutsuInfo.ninjutsuFullYin)
        {
            switch (yin)
            {
                case Yin.Zi:
                    yinText.text += "子";
                    break;
                case Yin.Yin:
                    yinText.text += "寅";
                    break;
                case Yin.Chen:
                    yinText.text += "辰";
                    break;
                case Yin.Wu:
                    yinText.text += "午";
                    break;
                case Yin.Shen:
                    yinText.text += "申";
                    break;
                case Yin.Xu:
                    yinText.text += "戌";
                    break;
                default:
                    break;
            }
        }
    }

    private void HideAllChildren(Transform parent)
    {
        for (var i = 0; i < parent.childCount; i++)
        {
            parent.GetChild(i).gameObject.SetActive(false);
        }
    }
}