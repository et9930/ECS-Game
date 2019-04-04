using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerUserDataListener : MonoBehaviour, IEventListener, IAnyCurrentPlayerUserDataListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyCurrentPlayerUserDataListener(this);
    }

    public void OnAnyCurrentPlayerUserData(GameEntity entity, SCUserData value)
    {
        var headShot = transform.Find("UserInfoUserHeadShot").GetComponent<Image>();
        headShot.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + value.headShot + "HeadShot");

        var username = transform.Find("UserInfoUsername").GetComponent<Text>();
        username.text = value.username;

        var battleNumber = transform.Find("UserInfoBattleNumber").GetComponent<Text>();
        battleNumber.text = "战斗场次：" + value.battleNumber;

        var winRate = transform.Find("UserInfoWinRate").GetComponent<Text>();
        battleNumber.text = $"胜率：{value.winRate,0:F2}%";

        var battleLevel = transform.Find("UserInfoBattleLevel/UserInfoBattleLevelValue").GetComponent<Text>();
        battleLevel.text = value.levelS + "\n"
                         + value.levelA + "\n"
                         + value.levelB + "\n"
                         + value.levelC + "\n"
                         + value.levelD;

        var ninjaNumber = transform.Find("UserInfoNinjaNumber").GetComponent<Text>();
        ninjaNumber.text = "拥有忍者数：" + value.ninjaNumber;

        var userLevel = transform.Find("UserInfoUserLevel").GetComponent<Text>();
        userLevel.text = "Level " + value.userLevel;

    }
}