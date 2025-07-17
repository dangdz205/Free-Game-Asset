using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] BGs;

    
    private void OnDrawGizmosSelected()
    {
        BGs = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].sortingLayerName = "BG";
            BGs[i].sortingOrder = i;

        }
    }
}
