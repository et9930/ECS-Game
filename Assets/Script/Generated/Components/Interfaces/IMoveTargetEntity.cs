//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IMoveTargetEntity {

    MoveTargetComponent moveTarget { get; }
    bool hasMoveTarget { get; }

    void AddMoveTarget(UnityEngine.Vector2 newValue);
    void ReplaceMoveTarget(UnityEngine.Vector2 newValue);
    void RemoveMoveTarget();
}