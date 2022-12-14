using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }
}
