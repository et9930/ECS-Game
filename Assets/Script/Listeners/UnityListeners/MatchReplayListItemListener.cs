using System;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class MatchReplayListItemListener : MonoBehaviour, IEventListener, IMatchReplayListItemListener, IActiveListener
{
    private GameContext _context;
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddMatchReplayListItemListener(this);
        _entity.AddActiveListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveMatchReplayListItemListener(this);
        _entity.RemoveActiveListener(this);
    }
    
    public void OnMatchReplayListItem(GameEntity entity, int index, SCMatchData matchData)
    {
        var itemIndex = transform.Find("MatchReplayListItemIndex").GetComponent<Text>();
        itemIndex.text = $"{index,0:D4}";

        var dataTime = transform.Find("MatchReplayListItemDateTime").GetComponent<Text>();
        var matchDateTime = _context.timeService.instance.TimeStampToDateTime(matchData.matchStartTime);
        dataTime.text = matchDateTime.ToString("yyyy-MM-dd HH:mm:ss");

        var mapImage = transform.Find("MatchReplayListItemMap/MatchReplayListItemMapImage").GetComponent<Image>();
        var mapText = transform.Find("MatchReplayListItemMap/MatchReplayListItemMapText").GetComponent<Text>();
        mapText.text = _context.mapConfig.list[matchData.matchMap.mapName].Name;
        mapImage.sprite = Resources.Load<Sprite>("Image/UI/MapImage/" + matchData.matchMap.mapName);

        var characterText = transform.Find("MatchReplayListItemCharacter/MatchReplayListItemCharacterText").GetComponent<Text>();
        var characterImage = transform.Find("MatchReplayListItemCharacter/MatchReplayListItemCharacterHeadShot").GetComponent<Image>();
        foreach (var player in matchData.matchPlayers)
        {
            if (player.userId != _context.currentPlayerId.value) continue;
            characterText.text = _context.characterBaseAttributes.dic[player.ninjaName].name;
            characterImage.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + player.ninjaName + "HeadShot");
            break;
        }

        var matchSize = transform.Find("MatchReplayListItemMatchSize").GetComponent<Text>();
        switch (matchData.matchSize)
        {
            case 2:
                matchSize.text = "1 VS 1";
                break;
            case 4:
                matchSize.text = "2 VS 2";
                break;
            case 8:
                matchSize.text = "4 VS 4";
                break;
            default:
                matchSize.text = "";
                break;
        }

        var matchType = transform.Find("MatchReplayListItemMatchType").GetComponent<Text>();
        switch (matchData.matchType)
        {
            case 1:
                matchType.text = "遭遇战";
                break;
            case 2:
                matchType.text = "攻防战";
                break;
            case 3:
                matchType.text = "争夺战";
                break;
            default:
                matchType.text = "未知";
                break;
        }
    }

    public void OnActive(GameEntity entity, bool value)
    {
        transform.Find("MatchReplayListItemSelected").gameObject.SetActive(value);
    }
    
}