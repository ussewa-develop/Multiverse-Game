using UnityEngine;

public class AnimatedMenuObj : MonoBehaviour
{
    private void OnMouseEnter()
    {
        GetComponent<Animator>().SetBool("Open", true);
        GetComponent<Animator>().SetBool("Close", false);
    }

    private void OnMouseExit()
    {
        GetComponent<Animator>().SetBool("Open", false);
        GetComponent<Animator>().SetBool("Close", true);
    }

}
