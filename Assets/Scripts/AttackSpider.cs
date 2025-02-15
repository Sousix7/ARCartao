using UnityEngine;

public class AttackSpider : MonoBehaviour
{
    public Animator animation;
    private int impactos = 0; // Contador de impactos

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Objeto tocado: " + hit.transform.name);

                if (hit.transform == transform)
                {
                    Debug.Log("Aranha tocada! Acionando animação.");
                    animation.SetTrigger("Attack");
                }
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meteoro"))
        {
            impactos++;
            Debug.Log("A aranha foi atingida! Impactos: " + impactos);

            if (impactos >= 3) // Se for atingida 3 vezes, morre
            {
                Debug.Log("Aranha morreu!");
                animation.SetTrigger("Die");

                // Ativar física e soltar a aranha
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.isKinematic = false; // Agora pode ser afetada pela física
                rb.AddForce(Vector3.down * 5, ForceMode.Impulse); // Faz ela cair

                // Destruir a aranha depois de 3 segundos
                Destroy(gameObject, 3f);
            }
        }
    }
}
