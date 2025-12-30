using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestruirCone : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Cone")
        {
            Destroy(target.gameObject);
        }
    }

}
