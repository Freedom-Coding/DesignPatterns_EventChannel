using UnityEngine;

[CreateAssetMenu(fileName = "Void event", menuName = "Events/Void event")]
public class VoidEvent : AbstractEvent<EmptyPayload>
{

}

public struct EmptyPayload { }