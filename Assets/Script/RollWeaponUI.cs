using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollWeaponUI : MonoBehaviour
{
    [SerializeField] float rotate = -2 ;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Rotate(Vector3.forward * rotate, Space.World);
    }
}
