using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour
{
    public Vector3 spawnValues;
    public GameObject go1, go2, go3, go4;
    public float spawnWait;
    private GameObject[] hazards = new GameObject[4];

	// Use this for initialization
	void Start () {
        hazards[0] = go1;
        hazards[1] = go2;
        hazards[2] = go3;
        hazards[3] = go4;

        StartCoroutine(SpawnWaves());
	}
	
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(spawnWait);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(1.2f, 3.4f), spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazards[CreateNumber()], spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
                       
        }
    }

    int CreateNumber()
    {
        int escolha = Random.Range(0,4);
        Debug.Log(escolha);
        return escolha;

    }

	// Update is called once per frame
	void Update () {
	}
}
