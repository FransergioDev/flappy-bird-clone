using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float time = 5f;
    [SerializeField] int levelHard = 150;
    [SerializeField] GameObject pipePrefab;
    [SerializeField] float minY = -2f, maxY = 2f;
    private bool waitingTime = false;
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating(nameof(Spawn), time, time);
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitingTime) {
            StartCoroutine("Spawn");
        }
    }

    public void updateDifficulty() {
        if (time >= 2.5f && levelHard > 100) {
            time = time - 0.25f;
        } else if (time >= 1.5f && levelHard <= 80){
            time = time - 0.25f;
        } else if (time >= 1f && levelHard <= 10) {
            time = 0.5f;
        }
        levelHard = levelHard - 5;
        Debug.Log("updateDifficulty: " + time);
    }

    IEnumerator Spawn() {
        waitingTime = true;
        GameObject newPipes = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        newPipes.transform.position += new Vector3(0f, Random.Range(minY, maxY), -1f);
        yield return new WaitForSeconds(time);
        waitingTime = false;
    }
}
