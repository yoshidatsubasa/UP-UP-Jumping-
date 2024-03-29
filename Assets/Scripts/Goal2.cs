using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal2 : MonoBehaviour
{
    [SerializeField]
    GameObject clearUI;

    
    public Text coinNumText, resultCoinText;

    private PlayerController ball;
   
    [SerializeField] private GameObject pausePanel;
   
    private TimeCounter time;
    public GameObject selectButtan;
    public GameObject titleButtan;
    int stageCoinNum;
    int coinCount;

    //[SerializeField] Font customFont; //カスタムフォント

    private Pause pauseScript; // Pauseスクリプトへの参照

    public GameObject setumeiWindow; // RadarSetumeiWindowで設定されたUI
    public GameObject setumeiWindow2; // RadarSetumeiWindowで設定されたUI
    public GameObject setumeiWindow3; // RadarSetumeiWindowで設定されたUI
    public GameObject setumeiWindow4; // RadarSetumeiWindowで設定されたUI


    void Start()
    {
        // ステージ内のコインの枚数を取得
        stageCoinNum = GameObject.FindGameObjectsWithTag("Coin").Length;

        // Pauseスクリプトへの参照を取得
        pauseScript = FindObjectOfType<Pause>();

        ////カスタムフォントを適用する
        //coinNumText.font = customFont;
        //resultCoinText.font = customFont;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinCount = Coincounter.getscore();

            
            // Ballの動きを司るスクリプトをオフにする。
            ball = collision.gameObject.GetComponent<PlayerController>();
            ball.enabled = false;

           

            // ２秒後にボールが動けるようにする。
            //Invoke("StopOff", 2.0f);

            Debug.Log("ゴール");

            Time.timeScale = 0;

            pausePanel.SetActive(false);

            selectButtan.SetActive(true);

            titleButtan.SetActive(true);

            clearUI.SetActive(true);

            resultCoinText.text = coinCount.ToString().PadLeft(3) + "/" + stageCoinNum;

            pauseScript.GameOver();

            // ゴールに触れたときにRadarSetumeiWindowのsetumeiWindowを非表示にする
            if (setumeiWindow != null)
            {
                setumeiWindow.SetActive(false);
            }
            if (setumeiWindow2 != null)
            {
                setumeiWindow2.SetActive(false);
            }
            if (setumeiWindow3 != null)
            {
                setumeiWindow3.SetActive(false);
            }
            if (setumeiWindow4 != null)
            {
                setumeiWindow4.SetActive(false);
            }
        }

    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);

        Time.timeScale = 1;
        Coincounter.coinCount = 0;

    }
    public void ChangeResult(string nextScene)
    {

        SceneManager.LoadScene("Over");

    }

    //void StopOff()
    //{
    //    // ポイント
    //    // Ballの動きを司るスクリプトをオンにする。
    //    ball.enabled = true;
    //}

    void Update()
    {
       
        coinNumText.text = coinCount.ToString();

        if (Input.GetButton("BButton"))
        {
            setumeiWindow.SetActive(false);
            setumeiWindow2.SetActive(false);
            setumeiWindow3.SetActive(false);
            setumeiWindow4.SetActive(false);
        }
    }

}
