using System;
using Entitas;
using System.Collections.Generic;

public class ClickEventSystem : ReactiveSystem<GameEntity>, IInitializeSystem 
{
    private readonly GameContext _context;

    public ClickEventSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceClickEventFunc(new Dictionary<string, Action<GameEntity>>());
        _context.clickEventFunc.clickDic["NinjaItemMenuItem"] = OnNinjaItemMenuItemClick;
        _context.clickEventFunc.clickDic["QuickActionMenuItem"] = OnQuickActionMenuItemClick;
        _context.clickEventFunc.clickDic["SelectTarget"] = OnSelectTargetClick;
        _context.clickEventFunc.clickDic["LoginButton"] = OnLoginButtonClick;
        _context.clickEventFunc.clickDic["SignInButton"] = OnSignInButtonClick;
        _context.clickEventFunc.clickDic["SignInConfirmButton"] = OnSignInConfirmButtonClick;
        _context.clickEventFunc.clickDic["SignInCancelButton"] = OnSignInCancelButtonClick;
        _context.clickEventFunc.clickDic["MainUIOperationSearchBattle"] = OnMainUIOperationSearchBattleClick;
        _context.clickEventFunc.clickDic["SearchBattleWindowMask"] = OnSearchBattleWindowMaskClick;
        _context.clickEventFunc.clickDic["StartSearchButton"] = OnStartSearchButtonClick;
        _context.clickEventFunc.clickDic["StopSearchButton"] = OnStopSearchButtonClick;
        _context.clickEventFunc.clickDic["ReadyMatchButton"] = OnReadyMatchButtonClick;
        _context.clickEventFunc.clickDic["CancelMatchButton"] = OnCancelMatchButtonClick;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ClickState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasClickState && entity.clickState.value;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.ReplaceClickState(false);
            var uiName = e.name.text;
            var index = e.name.text.IndexOf('_');
            if (index != -1)
            {
                uiName = e.name.text.Substring(0, index);
            }
            if (_context.clickEventFunc.clickDic.ContainsKey(uiName))
            {
                _context.clickEventFunc.clickDic[uiName](e);
            }
        }
    }

    private void OnNinjaItemMenuItemClick(GameEntity entity)
    {
        if (entity.hasActive && entity.active.value) return;
        if (entity.leftNumber.value <= 0) return;

        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        currentPlayer.ReplaceUseNinjaItem(entity.ninjaItemName.value);
        
        foreach (var e in _context.GetEntitiesWithName("NinjaItemMenuItem"))
        {
            e.ReplaceActive(false);
        }

        entity.ReplaceActive(true);
    }

    private void OnQuickActionMenuItemClick(GameEntity entity)
    {
        _context.CreateEntity().ReplaceDebugMessage(entity.quickActionTarget.value.name.text);
    }

    private void OnSelectTargetClick(GameEntity entity)
    {
        entity.isSelected = true;
    }

    private void OnLoginButtonClick(GameEntity entity)
    {
        var email = _context.sceneService.instance.GetInputValue("LoginEmailInput");
        var password = _context.sceneService.instance.GetInputValue("LoginPasswordInput");

        GameEntity loginErrorMessage = null;
        foreach (var e in _context.GetEntitiesWithName("LoginErrorMessage"))
        {
            loginErrorMessage = e;
        }
        if (loginErrorMessage == null) return;
        loginErrorMessage.ReplaceText("");

        if (email == "")
        {
            loginErrorMessage.ReplaceText("邮箱不能为空");
            return;
        }
        if (password == "")
        {
            loginErrorMessage.ReplaceText("密码不能为空");
            return;
        }
        if (password.Length < 8)
        {
            loginErrorMessage.ReplaceText("密码必须大于8位");
            return;
        }

        _context.localStorageService.instance.SetString("login_email", email);
        var isRemember = _context.sceneService.instance.GetToggleOnState("LoginRememberPasswordToggle");
        _context.localStorageService.instance.SetBool("login_remember_password", isRemember);
        if (isRemember)
        {
            _context.localStorageService.instance.SetString("login_password", password);
        }
        
        _context.ReplaceLogin(email, password);
    }

    private void OnSignInButtonClick(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("SignInWindow"))
        {
            e.ReplaceActive(true);
        }
    }

    private void OnSignInConfirmButtonClick(GameEntity entity)
    {
        var email = _context.sceneService.instance.GetInputValue("SignInEmailInput");
        var userName = _context.sceneService.instance.GetInputValue("SignInUserNameInput");
        var password = _context.sceneService.instance.GetInputValue("SignInPasswordInput");
        var passwordConfirm = _context.sceneService.instance.GetInputValue("SignInPasswordConfirmInput");

        GameEntity signInErrorMessage = null;
        foreach (var e in _context.GetEntitiesWithName("SignInErrorMessage"))
        {
            signInErrorMessage = e;
        }
        if (signInErrorMessage == null) return;
        signInErrorMessage.ReplaceText("");

        if (email == "")
        {
            signInErrorMessage.ReplaceText("邮箱不能为空");
            return;
        }
        if (userName == "")
        {
            signInErrorMessage.ReplaceText("用户名不能为空");
            return;
        }
        if (password == "")
        {
            signInErrorMessage.ReplaceText("密码不能为空");
            return;
        }
        if (passwordConfirm == "")
        {
            signInErrorMessage.ReplaceText("确认密码不能为空");
            return;
        }
        if (password != passwordConfirm)
        {
            signInErrorMessage.ReplaceText("两次输入密码不一致");
            return;
        }
        if (password.Length < 8)
        {
            signInErrorMessage.ReplaceText("密码必须大于8位");
            return;
        }

        _context.ReplaceSignIn(userName, email, password);
    }

    private void OnSignInCancelButtonClick(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("SignInWindow"))
        {
            e.ReplaceActive(false);
        }
    }

    private void OnMainUIOperationSearchBattleClick(GameEntity entity)
    {
        var e = _context.CreateEntity();
        e.ReplaceUiOpen("SearchBattleWindow");
        e.ReplaceName("SearchBattleWindow");
    }

    private void OnSearchBattleWindowMaskClick(GameEntity entity)
    {
        if (_context.isSearchingBattle) return;
        foreach (var e in _context.GetEntitiesWithName("SearchBattleWindow"))
        {
            e.isUiClose = true;
        }
    }

    private async void OnStartSearchButtonClick(GameEntity entity)
    {
        var matchType = _context.sceneService.instance.GetDropdownValue("MatchTypeDropdown");
        var playerCount = (int)Math.Pow(2, 1 + _context.sceneService.instance.GetDropdownValue("MatchScaleDropdown"));

        var result = await _context.networkService.instance.StartMatchMaker(matchType, playerCount);
        if (!result) return;
        foreach (var e in _context.GetEntitiesWithName("StartSearchButton"))
        {
            e.ReplaceActive(false);
        }
        foreach (var e in _context.GetEntitiesWithName("StopSearchButton"))
        {
            e.ReplaceActive(true);
        }

        foreach (var e in _context.GetEntitiesWithName("WaitOtherPlayerJoin"))
        {
            e.ReplaceActive(false);
        }

        _context.isSearchingBattle = true;

        _context.sceneService.instance.SetSelectableInteractable("MatchScaleDropdown", false);
        _context.sceneService.instance.SetSelectableInteractable("MatchTypeDropdown", false);

    }

    private async void OnStopSearchButtonClick(GameEntity entity)
    {
        var result = await _context.networkService.instance.StopMatchMaker();
        if (!result) return;
        foreach (var e in _context.GetEntitiesWithName("StartSearchButton"))
        {
            e.ReplaceActive(true);
        }
        foreach (var e in _context.GetEntitiesWithName("StopSearchButton"))
        {
            e.ReplaceActive(false);
        }
        foreach (var e in _context.GetEntitiesWithName("WaitOtherPlayerJoin"))
        {
            e.ReplaceActive(false);
        }

        _context.isSearchingBattle = false;

        _context.sceneService.instance.SetSelectableInteractable("MatchScaleDropdown", true);
        _context.sceneService.instance.SetSelectableInteractable("MatchTypeDropdown", true);

    }

    private async void OnReadyMatchButtonClick(GameEntity entity)
    {
        var readyMatch = new CSReadyMatch
        {
            ready = true
        };
        var strReadyMatch = Utilities.ToJson(readyMatch);
        var rpcPayload = await _context.networkService.instance.RpcCall("rpc_ready_match", strReadyMatch);
        if (rpcPayload == null) return;

        foreach (var e in _context.GetEntitiesWithName("WaitOtherPlayerReady"))
        {
            e.ReplaceActive(true);
        }
        foreach (var e in _context.GetEntitiesWithName("ReadyMatchButton"))
        {
            e.ReplaceActive(false);
        }
        foreach (var e in _context.GetEntitiesWithName("CancelMatchButton"))
        {
            e.ReplaceActive(false);
        }
    }

    private async void OnCancelMatchButtonClick(GameEntity entity)
    {
        var readyMatch = new CSReadyMatch
        {
            ready = false
        };
        var strReadyMatch = Utilities.ToJson(readyMatch);
        await _context.networkService.instance.RpcCall("rpc_ready_match", strReadyMatch);
    }
}
