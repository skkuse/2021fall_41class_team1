
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class DeleteButton : UdonSharpBehaviour
{
    public GameObject schoolbag, canvas, detail_canvas;
    public Text courses, cur_course;
    public Button[] slots;

    void Start()
    {
        schoolbag = GameObject.Find("SchoolBag_2");
        canvas = GameObject.Find("SchoolBagCanvas");
        detail_canvas = GameObject.Find("DetailCanvas");
        courses = schoolbag.transform.Find("Courses").GetComponent<Text>();
        cur_course = GameObject.Find("Detail").GetComponent<Text>();
        slots = canvas.gameObject.GetComponentsInChildren<Button>();
    }

    public void DeleteCourse(){
        string[] course_list = courses.text.Split(',');
        courses.text = "";
        for(int i = 0; i < course_list.Length - 1; i++){
            if(cur_course.text == course_list[i]){
                for(int j = 0; j < course_list.Length - 1; j++){
                    if(j != i){
                        courses.text += course_list[j] + ",";
                    }
                }
            }
            slots[i].interactable = false;
            slots[i].GetComponentInChildren<Text>().text = "Empty";
        }

        course_list = courses.text.Split(',');
        if(course_list[0] != ""){
            for(int i = 0; i < course_list.Length - 1; i++){
                Text[] temp = slots[i].GetComponentsInChildren<Text>();
                temp[0].text = "Book";
                temp[1].text = course_list[i];
                slots[i].interactable = true;
            }
        }

        detail_canvas.SetActive(false);
    }

}
