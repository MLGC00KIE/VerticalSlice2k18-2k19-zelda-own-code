using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    Transform player;
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private float rSpeed = 10f;
    [SerializeField]
    private Transform anchor;
    private int lSpeed = 2;
    private float forceMultiplier = 100f;
    [SerializeField]
    private bool moveTowardsPlayer = false;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("player").transform;
        StartCoroutine(MoveCloserCountdown(3, 5));
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveTowardsPlayer)
        {
            moveCloseTo(player);
        } else
        {
            moveCloseTo(anchor);
        }
        lookAt(player);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            KnockBackOnArrow();
        }
	}

    void moveCloseTo(Transform target)
    {

        if(ButNotTooCloseForComfort(player))
        {
            // move towards
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        } else if(target.transform.name == "Boss Anchor")
        {
            // move back
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    void lookAt(Transform target)
    {
        // rotate towards
        var rotation = Quaternion.LookRotation(target.position - anchor.transform.position);
        float rStep = rSpeed * Time.deltaTime;
        anchor.transform.rotation = Quaternion.RotateTowards(anchor.transform.rotation, rotation, rStep);

    }

    bool ButNotTooCloseForComfort(Transform target)
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist <= 10)
            return false;

        return true;
    }

    IEnumerator MoveCloserCountdown(float timeBefore, float duration)
    {
        yield return new WaitForSeconds(timeBefore);
        moveTowardsPlayer = true;
        yield return new WaitForSeconds(duration);
        moveTowardsPlayer = false;
    }

    public void KnockBackOnArrow()
    {
        moveTowardsPlayer = false;
        rb.AddForce((anchor.position - player.position.normalized) * forceMultiplier);
    }
}
