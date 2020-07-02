using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 按下左方向鈕時
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3.0f, 0.0f, 0.0f);
        }// end - if

        // 按下左方向鈕時
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(3.0f, 0.0f, 0.0f);
        }// end - if
    }// End - Update()
}// END - PlayerController()

