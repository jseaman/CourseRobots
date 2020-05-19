using UnityEngine;
using System.Collections;

public class LeverScript : MonoBehaviour {
    public GameObject door;
    public float turnOffTime = 0;

    private float timeToTurnOff = 0;

    private Animator _animator;
    private Collider2D _collider;
    private DoorScript _doorScript;

    private bool leverOn = false;

	// Use this for initialization
	void Awake () {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();

        if (door != null)
            _doorScript = door.GetComponent<DoorScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (leverOn && turnOffTime > 0 && Time.time >= timeToTurnOff)
            TurnOFF();
	}

    public void TurnON ()
    {
        _collider.enabled = false;
        _animator.SetBool("LeverON", true);

        if (_doorScript != null)
            _doorScript.OpenDoor();

        if (turnOffTime > 0)
            timeToTurnOff = Time.time + turnOffTime;

        leverOn = true;
    }

    public void TurnOFF ()
    {
        _collider.enabled = true;
        _animator.SetBool("LeverON", false);

        if (_doorScript != null)
            _doorScript.CloseDoor();

        leverOn = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.transform.localScale.x > 0)            
                TurnON();                
        }
    }
}
