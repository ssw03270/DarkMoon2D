using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string horizontalAxisName = "Horizontal";
    public string verticalAxisName = "Vertical"; 
    public string mouseXAxisName = "Mouse X";
    public string mouseYAxisName = "Mouse Y";

    public float horizontal;
    public float vertical;
    public float mouseX;
    public float mouseY;
    public bool mouseLeftClick;
    public bool mouseRightClick;

    // 매프레임 사용자 입력을 감지
    private void FixedUpdate()
    {
        /*if (GameManager.instance != null && GameManager.instance.isGameover)
        {
            move = 0;
            rotate = 0;
            fire = false;
            reload = false;
            return;
        }*/

        horizontal = Input.GetAxis(horizontalAxisName);
        vertical = Input.GetAxis(verticalAxisName);
        mouseX = Input.GetAxis(mouseXAxisName);
        mouseY = Input.GetAxis(mouseYAxisName);
        mouseLeftClick = Input.GetMouseButton(0);
        mouseRightClick = Input.GetMouseButton(1);
    }

}
