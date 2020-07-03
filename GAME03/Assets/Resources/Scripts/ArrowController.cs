using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArrowController : MonoBehaviour
{
    // 宣告物件
    public Image playerImgUI;
    private float playerHeightRadius;
    public Image enemyShortUI;
    private float enemyShortHeightRadius;
    private float threshold;


    // Start is called before the first frame update
    void Start()
    {
        float playerFixedScale = this.playerImgUI.rectTransform.lossyScale.y;       // 取得玩家縮放比
        this.playerHeightRadius = (this.playerImgUI.rectTransform.rect.height * playerFixedScale) / 2.0f;  // 取得玩家物件的半徑大小

        float enemyShortFixedScale = this.enemyShortUI.rectTransform.lossyScale.y;  // 取得敵人(箭頭)縮放比
        this.enemyShortHeightRadius = (this.enemyShortUI.rectTransform.rect.height * enemyShortFixedScale) / 2.0f;  // 取得敵人(箭頭)物件的半徑大小

        this.threshold = (this.playerHeightRadius + this.enemyShortHeightRadius) * 0.5f;  // 碰撞距離閥值設定
        transform.Translate(0.0f, -0.1f, 0.0f);
    }// End - Start()


    // Update is called once per frame
    void Update()
    {
        // 每次動畫更新，物件就等速落下
        transform.Translate(0.0f, -0.3f, 0.0f);

        if(transform.position.y <= 0.0f)
        {
            // 銷毀超出由下畫面的敵人(箭頭)
            Destroy(gameObject);
        }// end - if

        // 新增衝突判定
        Vector2 p1 = transform.position;    // 敵人(箭頭)的中心點座標
        Vector2 p2 = this.playerImgUI.transform.position; // 玩家的中心點座標
        Vector2 dir = p1 - p2;    // 敵人(箭頭)到玩家的向量
        float d = dir.magnitude;  // 敵人(箭頭)到玩家的距離

        Debug.Log("----");
        Debug.LogFormat("Enemy Position:{0};\tPlayer Pisotion:{1};\tVector form Enemy to Player:{2}", p1, p2, dir);

        // 取得符合螢幕縮放打大小的縮放比
        // this.playerImgUI.rectTransform.lossyScale. ==> Scale:(1.0, 1.0, 1.0)
        Debug.LogFormat("d:{0};\tPlayer Radius:{1};\tEnemy-Short Radius:{2}", d, this.playerHeightRadius, this.enemyShortHeightRadius);

        if (d < this.threshold)
        {   // 發生碰撞衝突就銷毀物件
            Destroy(gameObject);
        }
    }// End - Update()


}// END - ArrowController{}

