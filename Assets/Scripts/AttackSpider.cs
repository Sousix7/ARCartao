using UnityEngine;

public class AttackSpider : MonoBehaviour
{
    public Animator animation;

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

}
