using UnityEngine;
using System.Collections;

public class MovingPlatform : Entity {

    public GameObject platform;
    public GameObject[] track;
    public bool reversed = false;

    private int trackSegment;

	// Use this for initialization
	void Start () {
        trackSegment = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (track.Length > 0) {
            if (trackSegment >= track.Length) {
                trackSegment = track.Length-1;
                reversed = true;
            } else if (trackSegment < 0) {
                if(track.Length > 1) {
                    trackSegment = 1;
                }
                reversed = false;
            }

            Vector3 diff = track[trackSegment].transform.position - platform.transform.position;
            if( speed > diff.magnitude ) {
                platform.transform.position = track[trackSegment].transform.position;
                if(reversed) {
                    --trackSegment;
                } else {
                    ++trackSegment;
                }
            } else {
                platform.transform.Translate(diff.normalized * speed);
            }
        }
	}
}
