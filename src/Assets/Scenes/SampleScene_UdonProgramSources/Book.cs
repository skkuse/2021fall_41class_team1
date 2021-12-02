
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
    public GameObject video;

    void Start()
    {

        bookcase = gameObject.GetComponentsInParent<Transform>()[1].gameObject;
        canvas = bookcase.GetComponentInChildren<Canvas>(true).gameObject;
        video = gameObject.GetComponentsInChildren<Transform>(true)[2].gameObject;
        canvas_text = canvas.GetComponentInChildren<Text>(true);
        information = gameObject.GetComponentInChildren<Text>();
        Transform[] temp = bookcase.GetComponentsInChildren<Transform>(true);
        book_open = temp[temp.Length - 1].gameObject;

        video.SetActive(false);
    }

    private void OnMouseDown() {
        canvas.SetActive(true);
        book_open.SetActive(true);
        video.SetActive(!video.activeSelf);
        canvas_text.text = information.text;
    }
}
