using UnityEngine;
using System.Collections;

public class ExpandControl : MonoBehaviour {

    public int RateOfExpansion;
    public float SpeedOfExpansion;

    private float frameCounter;

	// Update is called once per frame
	void Update ()
    {
        frameCounter += Time.deltaTime;
        if (frameCounter > RateOfExpansion)
        {
            Vector3 local = transform.localPosition;
            local.x += SpeedOfExpansion;
            transform.localPosition = local;
            frameCounter = 0f;
        }
	}
}
