using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] protected Transform sphere;

    protected Rigidbody rb;
    protected float gravityConstant = -9.8f;
    protected Transform _centreTrans;

    void Start()
    {
        //GameObject centre = GameObject.Find("Centre");
        //if (centre != null)
        //    _centreTrans = centre.transform;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 toCentre = sphere.position - transform.position;
        toCentre.Normalize();

        //rb.AddForce(toCentre * gravityConstant, ForceMode.Acceleration);

        Quaternion q = Quaternion.FromToRotation(transform.right, -toCentre);
        q = q * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);

        //transform.LookAt(_centreTrans);
    }

    public void setSphere(Transform newSphere)
    {
        sphere = newSphere;
    }
}
