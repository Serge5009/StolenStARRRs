using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MovementJoystick : MonoBehaviour
{
    public GameObject Joystick;
    public GameObject JoystickBG;
    public Vector2 JoystickVec;

    public Vector2 JoystickTouchPos;
    public Vector2 JoystickOrjinalPos;
    private float JoystickRad;
    // Start is called before the first frame update
    void Start()
    {
        JoystickOrjinalPos = JoystickBG.transform.position;
        JoystickRad = JoystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;

    }

    public void PointerDown()
    {
        Joystick.transform.position = Input.mousePosition;
        JoystickBG.transform.position = Input.mousePosition;
        JoystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        JoystickVec = (dragPos - JoystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, JoystickTouchPos);

        if(joystickDist < JoystickRad)
        {
            Joystick.transform.position = JoystickTouchPos + JoystickVec * joystickDist;
        }
        else
        {
            Joystick.transform.position = JoystickTouchPos + JoystickVec * JoystickRad;
        }
    }

    public void PointerUp()
    {
        JoystickVec = Vector2.zero;
        Joystick.transform.position = JoystickOrjinalPos;
        JoystickBG.transform.position = JoystickOrjinalPos;
    }

    
}
