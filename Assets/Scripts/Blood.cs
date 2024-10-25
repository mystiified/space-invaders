using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public GameObject[] bloodmonster;
    public Transform bholder;

    // Start is called before the first frame update
    void Start()
    {
        bholder = FindObjectOfType<Transform>();
        StartCoroutine(BloodMonster());
    }

    IEnumerator BloodMonster()
    {
        yield return new WaitForSeconds(1);
        float rand = Random.Range(0.0f, 10.0f);
        int randmonster = Random.Range(0, 1);
        if (rand > 8.0f)
        {
            Instantiate(bloodmonster[randmonster], transform.position, Quaternion.identity, bholder);
        }
        Destroy(gameObject);
    }
}
