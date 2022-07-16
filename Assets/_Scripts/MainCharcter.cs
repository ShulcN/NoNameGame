using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainCharcter : MonoBehaviour
{
    [Header("Set in Inspecor")]
    public int Health = 10;
    static public Sprite[] HEALTH;
    public float gSpeed = 1;
    public int facing = 1;
    public GameObject MC;
    private Rigidbody rigid;
    private Animator anim;
    private float timeStay;
    private bool Staying;
    public Canvas canv;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        HEALTH = Resources.LoadAll<Sprite>("HealthFaces(13)");
    }
    public int GetHealth()
    {
        return Health;
    }
    public int Getfacing()
    {
        return facing;
    }
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        Vector3 lastPos = pos;
        pos.x += xAxis * gSpeed * Time.deltaTime;
        pos.y += yAxis * gSpeed * Time.deltaTime;
        transform.position = pos;
        if (pos.x > lastPos.x) {
            facing = 1;
            anim.CrossFade("MainCharcterG0_" + facing, 0);
            anim.speed = 1;
        } else
        {
            if (pos.x < lastPos.x)
            {
                facing = 3;
                anim.CrossFade("MainCharcterG0_" + facing, 0);
                anim.speed = 1;
            }
            else
            {
                if (pos.y < lastPos.y)
                {
                    facing = 0;
                    anim.CrossFade("MainCharcterG0_" + facing, 0);
                    anim.speed = 1;
                }
                else
                {
                    if (pos.y > lastPos.y)
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
            
            if (!Staying) {

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
            
            
        } else { Staying = false; }
        
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

    }
}
