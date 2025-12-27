using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField]  GameObject destroyVFX;
    [SerializeField] int hitpoint = 3;
    [SerializeField] int scoreValue = 10;
    [SerializeField] AudioSource destroySFX;
    [SerializeField] bool isBoss = false;
    [SerializeField] GameObject WinScreen;

    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        hitpoint--;

        if (hitpoint <= 0)
        { 
            Destroy(gameObject);
            Instantiate(destroyVFX,transform.position,destroyVFX.transform.rotation);
            scoreboard.UpdateScore(scoreValue);
            AudioSource.PlayClipAtPoint(destroySFX.clip,transform.position);

            if (isBoss)
            {
                WinScreen.SetActive(true);
            }
        }
    }
}
