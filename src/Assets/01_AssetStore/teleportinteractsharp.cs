﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class teleportinteractsharp : UdonSharpBehaviour
{
    public Transform Target;
    public override void Interact()
    {
        Networking.LocalPlayer.TeleportTo(Target.position, Target.rotation);

    }
}
