using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //conePrefab������
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    //�ϐ��uunitychan�v��GameObject�^�Ő錾------------------------------------------------���W�ۑ�@�ǋL�@/4�@�@�@
    private GameObject unitychan;

    //�ϐ��uunitychan_z�ʒu�v��int�^�Ő錾_�����l40-------------------------------------------���W�ۑ�@�ǋL�A/4
    int unitychan_�ʒu = 40;

    // Start is called before the first frame update
    void Start()
    {

        //�ϐ��uUnity�����v��unitychan�I�u�W�F�N�g����--------------------------------------���W�ۑ�@�ǋL�B/4
        this.unitychan = GameObject.Find("unitychan");

        ////���̋������ƂɃA�C�e���𐶐�
        //for (int i = startPos; i < goalPos; i += 15)
        //{
        //    //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
        //    int num = Random.Range(1, 11);
        //    if (num <= 2)
        //    {
        //        //�R�[����x�������Ɉ꒼���ɐ���
        //        for (float j = -1; j <= 1; j += 0.4f)
        //        {
        //            GameObject cone = Instantiate(conePrefab);
        //            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
        //        }
        //    }
        //    else
        //    {

        //        //���[�����ƂɃA�C�e���𐶐�
        //        for (int j = -1; j <= 1; j++)
        //        {
        //            //�A�C�e���̎�ނ����߂�
        //            int item = Random.Range(1, 11);
        //            //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
        //            int offsetZ = Random.Range(-5, 6);
        //            //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
        //            if (1 <= item && item <= 6)
        //            {
        //                //�R�C���𐶐�
        //                GameObject coin = Instantiate(coinPrefab);
        //                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
        //            }
        //            else if (7 <= item && item <= 9)
        //            {
        //                //�Ԃ𐶐�
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
        //unitychan�I�u�W�F�N�g�̂��l��������15��������x��40����ŃA�C�e����������������-----------------------------���W�ۑ�@�ǋL�C/4

        float f = this.unitychan.transform.position.z;//unitychan�I�u�W�F�N�g�̌����l�̎擾
        if ((int)f == unitychan_�ʒu)
        {
            if(unitychan_�ʒu>= startPos-40 && unitychan_�ʒu <= goalPos - 40)//���l��80�`360�͈̔͂ŃA�C�e���������s��
            {
                //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //�R�[����x�������Ɉ꒼���ɐ���
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan_�ʒu+40);
                    }
                }
                else
                {

                    //���[�����ƂɃA�C�e���𐶐�
                    for (int j = -1; j <= 1; j++)
                    {
                        //�A�C�e���̎�ނ����߂�
                        int item = Random.Range(1, 11);
                        //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                        int offsetZ = Random.Range(-5, 6);
                        //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                        if (1 <= item && item <= 6)
                        {
                            //�R�C���𐶐�
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan_�ʒu + 40 + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //�Ԃ𐶐�
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan_�ʒu + 40 + offsetZ);
                        }
                    }
                }
            }


            unitychan_�ʒu+=15;//���Ԋu�i15�j����
        }
    }

}