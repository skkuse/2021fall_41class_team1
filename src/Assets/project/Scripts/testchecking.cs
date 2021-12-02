
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class testchecking : UdonSharpBehaviour
{
    public GameObject target;
    public void checking(){
        target.SetActive(!target.activeSelf);
    }
}
