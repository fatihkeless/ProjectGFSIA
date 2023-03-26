using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeKesimi : MonoBehaviour
{
    public GameObject slicedObjectPrefab;
    public float sliceForce = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanSlice"))
        {
            GameObject slicedObject = Instantiate(slicedObjectPrefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
            slicedObject.GetComponent<Rigidbody>().AddForce(Vector3.down * sliceForce, ForceMode.Impulse);
            Destroy(slicedObject, 5f);

            Destroy(other.gameObject);
        }
    }
}
