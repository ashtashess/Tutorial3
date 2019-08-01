using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyBoundry : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
