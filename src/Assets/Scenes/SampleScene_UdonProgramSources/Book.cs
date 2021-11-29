
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class Book : UdonSharpBehaviour
{
    public GameObject bookcase;
    public GameObject canvas;
    public Text canvas_text;
    public Text information;
    public GameObject book_open;

    void Start()
    {
        bookcase = gameObject.GetComponentsInParent<Transform>()[1].gameObject;
        canvas = bookcase.GetComponentInChildren<Canvas>(true).gameObject;
        canvas_text = canvas.GetComponentInChildren<Text>(true);
        information = gameObject.GetComponentInChildren<Text>();
        Transform[] temp = bookcase.GetComponentsInChildren<Transform>(true);
        book_open = temp[temp.Length - 1].gameObject;
    }

    private void OnMouseDown() {
        canvas.SetActive(true);
        book_open.SetActive(true);
        canvas_text.text = information.text;
    }
}
