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
    private GameObject go;
    private float span = 3.0f;
    private float delta = 0.0f;
    private float randomRange;
    private float fixedHeightPotiosion;


    private void Awake()
    {
        //this.go = Instantiate(enemyShortPrefab) as GameObject;
    }


    // Start is called before the first frame update
    void Start()
    {
        // .sprite.rect.width
        float gameCanvasScale = this.gameCanvas.scaleFactor;      // 取得符合Canvas的縮放比例
        float gameCanvasWidth = this.gameCanvas.pixelRect.width; // 取得Canvas縮放過的(screen-fitted)寬度
        Debug.LogFormat("Canvas Scale:{0};\tCanvas Width:{1};\t", gameCanvasScale, gameCanvasWidth);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta = this.delta + Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0.0f;
            
            float anchPoint = Random.Range(40, 1880);
            Image enemy = Instantiate(this.enemyPrefab) as Image;
            enemy.transform.parent = this.gameCanvas.transform;
            enemy.transform.position = new Vector3(anchPoint, 1040.0f, 0.0f);
            
        }
    }
}
