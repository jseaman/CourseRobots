using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
    public AudioClip doorSound;

    private bool doorOpen = false;

    private Animator _animator;
    private Collider2D _collider;
    private AudioSource _audioSource;

    public void OpenDoor ()
    {
        if (!doorOpen)
        {
            _animator.SetBool("DoorOpen", true);            
            _collider.enabled = true;
            doorOpen = true;

            _audioSource.PlayOneShot(doorSound);
        }
    }

    public void CloseDoor ()
    {
        if (doorOpen)
        {
            _animator.SetBool("DoorOpen", false);
            _collider.enabled = false;
            doorOpen = false;

            _audioSource.PlayOneShot(doorSound);
        }
    }

	// Use this for initialization
	void Awake () {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.gameObject.SetActive(false);
            GameManager.gameManager.LevelCompleted();
        }
    }
}
