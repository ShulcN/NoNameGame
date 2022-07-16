using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharcterIsometry : MonoBehaviour
{
    [Header("Set in Inspecor")]
    public float gSpeed = 1;
    public int facing = 1;
    public GameObject MC;
    private Rigidbody rigid;
    private Animator anim;
    private float timeStay;
    private bool Staying;
    public GameObject healthFaces;
    public int Health = 12;
    private Animator animHealth;
    void Awake()
    {
        animHealth = healthFaces.GetComponent<Animator>();
        animHealth.speed = 0;
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        animHealth.CrossFade("_Health_" + Health, 0);
    }
    public int Getfacing()
    {
        return facing;
    }
    public int GetHealth()
    {
        return Health;
    }
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        Vector3 lastPos = pos;
        pos.x += xAxis * gSpeed * Time.deltaTime;
        pos.z += zAxis * gSpeed*2 * Time.deltaTime;
        //pos.z += zAxis * gSpeed * Time.deltaTime;
        //pos.x += zAxis * gSpeed/3.5f * Time.deltaTime;
        //pos.x += xAxis * gSpeed * Time.deltaTime;
        transform.position = pos;
        if (pos.x > lastPos.x)
        {
            facing = 1;
            anim.CrossFade("MainCharcterG0_" + facing, 0);
            anim.speed = 1;
        }
        else
        {
            if (pos.x < lastPos.x)
            {
                facing = 3;
                anim.CrossFade("MainCharcterG0_" + facing, 0);
                anim.speed = 1;
            }
            else
            {
                if (pos.z < lastPos.z)
                {
                    facing = 0;
                    anim.CrossFade("MainCharcterG0_" + facing, 0);
                    anim.speed = 1;
                }
                else
                {
                    if (pos.z > lastPos.z)
                    {
                        facing = 2;
                        anim.CrossFade("MainCharcterG0_" + facing, 0);
                        anim.speed = 1;
                    }
                }
            }
        }

        if (pos == lastPos)
        {

            if (!Staying)
            {

                Stay();

                Staying = true;
                return;
            } /*else
            {
                if (facing == 2)
                {
                    anim.CrossFade("MainCharcter ", 0);
                    
                }
            }
            */


        }
        else { Staying = false; }
    }
    void Stay()
    {

        anim.CrossFade("MainCharcterStay_" + facing, 0);


    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject go = coll.gameObject;
        // Damage
        if (go.tag == "Enemy")
        {
            print("Oh, no!");
            Health--;
        }
        if (Health <= 2) 
        {
            Die();
            return;
        }
        animHealth.CrossFade("_Health_" + Health, 0);
    }
    public void Die()
    {
        print("you are dead");
    }
}
