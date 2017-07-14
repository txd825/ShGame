using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalActive : MonoBehaviour
{
    public GUISkin guiSkin;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Touch CurTouch = Input.GetTouch(0);
        
        if (IsTouched(CurTouch))
        {
            TouchMove(CurTouch);
        }

    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 800, 100), string.Format("当前手指点的x坐标：{0:0.000},y坐标：{1:0.000}", Input.GetTouch(0).position.x,Input.GetTouch(0).position.y), guiSkin.box);
    }



    bool IsTouched(Touch touch)
    {
        Vector3 pos = TouchPositionToAnimalPosition(touch);
        float x1 = this.transform.position.x - 0.5f;
        float x2 = this.transform.position.x + 0.5f;
        float y1 = this.transform.position.y - 0.5f;
        float y2 = this.transform.position.y + 0.5f;
        if (x1<pos.x&& x2 > pos.x&& y1 < pos.y && y2 > pos.y)
        {
            return true;
        }
        else
        { 
            return false;
        }
    }

    void TouchMove(Touch touch)
    {

        if (touch.phase == TouchPhase.Moved)
        {
            this.transform.position = TouchPositionToAnimalPosition(touch);
        }
    }


    Vector2 TouchPositionToAnimalPosition(Touch touch)
    {
        Vector2 pos = new Vector2();
        float longth = Screen.height * 160 / 1280f;
        pos.x = touch.position.x / longth - 2.5f;
        pos.y = touch.position.y / longth - 4;
        return pos;
    }
}
