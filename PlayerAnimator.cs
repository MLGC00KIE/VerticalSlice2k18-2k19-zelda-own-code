using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour
{

    public Animator anim;
    public Rigidbody rbody;

    private bool run;

    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isWalking", true);
        } else if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isWalking", false);
            anim.Play("Idle");
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            anim.Play("death");
        }
    }
}