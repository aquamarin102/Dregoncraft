using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointRotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }
}
