using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class movement : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public float speed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
            return;

        var move = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            move += Vector3.left;// * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += Vector3.right;// * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            move += Vector3.up;// * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += Vector3.down;
        }

        //var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
    }
}
