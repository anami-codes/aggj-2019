using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualObstacle : MonoBehaviour {

    public enum ObstacleType {
        Timed,
        Animated,
        UntilKilled,
    }

    public ObstacleType obstacleType;
    public float valueToUse;

    private float timer;

	public void Initialize () {
        if (obstacleType == ObstacleType.Timed) timer = Time.time + valueToUse;
	}
	
	void Update () {

        if ((obstacleType == ObstacleType.Timed) && (timer <= Time.time)) EndTime();

    }

    public void Damage () {
        valueToUse -= 1;
        if (valueToUse <= 0) EndTime();
    }

    public void EndTime () {
        gameObject.SetActive(false);
    }
}
