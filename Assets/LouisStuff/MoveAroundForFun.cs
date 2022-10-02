using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundForFun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate around z axis by 10 degrees per second
        transform.Rotate(0, 0, 10 * Time.deltaTime);

    }
}
