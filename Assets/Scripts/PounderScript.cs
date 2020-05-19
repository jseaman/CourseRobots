using UnityEngine;
using System.Collections;

public class PounderScript : MonoBehaviour {
    public float startToFallTime = 3;
    public float resettingSpeed = 2;
    public float initialWait = 1;

    private Vector2 originalPosition;
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private float timeToFall = 0;
    private float timeToWake = 0;


    // states
    private bool atTheTop = true;
    private bool falling = false;
    private bool resetting = false;

    void Awake ()
    {
        originalPosition = transform.position;
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        timeToFall = Time.time + startToFallTime;
        timeToWake = Time.time + initialWait;
    }

    public void Fall ()
    {
        _rigidBody.isKinematic = false;
        falling = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time < timeToWake)
            return;

        if (atTheTop && Time.time >= timeToFall)
        {
            _animator.SetTrigger("ReadyToFall");
            atTheTop = false;            
        }

        if (falling && _rigidBody.IsSleeping())
        {            
            _rigidBody.isKinematic = true;
            
            falling = false;
            resetting = true;
        }

        if (resetting)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, Time.deltaTime * resettingSpeed);

            if (transform.position.y == originalPosition.y)
            {
                _animator.SetTrigger("Reset");
                resetting = false;
                atTheTop = true;
                timeToFall = Time.time + startToFallTime;
            }
        }
	}
}
