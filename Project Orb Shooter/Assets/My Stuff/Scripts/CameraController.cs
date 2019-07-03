using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] protected bool isSecond;
    protected Transform _centerTrans;

    void Start()
    {
        GameObject ship = GameObject.Find("Ship_1");
        if (ship != null)
            _centerTrans = ship.transform;
    }

    void Update()
    {
        if (isSecond)
            transform.rotation = Quaternion.LookRotation(transform.position - _centerTrans.position);
        else
        transform.LookAt(_centerTrans);
    }
}
