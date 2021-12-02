
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Components;
using System.Collections;

public class SchoolBag : UdonSharpBehaviour
{
    private VRCPlayerApi _player;
    private Vector3 curlocation;
    public float xOffset = 0;
    public float yOffset = 0;
    public float zOffset = 0;
    public GameObject canvas = GameObject.Find("InventoryTextCanvas");
    public bool[] slotVacantList = new bool[10];
    public GameObject[] slotList = new GameObject[10];
    public string[] courseNameList = new string[10];
    private int itemcount = 0;

    public GameObject slot;
    public UdonSharpBehaviour allNetwork;
    public GameObject itemInHand;
    public string itemName = null;


    //public UdonSharpBehaviour ;


    void Start()
    {
        _player = Networking.LocalPlayer;
        for (int i = 0; i < slotList.Length; i++) {
            //itemList[i] = false;
        }
        canvas.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            canvas.SetActive(!canvas.activeSelf);
            // need to rotate inventory window as my view goes
            transform.eulerAngles = new Vector3(0, _player.GetRotation().y, 0);
        }

        // item insertion
        if (Input.GetKeyDown(KeyCode.E)) {
            if (itemInHand){
                allNetwork.SendCustomEvent("checking");


                // Mesh Renderer might need to be disabled
                //MeshRenderer[] item_MeshRenderer = itemInHand.GetComponents<MeshRenderer>();

                //BoxCollider item_collider = itemInHand.GetComponent<BoxCollider>();
                //item_collider.enabled = !item_collider.enabled;
                

                //itemInHand.GetComponent(typeof(VRC_Pickup)).enabled = false;
                //itemInHand.GetComponent<MeshRenderer>().enabled = false;
                
                
                itemInHand.GetComponent<BoxCollider>().enabled = false;

                itemInHand.transform.SetParent(slot.transform, true); // set item as child of slot
                itemInHand.transform.position = new Vector3(0, 2, 0); // set location of the itme as slot
                //ItemInsertion(itemInHand, itemName);
                allNetwork.SendCustomEvent("SlotInsertion"); // send event to change texture of item slot
            } else {}   
        }
    }

    public void ReadInputText() {
        
        
    }


    public void SlotExtraction() {
        curlocation = _player.GetPosition();
        itemInHand.transform.position = curlocation + new Vector3(0, 1, 1); // set item out of slot 
        itemInHand.transform.parent = null; // remove item from slot

        itemInHand.GetComponent<BoxCollider>().enabled = true; // collider active
        //itemInHand.GetComponent<MeshRenderer>().enabled = true;
    }

    
    private void LateUpdate() {
        curlocation = _player.GetPosition();
        transform.position = curlocation + new Vector3(xOffset, yOffset, zOffset);
    }


    private bool ItemInsertion(GameObject inputItem, string inputString) {
        if (itemcount == slotList.Length) {
            return false;
        } else {
            int slotNum = 0;
            while (slotNum < slotList.Length) {
                if (slotList[slotNum] == null)
                {
                    slotList[slotNum] = inputItem;
                    courseNameList[slotNum] = inputString;
                }
                slotNum++;
            }
        }
        return true;
    }

    private bool ItemExtraction(int slotNum) {
        slotList[slotNum] = null;
        courseNameList[slotNum] = null;
        return true;
    }

    private void InventoryClear() { // Clear Inventory by dropping all the items on the floor
        int slotNum = 0;
        while (slotNum < slotList.Length) {
            // Drop all the itmes
            slotList[slotNum] = null;
            courseNameList[slotNum] = null;
            slotNum++;
        }
    }
}
