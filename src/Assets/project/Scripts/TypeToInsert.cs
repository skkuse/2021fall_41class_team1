
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TypeToInsert : UdonSharpBehaviour
{
    private string input;
    public UdonSharpBehaviour inventory;

    public void ReadStringInputFromField(string s) {
        input = s;
        
        inventory.SendCustomEvent("ReadInputText");
    }
}
