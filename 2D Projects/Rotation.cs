using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSaw : MonoBehaviour
{
    [SerializeField] private float OtackyZaMinutu = 2.5f;

    private void Update()
    {
        transform.Rotate(0, 0, 360 *  OtackyZaMinutu * Time.deltaTime);
    }
}
