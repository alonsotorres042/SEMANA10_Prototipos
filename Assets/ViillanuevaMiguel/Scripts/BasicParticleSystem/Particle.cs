using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private float speed;
    private void SetSprite(Sprite newSprite)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
