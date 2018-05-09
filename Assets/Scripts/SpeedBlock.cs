using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBlock : Wall {

    SpriteRenderer orangeSquare;

    [SerializeField] float speedValue = 1;
    [SerializeField] int uses = 1;
    int currentUses;

    void Start()
    {
        target = bounds[boundCheck].transform.position;
        movingSquare = transform;

        orangeSquare = GetComponent<SpriteRenderer>();
        currentUses = uses;
        if (currentUses >= 4) { orangeSquare.color = new Color(.8f, .3f, 0f); }
        else if (currentUses == 3) { orangeSquare.color = new Color(.8f, .45f, 0f); }
        else if (currentUses == 2) { orangeSquare.color = new Color(.8f, .55f, 0f); }
        else if (currentUses == 1) { orangeSquare.color = new Color(.8f, .7f, 0f); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (finite)
        {
            if (collision.gameObject.tag == "Player")
            {
                currentUses--;
                if (currentUses <= 0) { Destroy(gameObject); }
                if (currentUses >= 4) { orangeSquare.color = new Color(.8f, .3f, 0f); }
                else if (currentUses == 3) { orangeSquare.color = new Color(.8f, .45f, 0f); }
                else if (currentUses == 2) { orangeSquare.color = new Color(.8f, .55f, 0f); }
                else if (currentUses == 1) { orangeSquare.color = new Color(.8f, .7f, 0f); }
            }
        }
    }

    public float SpeedValue
    {
        get { return speedValue; }
        set { }
    }
}
