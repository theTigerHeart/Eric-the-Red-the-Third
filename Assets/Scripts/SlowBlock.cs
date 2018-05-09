using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBlock : Wall {

    SpriteRenderer purpleSquare;

    [SerializeField] float slowValue = 1;
    [SerializeField] int uses = 1;
    int currentUses;

    void Start () {
        target = bounds[boundCheck].transform.position;
        movingSquare = transform;

        purpleSquare = GetComponent<SpriteRenderer>();
        currentUses = uses;
        if (currentUses >= 4) { purpleSquare.color = new Color(.8f, 0f, .7f); }
        else if (currentUses == 3) { purpleSquare.color = new Color(.65f, 0f, .7f); }
        else if (currentUses == 2) { purpleSquare.color = new Color(.5f, 0f, .7f); }
        else if (currentUses == 1) { purpleSquare.color = new Color(.4f, 0f, .7f); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (finite)
        {
            if (collision.gameObject.tag == "Player")
            {
                currentUses--;
                if (currentUses <= 0) { Destroy(gameObject); }
                if (currentUses >= 4) { purpleSquare.color = new Color(.8f, 0f, .7f); }
                else if (currentUses == 3) { purpleSquare.color = new Color(.65f, 0f, .7f); }
                else if (currentUses == 2) { purpleSquare.color = new Color(.5f, 0f, .7f); }
                else if (currentUses == 1) { purpleSquare.color = new Color(.4f, 0f, .7f); }
            }
        }
    }

    public float SlowValue
    {
        get { return slowValue; }
        set {  }
    }
}
