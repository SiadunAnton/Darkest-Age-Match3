using System.Collections;
using UnityEngine;

public class TileTransparentRecreator : TileRecreator
{
    public bool isMatching = false;
    [SerializeField] private float _delay = 0.1f;
    [SerializeField] private ParticleSystem _particle;

    private TileSpriteRandomizer _spriteRandomizer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        _spriteRandomizer = GetComponent<TileSpriteRandomizer>();
    }

    private void Start()
    {
        Hide();
    }

    public float ParticleSystemDuration()
    {
        if (_particle != null)
            return _particle.main.duration;
        else
            return 0f;
    }

    public override void Recreate(float delay)
    {
        StartCoroutine(StartRecreate(delay));
    }

    IEnumerator StartRecreate(float delay)
    {
        isMatching = true;
        yield return new WaitForSeconds(delay);
        _spriteRandomizer.SetRandomSprite();
        Show();
    }

    public override void Recreate()
    {
        StartCoroutine(StartRecreate());
    }

    IEnumerator StartRecreate()
    {
        isMatching = true;
        if (_particle != null)
        {
            _particle.Play();
            yield return new WaitForEndOfFrame();
        }
        _spriteRandomizer.SetRandomSprite();
        Show();
    }

    public override void Show()
    {
        StartCoroutine(ShowProcess());
    }

    IEnumerator ShowProcess()
    {
        for (int i = 0; i < 11; i ++)
        {
            SetTransparency((float)i/10);
            yield return new WaitForSeconds(_delay);
        }
        MatchProcessor.Instance.AddController(gameObject.GetComponent<MatchController>());
        isMatching = false;
    }

    public override void Hide()
    {
        SetTransparency(0f);
    }

    private void SetTransparency(float value)
    {
        if (value < 0f || value > 255f)
            return;
        var tempColor = renderer.color;
        tempColor.a = value;
        renderer.color = tempColor;
    }
}
