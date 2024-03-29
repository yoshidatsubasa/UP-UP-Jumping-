using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    /// <summary>
    /// 衝突した時
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手にPlayerタグが付いているとき
        if (collision.gameObject.tag == "Player")
        {
            // 0.1秒後に消える
            Destroy(gameObject, 0.1f);
        }
    }
}