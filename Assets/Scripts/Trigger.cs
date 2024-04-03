using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(DestroyPlatforms), 0.2f);
        }
    }

    private void DestroyPlatforms()
    {
        Rigidbody rb = GetComponentInParent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        Destroy(transform.parent.gameObject, 1f);
    }

}
