using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour
{
    public GameObject rotateObject;
    Transform mainCamera;

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    public void RotateDirection(Vector2 dir)
    {
        Vector3 camUp = mainCamera.forward;
        Vector3 playerUp = new Vector3(camUp.x, 0, camUp.z).normalized;

        Quaternion targetRotation = Quaternion.FromToRotation(playerUp, new Vector3(dir.x, 0, dir.y));

        Quaternion standardRotation = Quaternion.FromToRotation(Vector3.forward, playerUp);

        Quaternion ResultRot = standardRotation * targetRotation;
        Vector3 ResultDir = ResultRot * Vector3.forward;

        rotateObject.transform.rotation = Quaternion.LookRotation(ResultDir, Vector3.up);
    }
}
