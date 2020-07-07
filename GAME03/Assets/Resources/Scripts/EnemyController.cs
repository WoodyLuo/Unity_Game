using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    /// 宣告物件 ///
    // 主要遊戲畫布
    //private Canvas gameCanvasUI;
    //private float gameCanvasFixedScale;
    //private float gameCanvasFixedWidth;
    //private float gameCanvasFixedHeight;

    // 玩家
    private Image playerImgUI;
    private Vector3 playerFixedScale;
    private float playerFixedWidth;
    private float playerFixedHeight;
    private float playerHeightRadius;

    // 敵人
    private Vector3 enemyShortFixedScale;
    private float enemyShortFixedWidth;
    private float enemyShortFixedHeight;
    private float enemyShortHeightRadius;

    private float droppingFactor;
    private float threshold;
    private bool gameHasEnded = false;
    //private Image enemyShortUI;


    // Start is called before the first frame update
    void Start()
    {
        this.droppingFactor = -0.2f;

        //this.enemyShortUI = Instantiate(enemyShortUIPrefab, Quaternion.identity) as Image;

        // 畫布
        //this.gameCanvasUI = GameObject.Find("Game03Canvas").GetComponent<Canvas>();
        //this.gameCanvasFixedScale = this.gameCanvasUI.scaleFactor;         // 取得符合Canvas的縮放比例
        //this.gameCanvasFixedHeight = this.gameCanvasUI.pixelRect.height;   //取得Canvas縮放過的(screen - fitted)高度
        //this.gameCanvasFixedWidth = this.gameCanvasUI.pixelRect.width;     //取得Canvas縮放過的(screen - fitted)寬度

        //transform.SetParent(gameCanvas.transform, false);
        // 玩家
        this.playerImgUI = GameObject.Find("Player_img").GetComponent<Image>();
        this.playerFixedScale = this.playerImgUI.rectTransform.lossyScale;   // 取得玩家縮放比
        this.playerFixedHeight = this.playerImgUI.rectTransform.rect.height * this.playerFixedScale.x; // 取得玩家x軸(高度)的縮放比
        this.playerFixedWidth = this.playerImgUI.rectTransform.rect.width * this.playerFixedScale.y;   // 取得玩家y軸(高度)的縮放比
        this.playerHeightRadius = this.playerFixedHeight / 2.0f;              // 取得玩家物件的半徑大小(以高度為基礎)

        // 敵人
        this.enemyShortFixedScale = transform.lossyScale;          // 取得敵人(箭頭)縮放比
        this.enemyShortFixedHeight = 80 * this.enemyShortFixedScale.x;  // 取得敵人(箭頭)x軸(寬度)的縮放比
        this.enemyShortFixedWidth = 80 * this.enemyShortFixedScale.y;   // 取得敵人(箭頭)y軸(高度)的縮放比
        this.enemyShortHeightRadius = this.enemyShortFixedHeight / 2.0f;     // 取得敵人物件的半徑大小(以高度為基礎)

        //Debug.LogFormat("Player -- Scale:{0};\t Height:{1};\tWidth:{1}\t", this.playerFixedScale, this.playerFixedHeight, this.playerFixedWidth);
        //Debug.LogFormat("Enemy -- Scale:{0};\t Height:{1};\tWidth:{1}\t", this.enemyShortFixedScale, this.enemyShortFixedHeight, this.enemyShortFixedWidth);

        // 碰撞閥值(this.threshold) = (玩家半徑＋敵人半徑)*閥值係數
        this.threshold = (this.playerHeightRadius + this.enemyShortHeightRadius) * 0.5f;  // 碰撞距離閥值設定
        //Debug.LogFormat("Threshold:{0};", this.threshold);

    }// End - Start()


    // Update is called once per frame
    void Update()
    {

        if (this.gameHasEnded != true)
        {
            // 每次動畫更新，物件就等速落下
            this.droppingFactor = this.droppingFactor * 1.0035f;
            transform.Translate(0.0f, this.droppingFactor, 0.0f);

            if (transform.position.y <= -10.0f)
            {
                // 銷毀超出由下畫面的敵人(箭頭)
                Destroy(gameObject);
            }// end - if

            // 新增衝突判定
            Vector2 p1 = transform.position;    // 敵人(箭頭)的中心點座標
            Vector2 p2 = this.playerImgUI.transform.position; // 玩家的中心點座標
            Vector2 dir = p1 - p2;    // 敵人(箭頭)到玩家的向量
            float d = dir.magnitude;  // 敵人(箭頭)到玩家的距離

            //Debug.Log("----");
            //Debug.LogFormat("Enemy Position:{0};\tPlayer Pisotion:{1};\tVector form Enemy to Player:{2}", p1, p2, dir);

            // 取得符合螢幕縮放大小的縮放比
            // this.playerImgUI.rectTransform.lossyScale. ==> Scale:(1.0, 1.0, 1.0)
            //Debug.LogFormat("d:{0};\tPlayer Radius:{1};\tEnemy-Short Radius:{2}", d, this.playerHeightRadius, this.enemyShortHeightRadius);

            if (d < this.threshold)  // 衝突事件判斷
            {
                // 發生碰撞就扣血
                GameObject director = GameObject.Find("GameManager");  // 尋找與建立director物件
                director.GetComponent<GameDirector>().DecreaseHp();    // 取的GameDirector元件(物件)並使用DecreaseHp()方法

                // 發生碰撞衝突就銷毀物件
                Destroy(gameObject);

                // 沒有生命值就重新遊戲
                if (GameObject.Find("HpGauge_img").GetComponent<Image>().fillAmount == 0.0f)
                {
                    this.gameHasEnded = true;
                    GameObject.Find("GameManager").GetComponent<GameDirector>().GameOver();
                }
            }// end - if
        }//end -if
    }// End - Update()


    public Vector3 PlayerFixedScale
    {
        get
        {
            return this.playerFixedScale;
        }// end - get
    }// End - PlayerFixedScale(Getter)


    public float PlayerFixedHeight
    {
        get
        {
            return this.playerFixedHeight;
        }// end - get
    }// End - PlayerFixedHeight(Getter)


    public float PlayerFixedWidth
    {
        get
        {
            return this.playerFixedWidth;
        }// end - get
    }// End - PlayerFixedWidth(Getter)


    public float PlayerHeightRadius
    {
        get
        {
            return this.playerHeightRadius;
        }// end - get
    }// End - PlayerHeightRadius(Getter)


    public Vector3 EnemyShortFixedScale
    {
        get
        {
            return this.enemyShortFixedScale;
        }// end - get
    }// End - EnemyShortFixedScale(Getter)


    public float EnemyShortFixedHeight
    {
        get
        {
            return this.enemyShortFixedHeight;
        }// end - get
    }// End - EnemyShortFixedHeight(Getter)


    public float EnemyShortFixedWidth
    {
        get
        {
            return this.enemyShortFixedWidth;
        }// end - get
    }// End - EnemyShortFixedWidth(Getter)


    public float EnemyShortHeightRadius
    {
        get
        {
            return this.enemyShortHeightRadius;
        }// end - get
    }// End - EnemyShortHeightRadius(Getter)


    public float Threshold
    {
        get
        {
            return this.threshold;
        }// end - get
    }// End - Threshold(Getter)


}// END - ArrowController{}

