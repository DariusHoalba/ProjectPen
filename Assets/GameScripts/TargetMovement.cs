using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.forward * Time.deltaTime * 5f);
        if(Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.back * Time.deltaTime * 5f);
        if(Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * Time.deltaTime * 5f);
        if(Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * Time.deltaTime * 5f);
    }
}
