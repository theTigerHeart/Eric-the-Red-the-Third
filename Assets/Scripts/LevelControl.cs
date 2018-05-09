using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelControl : MonoBehaviour
{

    [SerializeField] float startingSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] int trophyReq;
    [SerializeField] string level;
    [SerializeField] string nextLevel;

    void Start()
    {

    }

    void Update()
    {

    }
    public float StartingSpeed
    {
        get { return startingSpeed; }
        set { }
    }
    public float MaxSpeed
    {
        get { return maxSpeed; }
        set { }
    }
    public int TrophyReq
    {
        get { return trophyReq; }
        set { }
    }
    public void LoseLevel()
    {
        Debug.Log("Lost");
        SceneManager.LoadScene(level);
    }
    public void WinLevel()
    {
        Debug.Log("Win");
        SceneManager.LoadScene(nextLevel);
    }
}