using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursivitySystem : MonoBehaviour
{
    public float ExternalRange = 1;
    public float ExternalInitialScaleX = 7;
    public float ExternalInitialScaleY = 6;

    public float MediumRange = 1;
    public float MediumInitialScaleX = 6;
    public float MediumInitialScaleY = 5;

    public float InternalRange = 1;
    public float InternalInitialScaleX = 5;
    public float InternalInitialScaleY = 4;

    public GameObject ExternalPrefab;
    public GameObject MediumPrefab;
    public GameObject InternalPrefab;

    public Transform externalFather;
    public Transform mediumFather;
    public Transform internalFather;

    public bool explosion;

    [Range(0.01f, 0.02f)] // slider
    public float externalFadeSpeed = 0.014f;

    [Range(0.01f, 0.02f)] // slider
    public float mediumFadeSpeed = 0.015f;

    [Range(0.01f, 0.02f)] // slider
    public float internalFadeSpeed = 0.017f;


    void ExternalGenerator(Vector3 pos, float X, float Y)
    {
        Vector3 pExternal = pos + new Vector3(0, 0, 0.4f);

        if (Y < ExternalRange)
        {
            GameObject a = (GameObject)GameObject.Instantiate(ExternalPrefab, pExternal, Quaternion.identity);
            a.transform.SetParent(externalFather);
            a.transform.localScale = new Vector3(X, Y, 1);
        }
        else
        {
            GameObject a = (GameObject)GameObject.Instantiate(ExternalPrefab, pExternal, Quaternion.identity);
            a.transform.SetParent(externalFather);
            a.transform.localScale = new Vector3(X, Y, 1);

            float x = UnityEngine.Random.Range(-X / 2, X / 2) * ExternalRange;
            float y = UnityEngine.Random.Range(-Y / 2, Y / 2) * ExternalRange;
            Vector3 p1 = pExternal + new Vector3(x, y, 0);
            p1 = new Vector3(p1.x, p1.y, 0);
            ExternalGenerator(p1, X / 2, Y / 2);
        }
    }

    void MediumGenerator(Vector3 pos, float X, float Y)
    {
        Vector3 pMedium = pos + new Vector3(0, 0, 0.2f);

        if (Y < MediumRange)
        {
            GameObject a = (GameObject)GameObject.Instantiate(MediumPrefab, pMedium, Quaternion.identity);
            a.transform.SetParent(mediumFather);
            a.transform.localScale = new Vector3(X, Y, 1);
        }
        else
        {
            GameObject a = (GameObject)GameObject.Instantiate(MediumPrefab, pMedium, Quaternion.identity);
            a.transform.SetParent(mediumFather);
            a.transform.localScale = new Vector3(X, Y, 1);

            float x = UnityEngine.Random.Range(-X / 2, X / 2) * MediumRange;
            float y = UnityEngine.Random.Range(-Y / 2, Y / 2) * MediumRange;
            Vector3 p1 = pMedium + new Vector3(x, y, 0);
            p1 = new Vector3(p1.x, p1.y, 0);
            MediumGenerator(p1, X / 2, Y / 2);

            x = UnityEngine.Random.Range(-X / 2, X / 2) * MediumRange;
            y = UnityEngine.Random.Range(-Y / 2, Y / 2) * MediumRange;
            Vector3 p2 = pMedium + new Vector3(x, y, 0);
            p2 = new Vector3(p2.x, p2.y, 0);
            MediumGenerator(p2, X / 2, Y / 2);

            x = UnityEngine.Random.Range(-X / 2, X / 2) * MediumRange;
            y = UnityEngine.Random.Range(-Y / 2, Y / 2) * MediumRange;
            Vector3 p3 = pMedium + new Vector3(x, y, 0);
            p3 = new Vector3(p3.x, p3.y, 0);
            MediumGenerator(p3, X / 2, Y / 2);
        }
    }

    void InternalGenerator(Vector3 pos, float X, float Y)
    {
        Vector3 pInternal = pos + new Vector3(0, 0, 0);

        if (Y < InternalRange)
        {
            GameObject a = (GameObject)GameObject.Instantiate(InternalPrefab, pInternal, Quaternion.identity);
            a.transform.SetParent(internalFather);
            a.transform.localScale = new Vector3(X, Y, 1);
        }
        else
        {
            GameObject a = (GameObject)GameObject.Instantiate(InternalPrefab, pInternal, Quaternion.identity);
            a.transform.SetParent(internalFather);
            a.transform.localScale = new Vector3(X, Y, 1);

            float x = UnityEngine.Random.Range(-X / 2, X / 2) * InternalRange;
            float y = UnityEngine.Random.Range(-Y / 2, Y / 2) * InternalRange;
            Vector3 p1 = pInternal + new Vector3(x, y, 0);
            p1 = new Vector3(p1.x, p1.y, 0);
            InternalGenerator(p1, X / 2, Y / 2);

            x = UnityEngine.Random.Range(-X / 2, X / 2) * InternalRange;
            y = UnityEngine.Random.Range(-Y / 2, Y / 2) * InternalRange;
            Vector3 p2 = pInternal + new Vector3(x, y, 0);
            p2 = new Vector3(p2.x, p2.y, 0);
            InternalGenerator(p2, X / 2, Y / 2);

            x = UnityEngine.Random.Range(-X / 2, X / 2) * InternalRange;
            y = UnityEngine.Random.Range(-Y / 2, Y / 2) * InternalRange;
            Vector3 p3 = pInternal + new Vector3(x, y, 0);
            p3 = new Vector3(p3.x, p3.y, 0);
            InternalGenerator(p3, X / 2, Y / 2);
        }
    }

    void Update()
    {
        if (explosion)
        {
            ExternalGenerator(transform.position, ExternalInitialScaleX, ExternalInitialScaleY);
            MediumGenerator(transform.position, MediumInitialScaleX, MediumInitialScaleY);
            InternalGenerator(transform.position, InternalInitialScaleX, InternalInitialScaleY);
        }

        explosion = false;

        StartCoroutine(ExternalFade());
        StartCoroutine(MediumFade());
        StartCoroutine(InternalFade());
    }

    IEnumerator ExternalFade()
    {
        for (int i = 0; i < externalFather.childCount; i++)
        {
            MeshRenderer childMesh = externalFather.GetChild(i).GetComponent<MeshRenderer>();

            childMesh.material.color -= new Color(0, 0, 0, externalFadeSpeed);

            if (childMesh.material.color.a <= 0)
            {
                Destroy(externalFather.GetChild(i).gameObject);
            }
        }
        yield return null;
    }

    IEnumerator MediumFade()
    {
        for (int i = 0; i < mediumFather.childCount; i++)
        {
            MeshRenderer childMesh = mediumFather.GetChild(i).GetComponent<MeshRenderer>();

            childMesh.material.color -= new Color(0, 0, 0, mediumFadeSpeed);

            if (childMesh.material.color.a <= 0)
            {
                Destroy(mediumFather.GetChild(i).gameObject);
            }
        }
        yield return null;
    }

    IEnumerator InternalFade()
    {
        for (int i = 0; i < internalFather.childCount; i++)
        {
            MeshRenderer childMesh = internalFather.GetChild(i).GetComponent<MeshRenderer>();

            childMesh.material.color -= new Color(0, 0, 0, internalFadeSpeed);

            if (childMesh.material.color.a <= 0)
            {
                Destroy(internalFather.GetChild(i).gameObject);
            }
        }
        yield return null;
    }
}