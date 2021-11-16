using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int teamBlueScore = 0;

    public int teamRedScore = 0;


    Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 startPoint = new Vector3(204, 97, -564);

        if(other.gameObject.tag == "BluGoal")
        {
            teamRedScore += 1;
        }

        if (other.gameObject.tag == "RedGoal")
        {
            teamBlueScore += 1;
        }

        transform.position = startPoint;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

    }

}
