using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class movement : NetworkBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    public float speed = 2.5f;

    // Start is called before the first frame update
   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
            return;

        var xxx = Input.GetAxis("Mouse X");
        Debug.Log(xxx);

        Vector3 dir =  cam.WorldToScreenPoint(transform.position) - Input.mousePosition;
        //var dir = new Vector3(xxx, 0, 0);
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.AngleAxis(angle, transform.rotation.eulerAngles ) * Vector3.one; 

        //WASD movement
        var move = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A)) move += Vector3.left;
        if (Input.GetKey(KeyCode.D)) move += Vector3.right;
        if (Input.GetKey(KeyCode.W)) move += Vector3.up;
        if (Input.GetKey(KeyCode.S)) move += Vector3.down;
        move = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward) * move;
        rb.AddForce(move * speed);

        if (Input.GetKey(KeyCode.Space)){
            if(Cursor.lockState == CursorLockMode.None){
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else{
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}