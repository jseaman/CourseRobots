using UnityEngine;
using System.Collections;

public class WayPointMover : MonoBehaviour {
    public float moveSpeed = 4f;
    public GameObject[] myWaypoints;
    [Tooltip("How much time in seconds to wait at each waypoint.")]
    public float waitAtWaypointTime = 1f;   // how long to wait at a waypoint
    public bool loopWaypoints = true; // should it loop through the waypoints

    // movement tracking
    [SerializeField]
    int _myWaypointIndex = 0; // used as index for My_Waypoints
    float _moveTime = 0;
    Vector2 distance;
    bool _moving = true;

    Rigidbody2D _rigidbody;

    // Use this for initialization
    void Start () {
	
	}

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > _moveTime)
            Movement();
    }

    void Movement()
    {
        // if there isn't anything in My_Waypoints
        if ((myWaypoints.Length != 0) && (_moving))
        {

            // make sure the enemy is facing the waypoint (based on previous movement)
            //Flip(_vx);

            // determine distance between waypoint and enemy
            distance = myWaypoints[_myWaypointIndex].transform.position - transform.position;

            // if the enemy is close enough to waypoint, make it's new target the next waypoint
            if (Mathf.Abs(distance.magnitude) <= 0.05f)
            {
                // At waypoint so stop moving
                _rigidbody.velocity = new Vector2(0, 0);

                // increment to next index in array
                _myWaypointIndex++;

                // reset waypoint back to 0 for looping
                if (_myWaypointIndex >= myWaypoints.Length)
                {
                    if (loopWaypoints)
                        _myWaypointIndex = 0;
                    else
                        _moving = false;
                }

                // setup wait time at current waypoint
                _moveTime = Time.time + waitAtWaypointTime;
            }
            else
            {
                // Set the enemy's velocity to moveSpeed in the x direction.
                _rigidbody.velocity = distance.normalized * moveSpeed;
            }

        }
    }
}
