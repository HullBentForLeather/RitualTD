using UnityEngine;
using System.Collections;

public class PathNode : MonoBehaviour
{
    public PathNode nextNode = null;

    void OnDrawGizmos()
    {
        if (nextNode != null)
        {
            Vector3 mid = Vector3.Lerp(transform.position, nextNode.transform.position, 0.5f);
            Gizmos.color = new Color(.7f, .7f, .7f, 1);
            Gizmos.DrawLine(transform.position, mid);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(mid, nextNode.transform.position);
        }
    }
}
