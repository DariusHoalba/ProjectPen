using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooting : MonoBehaviour
{
    public Transform target;
    public float Force;
    GK goal;
    public GameObject GoalKeeper;
    Vector3 StartPos;
    Vector3 GoalPos;

    void Start()
    {
        StartPos = transform.position;
        GoalPos = GoalKeeper.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Force++;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(Wait());
        }
    }

    void shoot()
    {
        Vector3 Shoot = (target.position - this.transform.position).normalized;
        GetComponent<Rigidbody>().angularDrag = 1;
        GetComponent<Rigidbody>().AddForce(Shoot * Force, ForceMode.Impulse);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        shoot();
        yield return new WaitForSeconds(0.05f);
        FindObjectOfType<GK>().GoalMove();
        yield return new WaitForSeconds(1.5f);
        Force = 0;
        GetComponent<Rigidbody>().angularDrag = 40;
        yield return new WaitForSeconds(5f);
        transform.position = StartPos;
        GoalKeeper.transform.position = GoalPos;
        FindObjectOfType<GK>().Reset();
        FindObjectOfType<GK>().Move = 0;
    }

}