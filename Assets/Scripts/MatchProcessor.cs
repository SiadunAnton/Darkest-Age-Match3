using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchProcessor : MonoBehaviour
{
    public static MatchProcessor Instance;

    [SerializeField] private float _delay = 2f;
    private Queue<MatchController> _queue = new Queue<MatchController>();

    private void Awake()
    {
        Instance = GetComponent<MatchProcessor>();
    }

    private void Start()
    {
        StartCoroutine(CheckQueueToHaveAController());
        
    }

    public void AddController(MatchController matchController)
    {
        _queue.Enqueue(matchController);
    }

    public bool IsQueueEmpty()
    {
        return _queue.Count == 0;
    }

    IEnumerator CheckQueueToHaveAController()
    {
        for(; ; )
        {
            yield return new WaitWhile( () => _queue.Count == 0);

            var nextController = _queue.Dequeue();

            if (IsBlockAppropriate(nextController))
            {
                nextController.Match();
                yield return new WaitForSeconds(_delay);
            }
        }
    }

    private bool IsBlockAppropriate(MatchController controller)
    {
        return MatchAnalizer.IsMatch(controller.GetMerged());
    }

}
