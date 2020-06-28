using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetDetectorCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Disappear scriptDisappear = other.GetComponent<Disappear>();
        if(scriptDisappear != null)
        {
            scriptDisappear.IsUnderPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Disappear scriptDisappear = other.GetComponent<Disappear>();
        if (scriptDisappear != null)
        {
            scriptDisappear.IsUnderPlayer = false;
        }
    }
}
