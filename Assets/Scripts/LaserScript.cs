using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
    public float turnOnTime = 0;
    public float turnOffTime = 0;

    private float timeToTurnOn = 0;
    private float timeToTurnOff = 0;

    private bool laserOn = true;

    private Vector2 topLaserEmitter;
    private Vector2 bottomLaserEmitter;

    private Animator _animator;

	// Use this for initialization
	void Start () {
        topLaserEmitter = transform.Find("LaserTop").position;
        bottomLaserEmitter = transform.Find("LaserBottom").position;

        var laserTrans = transform.Find("LaserBeamContainer");
        var dist = Mathf.Abs(topLaserEmitter.y - bottomLaserEmitter.y) + 2;

        laserTrans.position = new Vector2(laserTrans.position.x, (topLaserEmitter.y + bottomLaserEmitter.y) / 2.0f);
        laserTrans.localScale = Vector2.Scale(laserTrans.localScale, new Vector2(1, dist));

        GameObject laserBeam = laserTrans.Find("LaserBeam").gameObject;

        _animator = laserBeam.GetComponent<Animator>();

        if (turnOffTime != 0)
            timeToTurnOff = Time.time + turnOffTime;
    }
	
	// Update is called once per frame
	void Update () {
	    if (laserOn && turnOffTime>0 && Time.time > timeToTurnOff)
        {
            _animator.SetBool("LaserOn", false);
            laserOn = false;

            if (turnOnTime != 0)
                timeToTurnOn = Time.time + turnOnTime;
        }

        if (!laserOn && turnOnTime > 0 && Time.time > timeToTurnOn)
        {
            _animator.SetBool("LaserOn", true);
            laserOn = true;

            if (turnOffTime != 0)
                timeToTurnOff = Time.time + turnOffTime;
        }
    }
}
