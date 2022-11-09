using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2f)
        {

        }   
    }
}
