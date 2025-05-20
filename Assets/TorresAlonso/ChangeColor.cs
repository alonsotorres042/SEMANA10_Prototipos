using System.Collections;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;

    bool canChange = true;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _propBlock = new MaterialPropertyBlock();
    }
    private void Start()
    {
        StartCoroutine(StopInColorCoroutine());
    }
    private Color GetRandomColor()
    {
        return new Color(
            r: Random.Range(0f, 1f),
            g: Random.Range(0f, 1f),
            b: Random.Range(0f, 1f));
    }
    private void Update()
    {
        if(canChange)
        {
            _renderer.GetPropertyBlock(_propBlock);
            _propBlock.SetColor(name: "_BaseColor", value: GetRandomColor());
            _renderer.SetPropertyBlock(_propBlock);
        }
    }
    public IEnumerator StopInColorCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            canChange = false;
            _renderer.GetPropertyBlock(_propBlock);
            _propBlock.SetColor(name: "_BaseColor", Color.red);
            _renderer.SetPropertyBlock(_propBlock);

            yield return new WaitForSeconds(1);

            canChange = true;
        }
    }
}