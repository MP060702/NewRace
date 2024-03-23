using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject Target;

    private void Update()
    {
        transform.LookAt(Target.transform.position);
        Destroy(gameObject, 4f);
    }
}
