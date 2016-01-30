using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public float RotationSpeedX;
    public float RotationSpeedY;
    public float RotationSpeedZ;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(RotationSpeedX * Time.deltaTime, RotationSpeedY * Time.deltaTime, RotationSpeedZ * Time.deltaTime));
    }
}
