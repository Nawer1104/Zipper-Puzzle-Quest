using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zip : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private GameObject particleVFX;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim()
    {
        StartCoroutine(ExampleCoroutine());
    }

    private IEnumerator ExampleCoroutine()
    {
        anim.SetTrigger("Scale");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        GameObject explosion = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(explosion, .75f);

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].items.Remove(this.gameObject);
        Destroy(gameObject);
    }

}
