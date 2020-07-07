using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    // 變數宣告
    [SerializeField]
    private Image enemyPrefab;
    [SerializeField]
    private Canvas gameCanvas;
    private float span = 1.2f;  // 每1.2秒產生一次
    private float delta = 0.0f; // 秒數累計值
    private float gameCanvasScale;
    private float gameCanvasHeight;
    private float gameCanvasWidth;
    private float rangeStart;
    private float rangeEnd;
    public bool gameHasEnded = false;


    // Start is called before the first frame update
    void Start()
    {
        // .sprite.rect.width
        this.gameCanvasScale = this.gameCanvas.scaleFactor;       // 取得符合Canvas的縮放比例
        this.gameCanvasHeight = this.gameCanvas.pixelRect.height; // 取得Canvas縮放過的(screen-fitted)高度
        this.gameCanvasWidth = this.gameCanvas.pixelRect.width;   // 取得Canvas縮放過的(screen-fitted)寬度

        Image playerImgUI = GameObject.Find("Player_img").GetComponent<Image>();  // 取得Player_img物件
        Vector3 playerFixedScale = playerImgUI.rectTransform.lossyScale;          // 取得玩家縮放比
        float rangeThreshold = playerImgUI.rectTransform.rect.width * playerFixedScale.y;   // 取得玩家y軸(高度)的縮放比
        this.rangeStart = rangeThreshold;
        this.rangeEnd = this.gameCanvasWidth - rangeThreshold;

        //Debug.LogFormat("Canvas Scale:{0};\tCanvas Height:{1};\tCanvas Width:{2}", this.gameCanvasScale, this.gameCanvasHeight, this.gameCanvasWidth);
    }// End - Start()


    // Update is called once per frame
    void Update()
    {
        if (this.gameHasEnded == false)
        {
            this.delta = this.delta + Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0.0f;

                float anchPoint = Random.Range(this.rangeStart, this.rangeEnd);
                Image enemy = Instantiate(this.enemyPrefab) as Image;
                // 一定要先設定將實體化的物件父繼承類別，方可繼續使用其他函示。
                enemy.transform.SetParent(this.gameCanvas.transform);  // 設定敵人(箭頭)的父類別
                // 重新改變敵人(箭頭)的影像大小(符合螢幕縮放比)
                enemy.rectTransform.sizeDelta = new Vector3(enemy.rectTransform.rect.width*this.gameCanvasScale, enemy.rectTransform.rect.height*this.gameCanvasScale, 0.0f);
                enemy.transform.position = new Vector3(anchPoint, this.gameCanvasHeight, 0.0f);

                // 調用enemyPrefab的EnenyController元件(物件)的Threshold取用子的方法。
                //float thresh = enemy.GetComponent<EnemyController>().Threshold;
            }// end - if

            if(GameObject.Find("GameManager").GetComponent<GameDirector>().gameHasEnded == true)
            {
                this.gameHasEnded = true;
            }// end - if
        }// end - if
    }// End - Update()


    public float GameCanvasScale
    {
        get
        {
            return this.gameCanvasScale;
        }// end - get
    }// End - GameCanvasScale(Getter)


    public float GameCanvasHeight
    {
        get
        {
            return this.gameCanvasHeight;
        }// end - get
    }// End - GameCanvasHeight(Getter)


    public float GameCanvasWidth
    {
        get
        {
            return this.gameCanvasWidth;
        }// end - get
    }// End - GameCanvasWidth(Getter)


}// END - EnemyGenerator(Object)
