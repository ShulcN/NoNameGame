using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   // public MainCharcter mCS;
    public GameObject mC;
    public float timeComingToMC = 1f;   
    private float timeFollow;
    void Awake()
    {
        //GameObject mC = GameObject.Find("MainCharcter");
    }
    void LateUpdate()
    {
        Vector3 mCPos = mC.transform.position;
        Vector3 pos0 = transform.position;
        
            if (pos0.x + 2.15f < mCPos.x)
            {
                pos0.x = mCPos.x - 2.15f;
                timeFollow = Time.time;
            }
            else
            {
                if (pos0.x - 2.15f > mCPos.x)
                {
                    pos0.x = mCPos.x + 2.15f;
                    timeFollow = Time.time;
                }
            }
            if (pos0.y + 0.9f < mCPos.y)
            {
                pos0.y = mCPos.y - 0.9f;
                timeFollow = Time.time;
            }
            else
            {
                if (pos0.y - 1.8f > mCPos.y)
                {
                    pos0.y = mCPos.y + 1.8f;
                    timeFollow = Time.time;
                }
            }
        if (Time.time > timeFollow + timeComingToMC)
        {
            
            if (Mathf.Abs(pos0.x) + 3f > Mathf.Abs(mCPos.x) || Mathf.Abs(pos0.y) + 1.1f > Mathf.Abs(mCPos.y))
            {
                pos0 = Vector3.Lerp(pos0, mCPos, Time.deltaTime * timeComingToMC);
                pos0.z = -5;
            }
        }
        transform.position = pos0;
    }
}
