using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraIsometry : MonoBehaviour
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

        if (pos0.z + 29.5f < mCPos.z)
        {
            pos0.z = mCPos.z - 29.5f;
            timeFollow = Time.time;
        }
        else
        {
            if  (mCPos.z < pos0.z + 26.5f)
            {
                //print(pos0.z);
                pos0.z = mCPos.z - 26.5f;
                timeFollow = Time.time;
            }
        }
        
        /*
        if (Time.time > timeFollow + timeComingToMC)
        {
                pos0 = Vector3.Lerp(pos0, mCPos, Time.deltaTime * timeComingToMC);
                
                pos0.y = 12;
            
        }
        */
        transform.position = pos0;
        
    }
        
}
