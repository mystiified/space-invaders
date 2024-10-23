using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Blood : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject bloodmonster;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(BloodMonster());
    }

    IEnumerator BloodMonster()
    {
        yield return new WaitForSeconds(1);
        float rand = Random.Range(0.0f, 10.0f);
        if (rand > 8.0f)
        {
            Instantiate(bloodmonster, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
