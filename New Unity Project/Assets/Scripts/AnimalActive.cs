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
        Touch CurTouch = Input.GetTouch(0);
        GUI.Box(new Rect(0, 0, 1000, 100), string.Format("当前手指点的x坐标：{0:0.000},y坐标：{1:0.000},名字：{2}", Camera.main.ScreenToWorldPoint(CurTouch.position).x, TouchPositionToAnimalPosition(CurTouch).y, TouchName(CurTouch)), guiSkin.box);
    }



    bool IsTouched(Touch touch)
    {
        if (TouchName(touch) == "quadrel_26")
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
            this.transform.position= Camera.main.ScreenToWorldPoint(touch.position);
        }
    }


    Vector2 TouchPositionToAnimalPosition(Touch touch)
    {
        RaycastHit2D touchray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
        return touchray.transform.position;
    }

    GameObject touchedobject(Touch touch)
    {
        RaycastHit2D touchray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
        return touchray.transform.gameObject;
    }

    string TouchName(Touch touch)
    {
        RaycastHit2D touchray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
        return touchray.transform.gameObject.name;
    }
}
