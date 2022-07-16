using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChange : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer Srend;
    void Awake()
    {
        anim = GetComponent<Animator>();
        Srend = GetComponent<SpriteRenderer>();
        anim.speed = 0;
    }
    void OnTriggerEnter(Collider coll)
    {
        
        //particleSystem.renderer.sortingLayerID = 5;
        GameObject go = coll.gameObject;
        if (go.tag == "MainCharcter")
        {
            anim.CrossFade("CharcterHere", 0);
            Srend.sortingLayerName = "Wall";
        }
        return;
    }
    void OnTriggerExit(Collider coll)
    {
        
        GameObject go = coll.gameObject;
        if (go.tag == "MainCharcter")
        {
            anim.CrossFade("Original", 0);
            if (tag == "BackWall")
            Srend.sortingLayerName = "WallBack";
        }
        return;
    }
}
