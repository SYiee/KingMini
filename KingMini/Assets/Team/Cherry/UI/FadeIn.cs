using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    GameObject FadePannel;

    GameObject SplashObj;               //�ǳڿ�����Ʈ
    Image image;                            //�ǳ� �̹���

    private bool checkbool = false;     //���� ���� ���� ����

    void Awake()
    {
        SplashObj = this.gameObject;                         //��ũ��Ʈ ������ ������Ʈ
        image = SplashObj.GetComponent<Image>();    //�ǳڿ�����Ʈ�� �̹��� ����
    }

    void Update()
    {

        StartCoroutine("MainSplash");                       //�ڷ�ƾ    //�ǳ� ���� ����
        if (checkbool)                                            //���� checkbool �� ���̸�
        {
            this.gameObject.SetActive(false);   //�ǳ� �ı�, ����
            Destroy(this.gameObject);
        }
    }

    IEnumerator MainSplash()
    {
        Color color = image.color;                            //color �� �ǳ� �̹��� ����
        for (int i = 100; i >= 0; i--)                            //for�� 100�� �ݺ� 0���� ���� �� ����
        {

            color.a -= Time.deltaTime * 0.005f;               //�̹��� ���� ���� Ÿ�� ��Ÿ �� * 0.01
            image.color = color;                                //�ǳ� �̹��� �÷��� �ٲ� ���İ� ����

            if (image.color.a >= 255)                        //���� �ǳ� �̹��� ���� ���� 0���� ������
            {
              //  this.gameObject.SetActive(false);
                checkbool = true;                              //checkbool �� 
            }
        }
        yield return null;                                        //�ڷ�ƾ ����

    }

}