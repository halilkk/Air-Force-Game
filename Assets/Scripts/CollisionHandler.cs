using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] AudioSource destroySFX;
    [SerializeField] GameObject FailScreen;
    void OnTriggerEnter(Collider other)
    {
       Destroy(gameObject);
        Instantiate(destroyVFX, transform.position, destroyVFX.transform.rotation);
        AudioSource.PlayClipAtPoint(destroySFX.clip, transform.position);
        openFailScreen();
    }

    void openFailScreen()
    {
        FailScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }
}
