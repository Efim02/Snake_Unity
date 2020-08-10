using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Basis : MonoBehaviour
{
    static internal List<Vector2> ListVectors = new List<Vector2>();
    public static GameObject point = null;
    public GameObject tempPointGameObject;
    void Start()
    {
        for(int i = 5; i>-6; i--)
        {
            for(int u=-9; u<10; u++)
            {
                ListVectors.Add(new Vector2(u,i));
            }
        }
        point = tempPointGameObject;
        SpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void SpawnPoint()
    {
        GameObject objectPoint = Instantiate(point);
        objectPoint.transform.position = GetRandomPoint();
    }
   /* private void OnGUI()
    {
        int x = 20;        
        foreach (Vector2 v in ListVectors)
        {
            GUI.Label(new Rect(x, 20, 200, 50), v.ToString());
            x += 80;
        }
    }*/
    static Vector2 GetRandomPoint()
    {
        while (true)
        {
            Vector2 vector = new Vector2(Random.Range(-9, 9), Random.Range(-5, 5));
            foreach (Vector2 v in ListVectors)
            {
                if (v.x == vector.x && v.y == vector.y)
                {
                    return v;
                }
            }
        }
    }
}
