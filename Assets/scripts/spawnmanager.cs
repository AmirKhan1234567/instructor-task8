using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ballspawn", 1,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ballspawn()
    {
        Instantiate(ball, new Vector2(-9, 4), Quaternion.identity);
    }
}
