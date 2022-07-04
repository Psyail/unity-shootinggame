using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   
    public float Movespeed = 5.0f;
    public GameObject PlayerObject;
    public GameObject TargetObject;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Movement();
        RotateFollowMouse();
    }
    void Movement()
    {
        transform.Translate(Input.GetAxis("Vertical") * Vector2.up * Movespeed * Time.deltaTime);
        transform.Translate(Input.GetAxis("Horizontal") * Vector2.right * Movespeed * Time.deltaTime);
    }
    void RotateFollowMouse()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(PlayerObject.transform.position);
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf .Rad2Deg +270;
        PlayerObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 1;
        TargetObject.transform.position = position;
    }
}
