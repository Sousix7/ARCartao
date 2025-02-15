using UnityEngine;

public class ObjetoSpawner : MonoBehaviour
{
    public GameObject objetoPrefab; // Prefab do meteoro que vai cair
    public Transform alvo; // Referência à aranha (alvo)

    void Start()
    {
        // Iniciar o spawn dos meteoros a cada 3 segundos
        InvokeRepeating("SpawnObjeto", 2f, 3f);
    }

    void SpawnObjeto()
    {
        if (alvo != null)
        {
            // Gerar uma posição aleatória ACIMA da aranha
            Vector3 spawnPosition = new Vector3(
                alvo.position.x + Random.Range(-0.5f, 0.5f), // Pequena variação na horizontal
                alvo.position.y + 2.5f,  // Altura acima da aranha
                alvo.position.z + Random.Range(-0.5f, 0.5f)  // Pequena variação na profundidade
            );

            // Instanciar o meteoro na posição calculada
            GameObject obj = Instantiate(objetoPrefab, spawnPosition, Quaternion.identity);

            // Garantir que o meteoro tem física ativa
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = obj.AddComponent<Rigidbody>(); // Adiciona Rigidbody se não existir
            }
            rb.useGravity = true;
            rb.isKinematic = false;

            Debug.Log("Meteoro gerado na posição: " + spawnPosition);

            // Garantir que o objeto desaparece após 5 segundos para evitar sobrecarga
            Destroy(obj, 5f);
        }
        else
        {
            Debug.LogWarning("O alvo (aranha) não foi definido no Spawner!");
        }
    }
}
