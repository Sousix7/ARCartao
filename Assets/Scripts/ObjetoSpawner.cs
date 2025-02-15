using UnityEngine;

public class ObjetoSpawner : MonoBehaviour
{
    public GameObject objetoPrefab; // Prefab do meteoro que vai cair
    public Transform alvo; // Refer�ncia � aranha (alvo)

    void Start()
    {
        // Iniciar o spawn dos meteoros a cada 3 segundos
        InvokeRepeating("SpawnObjeto", 2f, 3f);
    }

    void SpawnObjeto()
    {
        if (alvo != null)
        {
            // Gerar uma posi��o aleat�ria ACIMA da aranha
            Vector3 spawnPosition = new Vector3(
                alvo.position.x + Random.Range(-0.5f, 0.5f), // Pequena varia��o na horizontal
                alvo.position.y + 2.5f,  // Altura acima da aranha
                alvo.position.z + Random.Range(-0.5f, 0.5f)  // Pequena varia��o na profundidade
            );

            // Instanciar o meteoro na posi��o calculada
            GameObject obj = Instantiate(objetoPrefab, spawnPosition, Quaternion.identity);

            // Garantir que o meteoro tem f�sica ativa
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = obj.AddComponent<Rigidbody>(); // Adiciona Rigidbody se n�o existir
            }
            rb.useGravity = true;
            rb.isKinematic = false;

            Debug.Log("Meteoro gerado na posi��o: " + spawnPosition);

            // Garantir que o objeto desaparece ap�s 5 segundos para evitar sobrecarga
            Destroy(obj, 5f);
        }
        else
        {
            Debug.LogWarning("O alvo (aranha) n�o foi definido no Spawner!");
        }
    }
}
