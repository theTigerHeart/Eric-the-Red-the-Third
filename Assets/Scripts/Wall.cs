using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    bool forward;
    [SerializeField] bool bouncy;
    [SerializeField] bool loop;
    [SerializeField] bool moving;
    [SerializeField] protected bool finite = true;
    
    protected Transform movingSquare;
    Vector2 startingPos;
    protected  Vector3 target;

    [SerializeField] float currentSpeed = 1;
    protected int boundCheck = 0;
    [SerializeField] protected Transform[] bounds;

    void Start()
    {
        target = bounds[boundCheck].transform.position;
        movingSquare = transform;
    }

    void FixedUpdate()
    {
        if (moving)
        {
            movingSquare.position =
                Vector3.MoveTowards(movingSquare.position, target, currentSpeed * Time.deltaTime);

            if (movingSquare.position == target) { ChangeTarget(); }
        }
    }

    public void ChangeTarget()
    {
        if (forward)
        {
            if (boundCheck < bounds.Length - 1)
            {
                boundCheck++;
                target = bounds[boundCheck].transform.position;
            }
            else if (loop)
            {
                boundCheck = 0;
                target = bounds[boundCheck].transform.position;
            }
            else if (bouncy)
            {
                forward = false;
                boundCheck--;
                target = bounds[boundCheck].transform.position;
            }
        }
        else
        {
            if (boundCheck == 0)
            {
                forward = true;
                boundCheck++;
                target = bounds[boundCheck].transform.position;
            }
            else
            {
                boundCheck--;
                target = bounds[boundCheck].transform.position;
            }
        }
    } //end Change Target

    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }
}
