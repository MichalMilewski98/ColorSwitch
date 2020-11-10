using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem deathEffect;
    private PlayerController player;
    private Color particleColor;
    
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != gameObject.GetComponent<PlayerController>().currentColor && collision.tag != "ColorChanger")
        {
           Explode();
           //Invoke("Explode", 0.5f);
        }
    }

    public void Explode()
    {
        SetParticlesColor(GetCurrentColor(player.currentColor));
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private void SetParticlesColor(Color currentColor)
    {
        var ps = this.deathEffect.main;
        ps.startColor = currentColor;
    }

    private Color GetCurrentColor(string color)
    {
        switch (color)
        {
            case "Cyan":
                particleColor = player.colorCyan;
                break;
            case "Magenta":
                particleColor = player.colorMagenta;
                break;
            case "Pink":
                particleColor = player.colorPink;
                break;
            case "Yellow":
                particleColor = player.colorYellow;
                break;
        }
        return particleColor;
    }

}
