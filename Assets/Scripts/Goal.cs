using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    GameObject clearUI;

    [SerializeField]
    Text coinNumText, resultCoinText;

    [SerializeField] private GameObject pausePanel;

   

    private PlayerController ball;
    private TimeCounter time;
    public GameObject nextButtan;
    int stageCoinNum;
    int coinCount;

    [SerializeField] Font customFont; //カスタムフォント
    private Pause pauseScript; // Pauseスクリプトへの参照


    void Start()
    {
        // ステージ内のコインの枚数を取得
        stageCoinNum = GameObject.FindGameObjectsWithTag("Coin").Length;

        // Pauseスクリプトへの参照を取得
        pauseScript = FindObjectOfType<Pause>();


        //カスタムフォントを適用する
        coinNumText.font = customFont;
        resultCoinText.font = customFont;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinCount = Coincounter.getscore();

            // ポイント
            // Ballの動きを司るスクリプトをオフにする。
            ball = collision.gameObject.GetComponent< PlayerController>();
            ball.enabled = false;

           
            // ポイント
            // ２秒後にボールが動けるようにする。
            Invoke("StopOff", 2.0f);

            Debug.Log("ゴール");

            Time.timeScale = 0;
            pausePanel.SetActive(false);

            nextButtan.SetActive(true);

            clearUI.SetActive(true);

            resultCoinText.text = coinCount.ToString().PadLeft(3) + "/" + stageCoinNum;
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
        
        SceneManager.LoadScene("Result");
       
    }

    void StopOff()
    {
        // ポイント
        // Ballの動きを司るスクリプトをオンにする。
        ball.enabled = true;
    }

    void Update()
    {
        coinNumText.text = coinCount.ToString();
    }

}
