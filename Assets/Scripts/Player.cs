using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //init
    public GameObject indicator;

    private Rigidbody rb;
    public LayerMask collisionMask;

    public int weapon_range;

    public GameObject pf_bullet;
    public int f_bullet;

    private int f_multiplier = 10000;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //face indicator to mouse
        RotateIndicator();

        //manage user inputs
        Inputs();
    }

    private void RotateIndicator()
    {
        //get position of mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //get angle between mouse and indicator (in radians)
        float angleRad = Mathf.Atan2(mousePos.y - indicator.transform.position.y, mousePos.x - indicator.transform.position.x);

        //convert angleRad to degrees
        float angleDeg = (180 / Mathf.PI) * angleRad;

        //rotate indicator
        indicator.transform.rotation = Quaternion.Euler(0, 0, angleDeg);
    }

    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0)) {
            DoFire();
        }

        if (Input.GetMouseButton(1)) {
            DoFire();
        }
    }

    private void DoFire() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.Scale(new Vector3(1,1,0));

        GameObject bullet = Instantiate<GameObject>(pf_bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Init((mousePos - transform.position).normalized * f_bullet);
    }
}
