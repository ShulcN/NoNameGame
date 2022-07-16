using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffieMachine : MonoBehaviour
{
    private Animator anim;
    //private Collider coll;
    //private Collider coll2;
    private bool mouseHere = false;
    public GameObject CoffieMachinePrefab;
    public GameObject CoffieMachinePanel;
    public GameObject CoffieTalk;
    public GameObject MC;

    private float Texttim = -3.2f;
    
    void Awake()
    {
        anim = CoffieMachinePrefab.GetComponent<Animator>();
        anim.speed = 0;
        //coll = GetComponent<Collider>();
        //coll2 = GetComponent<Collider>();
        //anim.enabled = false;
    }
    void OnMouseEnter()
    {
        
        anim.CrossFade("CoffieMachineActivate", 0);
        mouseHere = true;
        
    }
    void OnMouseExit()
    {

        anim.CrossFade("CoffieMachine", 0);
        mouseHere = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && (mouseHere) && (Texttim+3.2f < Time.time))
        {
            Talk();
            //mouseHere = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && (mouseHere))
        {

        }
        
    }
    void Talk()
    {
        
        GameObject go = Instantiate<GameObject>(CoffieTalk); 
        Vector3 pos = MC.transform.position;
        pos.y += 2;
        go.transform.position = pos;
        Texttim = Time.time;   
    }
     
}
