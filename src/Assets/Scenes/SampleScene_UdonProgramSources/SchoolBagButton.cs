
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class SchoolBagButton : UdonSharpBehaviour
{
    private Button _button;
    public Text description;
    public GameObject detail_canvas;

    void Start(){
        _button = gameObject.GetComponent<Button>();
    }

    public void OpenCanvas() {
        detail_canvas.SetActive(true);
        description = gameObject.GetComponentsInChildren<Text>()[1];
        detail_canvas.transform.Find("Panel").Find("Detail").gameObject.GetComponent<Text>().text = description.text;
    }
}
