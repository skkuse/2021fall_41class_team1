
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class CloseButton : UdonSharpBehaviour
{
    private Button _button;
    public GameObject canvas;

    void Start(){
        _button = gameObject.GetComponent<Button>();
    }

    public void CloseCanvas() {
        canvas.SetActive(false);
    }
}
