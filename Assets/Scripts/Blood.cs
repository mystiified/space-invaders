using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    SpriteRenderer sr;
    public Material mat;
    string name;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(DisappearingAct());
    }

    IEnumerator DisappearingAct()
    {
        Color c = new Color(255, 255, 255, (255 / 1.1f));
        yield return new WaitForSeconds(1);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.25f);
            c.a = 255 * (0.9f - 0.1f * i);
            sr.color = c;
        }
    }
}
