
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ItemSlot : UdonSharpBehaviour
{
    private bool isItemIn;
    public UdonSharpBehaviour inventory;
    public GameObject target;

    void Start()
    {
        
    }

    private void Update() {

    }

    public void itemSlotAction(){
        if (Input.GetMouseButtonDown(0)) {  // on left click
            
        }
        
        if (Input.GetMouseButtonDown(1)) {  // on right click
            
        }

        if (Input.GetMouseButtonDown(2)) {  // on middle click
            if (isItemIn) {
                inventory.SendCustomEvent("SlotExtraction");
            }
        }
    }




    
    public void SlotInsertion(){
        isItemIn = true;
        //change mesh or texture or whatever


        //target.SetActive(!target.activeSelf);
    }
}
