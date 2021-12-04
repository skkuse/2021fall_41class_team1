
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class SchoolBag_2 : UdonSharpBehaviour
{
    private VRCPlayerApi _player;
    private Vector3 curlocation;
    public GameObject canvas, detail_canvas;
    public Text courses;
    public Button[] slots;
    void Start()
    {
        _player = Networking.LocalPlayer;
        Canvas[] temp = gameObject.GetComponentsInChildren<Canvas>();
        canvas = temp[0].gameObject;
        detail_canvas = temp[1].gameObject;
        courses = gameObject.transform.Find("Courses").GetComponent<Text>();
        slots = canvas.gameObject.GetComponentsInChildren<Button>();
        for(int i = 0; i < slots.Length; i++){
            slots[i].interactable = false;
        }

        canvas.SetActive(false);
        detail_canvas.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F1)){
            canvas.SetActive(!canvas.activeSelf);
            detail_canvas.SetActive(false);
            transform.eulerAngles = new Vector3(0, _player.GetRotation().y, 0);
        }
    }

    private void LateUpdate() {
        curlocation = _player.GetPosition();
        transform.position = curlocation;

        if(Input.GetMouseButtonDown(1)){
            string[] course_list = courses.text.Split(',');
            if(course_list[0] != ""){
                for(int i = 0; i < course_list.Length - 1; i++){
                    Text[] temp = slots[i].GetComponentsInChildren<Text>();
                    temp[0].text = "Book";
                    temp[1].text = course_list[i];
                    slots[i].interactable = true;
                }
            }
        }
    }
}
