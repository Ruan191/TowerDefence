using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Pivot_Y;
    public Transform Pivot_X;
    public float RotationSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    Vector3 Dir;
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
            Pivot_X.Rotate(Vector3.up.normalized * RotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            Pivot_X.Rotate(Vector3.down.normalized * RotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            Pivot_Y.Rotate(Vector3.right.normalized * RotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            Pivot_Y.Rotate(Vector3.left.normalized * RotationSpeed * Time.deltaTime);

        if (Input.mouseScrollDelta.normalized.y == 1)
        {
            Dir = transform.position - Pivot_Y.position;
            transform.Translate(-Dir.normalized, Space.World);
        }else if (Input.mouseScrollDelta.normalized.y == -1)
        {
            Dir = transform.position - Pivot_Y.position;
            transform.Translate(Dir.normalized, Space.World);
        }


    }
}
