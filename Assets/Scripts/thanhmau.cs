using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thanhmau : MonoBehaviour
{
    public Image thanh_mau;
    public AudioClip gameover;
    public void capnhatthanhmau(float mauhientai, float mautoida)
    {
        thanh_mau.fillAmount = mauhientai / mautoida;
    }

}
