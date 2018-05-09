using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleBlock : Wall {

    [SerializeField] Transform teleport;
   
    public Transform Teleport
    {
        get { return teleport; }
        set { }
    }
}
