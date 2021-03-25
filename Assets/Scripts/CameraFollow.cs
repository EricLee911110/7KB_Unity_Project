using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    private void FixedUpdate()
    {
        transform.position = target.transform.position + new Vector3(0,0,-10);
        this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(this.GetComponent<Camera>().orthographicSize, (target.GetComponent<Rigidbody>().velocity.magnitude + 90), Time.deltaTime);
    }
}
