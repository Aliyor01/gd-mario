using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] running;
    public Sprite[] jumping;
    private Sprite[] current;
    private bool is_running = true;
    public float framerate = 1f / 6f;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        current = running;
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Animate), framerate, framerate);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void state(bool newState)
    {
        if (is_running != newState)
        {
            is_running = newState;
            frame = 0;
            if (!is_running)
            {
                current = jumping;
            }
            else
            {
                current = running;
            }
        }
    }


    private void Animate()
    {
        frame++;
        if (frame >= current.Length) {
            frame = 0;
        }

        if (frame >= 0 && frame < current.Length) {
            spriteRenderer.sprite = current[frame];
        }
        
    }

}
