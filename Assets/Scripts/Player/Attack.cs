using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // other detect the object that is hit
    {
        Debug.Log(other.name);
    }
}
