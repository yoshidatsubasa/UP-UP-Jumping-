using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartCount : MonoBehaviour
{
    //[SerializeField] private GameObject pausePanel;

    //時間を表示するText型の変数
   
    public Text timeText;
    public Text CountText;
    public Text CountText2;
    public Text CountText3;
    public float totaltime = 10.0f;
    float retTime;
    float countdown = 4f;
    int count;
    new public Rigidbody rigidbody;

    public float jumppower = 5;

  

    void Start()
    {
        
   
        //pausePanel.SetActive(true);
       
        //Time.timeScale = 0;  // 時間停止
        
    }

    private void Update()
    {
        if(countdown>=1)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountText.text = count.ToString();
            CountText3.text = "時間内にゴール旗を目指せ！";
            rigidbody.velocity = Vector3.zero;
            rigidbody.velocity = Vector3.up * jumppower;
        }
        if(countdown<=1)
        {
           //pausePanel.SetActive(false);
            CountText.text = "";
            CountText2.text = "Start!!";
            CountText3.text = "";
            totaltime -= Time.deltaTime;
            retTime = (float)totaltime;
            timeText.text = retTime.ToString("f1");
            if(retTime<=0)
            {
                SceneManager.LoadScene("Result");
            }

        }
        if(CountText2.text=="Start!!")
        {
            Destroy(CountText2, 0.5f);
        }


        if (totaltime <= 10.0f && totaltime >= 5.0f)
        {
            timeText.color = Color.red; // 5秒以上10秒以下の間、timeTextの色を赤くする
        }
    }
    
    //private void Pouse()
    //{
    //    Time.timeScale = 0;  // 時間停止
    //    pausePanel.SetActive(true);



    //}

    //private void Resume()
    //{
    //    Time.timeScale = 1;  // 再開
    //    pausePanel.SetActive(false);


    //}
}