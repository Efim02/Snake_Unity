using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxPointsText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StaticClass.Load();
        GetComponent<Text>().text = StaticClass.Load().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
