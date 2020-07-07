using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    // 變數宣告
    private Image playerImgUI;


    // Start is called before the first frame update
    void Start()
    {
        // 取得"Player_img"實體Image物件
        this.playerImgUI = GameObject.Find("Player_img").GetComponent<Image>();
    }// End - Start()


    // 玩家右移方法 (請使用事件觸發並綁定UI元件)
    public void PlayerMoveRight()
    {
        this.playerImgUI.transform.Translate(10.0f, 0.0f, 0.0f);
    }// End - PlayerMoveRight()


    // 玩家左移方卡 (請使用事件觸發並綁定UI元件)
    public void PlayerMoveLeft()
    {
        this.playerImgUI.transform.Translate(-10.0f, 0.0f, 0.0f);
    }// End - PlayerMoveLeft()


    /*
    // Update is called once per frame
    void Update()
    {
        // 按下左方向鈕時
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3.0f, 0.0f, 0.0f);
        }// end - if

        // 按下右方向鈕時
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(3.0f, 0.0f, 0.0f);
        }// end - if
    }// End - Update()
    */

}// END - PlayerController()

