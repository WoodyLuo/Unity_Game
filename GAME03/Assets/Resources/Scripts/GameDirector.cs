using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    // 變數宣告
    private Image hpGauge;
    public bool gameHasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("HpGauge_img").GetComponent<Image>();
    }// End - Start()


    // 減少血量
    public void DecreaseHp()
    {
        // 使用Image.fillAmount，需要將Image UI的Image Type設定為filled類型
        this.hpGauge.fillAmount = this.hpGauge.fillAmount - 0.1f;
    }// End - DecreaseHp()


    // 結束遊戲
    public void GameOver()
    {
        if(this.gameHasEnded==false)
        {
            this.gameHasEnded = true;
            GameObject.Find("Info_canvas").GetComponent<Text>().text = "遊戲結束！";  // 設定文字UI(Info_canvas)的text
            Invoke("Restart", 5.0f);   // 兩秒後執行Restart()方法
        }// end - if
    }// End - GameOver()


    // 重新開始遊戲
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 重新載入遊戲場景
    }// End - Restart()


}// END - GameDirector(Object)
