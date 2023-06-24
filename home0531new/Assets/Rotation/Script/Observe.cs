using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observe : MonoBehaviour
{

    public GameObject target;

    WaitForSeconds wait = new WaitForSeconds(1);

    public void EarthObservation()
    {
        StartCoroutine(LookCoroutine()); //100번 호출 됐을때,
    }

    public IEnumerator LookCoroutine()
    {
        transform.LookAt(target.transform);

        yield return wait;

        transform.rotation = Quaternion.Euler(15, 90, 0);
    }

}
