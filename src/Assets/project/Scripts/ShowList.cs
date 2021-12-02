
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ShowList : UdonSharpBehaviour
{
    private string[] courseList = new string[10];
    public GameObject schoolbag = GameObject.Find("SchoolBag");
    public GameObject content = GameObject.Find("Content");
    public GameObject itemTemplate = GameObject.Find("TextDefault");
    public UdonSharpBehaviour contentUdon;

    void Start()
    {
        Init();       
    }

    public void PrintList() {
        Init();
    }

    private void Init(){
        for (int i = 0; i < 10; i++) {
            
            //GameObject courseText = Instantiate(itemTemplate);
            //courseText.transform.SetParent(content.transform, false);
            //courseText.GetComponents<TextEditor>();
        }
    }
}
