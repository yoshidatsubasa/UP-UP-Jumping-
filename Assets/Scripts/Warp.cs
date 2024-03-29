using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    private GameObject obj;
    public Warp transObj;
    private Vector3 transVec;

    //移動状態を表すフラグ
    public bool moveStatus;

    public AudioSource warpSound; // ワープ時の効果音を再生するための AudioSource

    void Start()
    {
        // ワープ時の効果音がアタッチされたオブジェクトから AudioSource を取得
        warpSound = GetComponent<AudioSource>();
        //移動先(円柱B)の座標を取得する
        transVec = transObj.transform.position;
        //初期では移動可能なためTrue
        moveStatus = true;

    }


    //物体と重なる瞬間呼ばれる
    void OnTriggerEnter(Collider other)
    {
        obj = GameObject.Find(other.name);
        //自分が移動可能なとき移動する。
        if (moveStatus)
        {
            //移動先は直後移動できないようにする
            transObj.moveStatus = false;
            obj.transform.position = transVec;

            // ワープ時の効果音を再生する
            if (warpSound != null)
            {
                warpSound.Play();
            }
        }
    }
    //物体と離れた直後呼ばれる
    void OnTriggerExit(Collider other)
    {
        //移動可能にする。
        moveStatus = true;
    }

    private void Update()
    {

    }
}