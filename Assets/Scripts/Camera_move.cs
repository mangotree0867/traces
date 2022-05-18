using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    Transform ballTransform;
    Vector3 Offset;

    // Start is called before the first frame update
    void Awake()
    {
        ballTransform = GameObject.FindGameObjectWithTag("ball").transform;
        Offset = transform.position - ballTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = ballTransform.position + Offset;
    }
}
