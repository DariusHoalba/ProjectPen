using Gtec.UnityInterface;
using System;
using UnityEngine;
using static Gtec.UnityInterface.BCIManager;
using System.Collections;
using System.Collections.Generic;

public class ClassSelectionAvailableExample : MonoBehaviour
{

    public Transform target;
    public float Force;
    GK goal;
    public GameObject GoalKeeper;
    Vector3 StartPos;
    Vector3 GoalPos;
    Quaternion StartRot;

    public ERPFlashController3D _flashController;
    private Dictionary<int, Renderer> _selectedObjects;

    public GameObject ball;

    private uint _selectedClass = 0;
    private bool _update = false;

    private bool completedShoot = true;
    void Start()
    {
        //attach to class selection available event
        BCIManager.Instance.ClassSelectionAvailable += OnClassSelectionAvailable;
        StartPos = ball.transform.position;
        GoalPos = GoalKeeper.transform.position;
        StartRot = GoalKeeper.transform.rotation;

        _selectedObjects = new Dictionary<int, Renderer>();
        List<ERPFlashObject3D> applicationObjects = _flashController.ApplicationObjects;
        foreach(ERPFlashObject3D obj in applicationObjects)
        {
            Renderer[] renderers = obj.GameObject.GetComponentsInChildren<Renderer>();
            foreach(Renderer renderer in renderers)
            {
                if(renderer.name.Equals("selected"))
                {
                    _selectedObjects.Add(obj.ClassId, renderer);
                }
            }
        }


    }

    void OnApplicationQuit()
    {
        //detach from class selection available event
        BCIManager.Instance.ClassSelectionAvailable -= OnClassSelectionAvailable;
    }

    void Update()
    {
        //TODO ADD YOUR CODE HERE
        if(_update && completedShoot)
        {
            switch (_selectedClass)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    completedShoot = false;
                    StartCoroutine(Wait(-1));
                    break;
                case 3:
                    completedShoot = false;
                    StartCoroutine(Wait(0));
                    break;
                case 4:
                    completedShoot = false;
                    StartCoroutine(Wait(1));
                    break;
                case 5:
                    break;
                case 6:
                    break;

            }
            _update = false;
        } 
    }

    /// <summary>
    /// This event is called whenever a new class selection is available. Th
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClassSelectionAvailable(object sender, EventArgs e)
    {
        ClassSelectionAvailableEventArgs ea = (ClassSelectionAvailableEventArgs)e;
       _selectedClass = ea.Class;
        _update = true;
        Debug.Log(string.Format("Selected class: {0}", ea.Class));
    }

    void shoot(int direction)
    {
        if(direction == -1)
            target.position = new Vector3(-4f, 7.62f, -3.7f);
        else if(direction == 1)
            target.position = new Vector3(-4f, 7.62f, 3.7f);
        else
             target.position = new Vector3(-4f, 7.62f, 0.34f);

        Vector3 Shoot = (target.position - ball.transform.position).normalized;
        ball.GetComponent<Rigidbody>().angularDrag = 1;
        ball.GetComponent<Rigidbody>().AddForce(Shoot * Force, ForceMode.Impulse);
    }

    void CheckGoal()
    {
        GameObject gateCollider = GameObject.Find("footbal_goal/Rectangle001");
        Score score = FindObjectOfType<Score>();
        if (gateCollider.GetComponent<Collider>().bounds.Contains(ball.transform.position))
        {
            score.IncrementPlayerScore();
        } else {
            score.IncrementGoalkeeperScore();
        }
    }

    IEnumerator Wait(int direction)
    {
        completedShoot = false;
        yield return new WaitForSeconds(0.5f);


        FindObjectOfType<GK>().GoalMove();
        yield return new WaitForSeconds(0.75f);
        shoot(direction);
        yield return new WaitForSeconds(1.5f);
        CheckGoal();
        ball.GetComponent<Rigidbody>().angularDrag = 40;
        yield return new WaitForSeconds(5f);
        ball.transform.position = StartPos;
        GoalKeeper.transform.position = GoalPos;
        FindObjectOfType<GK>().Reset();
        FindObjectOfType<GK>().Move = 0;
        FindObjectOfType<GK>().transform.rotation = StartRot;
        completedShoot = true;
    }
}