using UnityEngine;
using TMPro;

public class BinaryUpEffect : MonoBehaviour
{
    public TextMeshPro textPrefab;
    public int count = 50;
    public float speed = 2f;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            SpawnDigit();
        }
    }

    void SpawnDigit()
    {
        TextMeshPro tmp = Instantiate(textPrefab, transform);
        tmp.text = Random.value > 0.5f ? "0" : "1";
        tmp.fontSize = 4;
        tmp.color = Color.green;

        Vector3 startPos = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, -2f), 0f);
        tmp.transform.localPosition = startPos;

        StartCoroutine(MoveUp(tmp));
    }

    System.Collections.IEnumerator MoveUp(TextMeshPro tmp)
    {
        while (tmp != null && tmp.transform.localPosition.y < 15f)
        {
            tmp.transform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
        if (tmp != null) Destroy(tmp.gameObject);
        SpawnDigit(); // respawn new one
    }
}