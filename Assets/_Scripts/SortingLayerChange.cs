using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerChange : MonoBehaviour
{
    private SpriteRenderer Srend;
    private string sName;
    // Start is called before the first frame update
    void Start()
    {
        Srend = GetComponent<SpriteRenderer>();
        sName = Srend.sortingLayerName;
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject go = coll.gameObject;
        if (go.tag == "MainCharcter")
        {
            Srend.sortingLayerName = "Wall";
        }
    }
    void OnTriggerExit(Collider coll)
    {
        GameObject go = coll.gameObject;
        if (go.tag == "MainCharcter")
        {
            Srend.sortingLayerName = sName;
        }
    }
}
