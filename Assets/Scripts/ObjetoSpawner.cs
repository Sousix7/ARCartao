using UnityEngine;

public class ObjetoSpawner : MonoBehaviour
{
    public GameObject objetoPrefab; // O objeto que vai cair
    public Transform alvo; // A aranha como alvo

    void Start()
    {
        // Começa a gerar objetos a cada 3 segundos
        InvokeRepeating("SpawnObjeto", 2f, 3f);
    }

    void SpawnObjeto()
    {
        if (alvo != null)
        {
            // Posição aleatória no céu acima da aranha
            Vector3 spawnPosition = new Vector3(alvo.position.x + Random.Range(-0.5f, 0.5f),
                                    alvo.position.y + 2.5f,
                                    alvo.position.z + Random.Range(-0.5f, 0.5f));



            GameObject obj = Instantiate(objetoPrefab, spawnPosition, Quaternion.identity);
            obj.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
