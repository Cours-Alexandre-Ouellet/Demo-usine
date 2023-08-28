using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateur : MonoBehaviour
{
    [SerializeField]
    private GameObject prototype;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject nouvelleInstance = Instantiate(prototype, transform);
            //nouvelleInstance.transform.position = transform.position;
        }
    }
}
