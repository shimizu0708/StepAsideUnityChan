using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //変数「unitychan」をGameObject型で宣言------------------------------------------------発展課題　追記①/4　　　
    private GameObject unitychan;

    //変数「unitychan_z位置」をint型で宣言_初期値40-------------------------------------------発展課題　追記②/4
    int unitychan_位置 = 40;

    // Start is called before the first frame update
    void Start()
    {

        //変数「Unityちゃん」にunitychanオブジェクトを代入--------------------------------------発展課題　追記③/4
        this.unitychan = GameObject.Find("unitychan");

        ////一定の距離ごとにアイテムを生成
        //for (int i = startPos; i < goalPos; i += 15)
        //{
        //    //どのアイテムを出すのかをランダムに設定
        //    int num = Random.Range(1, 11);
        //    if (num <= 2)
        //    {
        //        //コーンをx軸方向に一直線に生成
        //        for (float j = -1; j <= 1; j += 0.4f)
        //        {
        //            GameObject cone = Instantiate(conePrefab);
        //            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
        //        }
        //    }
        //    else
        //    {

        //        //レーンごとにアイテムを生成
        //        for (int j = -1; j <= 1; j++)
        //        {
        //            //アイテムの種類を決める
        //            int item = Random.Range(1, 11);
        //            //アイテムを置くZ座標のオフセットをランダムに設定
        //            int offsetZ = Random.Range(-5, 6);
        //            //60%コイン配置:30%車配置:10%何もなし
        //            if (1 <= item && item <= 6)
        //            {
        //                //コインを生成
        //                GameObject coin = Instantiate(coinPrefab);
        //                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
        //            }
        //            else if (7 <= item && item <= 9)
        //            {
        //                //車を生成
        //                GameObject car = Instantiate(carPrefab);
        //                car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
        //            }
        //        }
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //unitychanオブジェクトのｚ値が整数で15増加する度に40ｍ先でアイテム生成処理をする-----------------------------発展課題　追記④/4

        float f = this.unitychan.transform.position.z;//unitychanオブジェクトの現ｚ値の取得
        if ((int)f == unitychan_位置)
        {
            if(unitychan_位置>= startPos-40 && unitychan_位置 <= goalPos - 40)//ｘ値が80～360の範囲でアイテム生成を行う
            {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan_位置+40);
                    }
                }
                else
                {

                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan_位置 + 40 + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan_位置 + 40 + offsetZ);
                        }
                    }
                }
            }


            unitychan_位置+=15;//一定間隔（15）増加
        }
    }

}