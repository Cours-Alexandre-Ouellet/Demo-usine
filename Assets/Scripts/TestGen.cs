using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGen : MonoBehaviour
{
    [SerializeField]
    private string[] val;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log(val[Random.Range(0, val.Length)]);
        }
    }
}
