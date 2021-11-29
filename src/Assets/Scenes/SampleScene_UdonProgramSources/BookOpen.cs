
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class BookOpen : UdonSharpBehaviour
{
    public GameObject canvas;
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
    }
}
