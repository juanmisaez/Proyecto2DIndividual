using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursivitySystem : MonoBehaviour
{
    public float bigDustRange = 1;
    float bigDustInitialScaleX = 1;
    float bigDustInitialScaleY = 1;

    public float mediumDustRange = 1;
    float mediumDustInitialScaleX = 1;
    float mediumDustInitialScaleY = 1;

    public float littleDustRange = 1;
    float littleDustInitialScaleX = 1;
    float littleDustInitialScaleY = 1;

    public GameObject bigDustPrefab;
    public GameObject mediumDustPrefab;
    public GameObject littleDustPrefab;

    public Transform externalFather;
    public Transform mediumFather;
    public Transform internalFather;

    Vector3 posRock;
    bool breakRock;

    [Range(0.005f, 0.01f)] // slider
    public float externalFadeSpeed = 0.005f;

    [Range(0.005f, 0.01f)] // slider
    public float mediumFadeSpeed = 0.0075f;

    [Range(0.005f, 0.01f)] // slider
    public float internalFadeSpeed = 0.01f;

    void Update()
    {
        BreakRock(breakRock, posRock);
    }

    void BreakRock(bool _breakRock, Vector3 _posRock)
    {
        breakRock = _breakRock;

        _posRock.x += 0.5f;
        _posRock.y += 0.5f;

        posRock = _posRock;

        if (_breakRock)
        {
            Generator(posRock, bigDustInitialScaleX, bigDustInitialScaleY, bigDustRange, bigDustPrefab, externalFather);
            Generator(posRock, mediumDustInitialScaleX, mediumDustInitialScaleY, mediumDustRange, mediumDustPrefab, mediumFather);
            Generator(posRock, littleDustInitialScaleX, littleDustInitialScaleY, littleDustRange, littleDustPrefab, internalFather);
        }

        breakRock = false;

        StartCoroutine(Fade(externalFather, externalFadeSpeed));
        StartCoroutine(Fade(mediumFather, mediumFadeSpeed));
        StartCoroutine(Fade(internalFather, internalFadeSpeed));
    }

    void Generator(Vector3 pos, float X, float Y, float range, GameObject prefab, Transform father)
    {
        if (Y < range)
        {
            GameObject a = Instantiate(prefab, pos, Quaternion.identity);
            a.transform.SetParent(father);
        }
        else
        {
            GameObject a = Instantiate(prefab, pos, Quaternion.identity);
            a.transform.SetParent(father);

            float x = Random.Range(-X / 2, X / 2) * range;
            float y = Random.Range(-Y / 2, Y / 2) * range;
            Vector3 p1 = pos + new Vector3(x, y, 0);
            p1 = new Vector3(p1.x, p1.y, 0);
            Generator(p1, X / 2, Y / 2, range, prefab, father);
        }
    }

    IEnumerator Fade(Transform father, float fadeSpeed)
    {
        for (int i = 0; i < father.childCount; i++)
        {
            MeshRenderer childMesh = father.GetChild(i).GetComponent<MeshRenderer>();

            childMesh.material.color -= new Color(0, 0, 0, fadeSpeed);

            if (childMesh.material.color.a <= 0)
            {
                Destroy(father.GetChild(i).gameObject);
            }
        }
        yield return null;
    }

    void OnEnable()
    {
        GetComponent<BreakBlockSystem>().CrashRock += BreakRock;
    }

    void OnDisable()
    {
        GetComponent<BreakBlockSystem>().CrashRock -= BreakRock;
    }
}