using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    [Header("Set in Inspector")]
    public string tellerName;
    public float textLivingTime;
    private float birthTim;
    // Start is called before the first frame update
    void Start()
    {
        birthTim = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > birthTim + textLivingTime)
        {
            Destroy(this.gameObject);
        }
        GameObject tl = GameObject.Find(tellerName);
        Vector3 pos = tl.transform.position;
        pos.y += 2; 
        transform.position = pos;
    }
}
