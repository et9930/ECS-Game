//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class NetworkEntity {

    public SignInInfoComponent signInInfo { get { return (SignInInfoComponent)GetComponent(NetworkComponentsLookup.SignInInfo); } }
    public bool hasSignInInfo { get { return HasComponent(NetworkComponentsLookup.SignInInfo); } }

    public void AddSignInInfo(string newUsername, string newEmail, string newPassword) {
        var index = NetworkComponentsLookup.SignInInfo;
        var component = (SignInInfoComponent)CreateComponent(index, typeof(SignInInfoComponent));
        component.username = newUsername;
        component.email = newEmail;
        component.password = newPassword;
        AddComponent(index, component);
    }

    public void ReplaceSignInInfo(string newUsername, string newEmail, string newPassword) {
        var index = NetworkComponentsLookup.SignInInfo;
        var component = (SignInInfoComponent)CreateComponent(index, typeof(SignInInfoComponent));
        component.username = newUsername;
        component.email = newEmail;
        component.password = newPassword;
        ReplaceComponent(index, component);
    }

    public void RemoveSignInInfo() {
        RemoveComponent(NetworkComponentsLookup.SignInInfo);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class NetworkMatcher {

    static Entitas.IMatcher<NetworkEntity> _matcherSignInInfo;

    public static Entitas.IMatcher<NetworkEntity> SignInInfo {
        get {
            if (_matcherSignInInfo == null) {
                var matcher = (Entitas.Matcher<NetworkEntity>)Entitas.Matcher<NetworkEntity>.AllOf(NetworkComponentsLookup.SignInInfo);
                matcher.componentNames = NetworkComponentsLookup.componentNames;
                _matcherSignInInfo = matcher;
            }

            return _matcherSignInInfo;
        }
    }
}
