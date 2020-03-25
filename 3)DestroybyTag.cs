using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyTag : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag == "yourtag")
        {
            Destroy(gameObject);
            Debug.Log("Collision");
        }
    }
}
