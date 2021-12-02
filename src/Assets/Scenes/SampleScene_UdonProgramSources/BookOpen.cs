
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class BookOpen : UdonSharpBehaviour
{
    public GameObject canvas;
    public GameObject video1;
    public GameObject video2;
    public GameObject video3;
    public GameObject video4;

    void Start()
    {
        GameObject bookcase = gameObject.GetComponentsInParent<Transform>()[1].gameObject;
        canvas = bookcase.GetComponentInChildren<Canvas>(true).gameObject;
        canvas.SetActive(false);
        gameObject.SetActive(false);

    }

    private void OnMouseDown() {
        canvas.SetActive(false);
        gameObject.SetActive(false);
        video1.SetActive(false);
        video2.SetActive(false);
        video3.SetActive(false);
        video4.SetActive(false);
    }
}
