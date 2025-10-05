using UnityEngine;

public class CactusProximity : MonoBehaviour
{
    public Animator animator;
    public string cactusTag = "Cactus";
    public float triggerDistance = 0.3f;

    private bool wasClose = false;

    void Update()
    {
        GameObject[] allCacti = GameObject.FindGameObjectsWithTag(cactusTag);
        bool foundClose = false;

        foreach (GameObject other in allCacti)
        {
            if (other == this.gameObject) continue;

            float dist = Vector3.Distance(transform.position, other.transform.position);
            if (dist < triggerDistance)
            {
                foundClose = true;
                break;
            }
        }

        if (foundClose && !wasClose)
        {
            animator.ResetTrigger("Attack"); 
            animator.SetTrigger("Attack");
        }

        wasClose = foundClose;
    }
}