using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuOption : MonoBehaviour {

    [SerializeField] string level;
 
    void Start()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("It Worked");
        SceneManager.LoadScene(level);
    }
}
