using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private Image hpGauge;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("HpGauge_img").GetComponent<Image>();
    }

    // Update is called once per frame
    public void DecreaseHp()
    {
        // 使用Image.fillAmount，需要將Image UI的Image Type設定為filled類型
        this.hpGauge.fillAmount = this.hpGauge.fillAmount - 0.1f;
        Debug.Log(this.hpGauge.fillAmount);
    }
}
