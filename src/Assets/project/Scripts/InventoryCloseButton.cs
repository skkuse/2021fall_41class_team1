
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class InventoryCloseButton : UdonSharpBehaviour
{
    public GameObject inventory;

    public void CloseInventory(){
        inventory.SetActive(false);        
    }
}
