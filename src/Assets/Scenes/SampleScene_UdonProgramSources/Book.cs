
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using VRC.Udon.Common;

public class Book : UdonSharpBehaviour
{
    public GameObject bookcase, canvas, book_open, video, schoolbag;
    public Text canvas_text, information, courses;
    public Canvas schoolbag_canvas;

    void Start()
    {
        bookcase = gameObject.GetComponentsInParent<Transform>()[1].gameObject;
        canvas = bookcase.GetComponentInChildren<Canvas>(true).gameObject;
        video = gameObject.GetComponentsInChildren<Transform>(true)[2].gameObject;
        canvas_text = canvas.GetComponentInChildren<Text>(true);
        information = gameObject.GetComponentInChildren<Text>();
        Transform[] temp = bookcase.GetComponentsInChildren<Transform>(true);
        book_open = temp[temp.Length - 1].gameObject;
        schoolbag = GameObject.Find("SchoolBag_2");
        
        video.SetActive(false);
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)){
            OpenBook();
        }
        else if(Input.GetMouseButtonDown(1)){
            InsertBag();
        }
    }

    private void OpenBook() {
        canvas.SetActive(true);
        book_open.SetActive(true);
        video.SetActive(true);
        canvas_text.text = information.text;
    }

    private void InsertBag(){
        courses = schoolbag.transform.Find("Courses").GetComponent<Text>();
        string[] course_list = courses.text.Split(',');
        if(course_list[0] == ""){
            courses.text += information.text + ",";
        }
        else if(course_list.Length-1 < 8){
            for(int i = 0; i < course_list.Length-1; i++){
                if(course_list[i] == information.text){
                    return;
                }
            }
            courses.text += information.text + ",";
        }
        else{
            return;
        }
    }
}
