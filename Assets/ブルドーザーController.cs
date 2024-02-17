using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ブルドーザーController : MonoBehaviour
{
    //変数「Unityちゃん」をGameObject型で宣言
    private GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        //変数「Unityちゃん」にunitychanオブジェクトを代入
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //削除用オブジェクト（ブルドーザー）をUnityちゃんの後方から追随
        transform.position = new Vector3(0, 2.5f, this.unitychan.transform.position.z - 5);
    }
    void OnTriggerEnter(Collider other)//通り過ぎたオブジェクトを削除する関数
    {
            //ブルドーザーに接触したオブジェクトをDestroy
            Destroy(other.gameObject);
    }
}
