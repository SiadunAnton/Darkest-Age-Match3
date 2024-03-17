using UnityEngine;

public abstract class TileRecreator : MonoBehaviour
{
    protected new SpriteRenderer renderer;

    public abstract void Recreate(float delay);
    public abstract void Recreate();
    public abstract void Show();
    public abstract void Hide();
}
