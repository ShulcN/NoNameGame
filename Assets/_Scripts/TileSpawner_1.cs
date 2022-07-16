using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner_1 : MonoBehaviour
{
    public GameObject WallPrefabDown_1;
    public GameObject WindowPrefabDown_1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWallDown_1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnWallDown_1()
    {
        Vector3 pos = new Vector3(-6.25f, -6.865f, 6.881834f);
        
        for (int i = 0; i < 15; i++)
        {
            GameObject WallDown_1 = Instantiate<GameObject>(WallPrefabDown_1);
            
            WallDown_1.transform.position = pos;
            pos.x += 0.95f;
        }
        GameObject WindowDown_1 = Instantiate<GameObject>(WindowPrefabDown_1);
    }
}
