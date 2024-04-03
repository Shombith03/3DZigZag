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
        GameObject.Find("PlatformSpawner").gameObject.GetComponent<PlatformSpawner>().RemovePlatformFromList(rb.gameObject);
        rb.useGravity = true;
        rb.isKinematic = false;
        Destroy(transform.parent.gameObject, 1f);
    }

}
