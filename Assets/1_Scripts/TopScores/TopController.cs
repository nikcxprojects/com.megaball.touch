using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopController : MonoBehaviour
{
    [SerializeField] private TopScores _scores;
    [SerializeField] private Transform _content;

    [SerializeField] private GameObject _viewPrefab;
    
    private void Start()
    {
        foreach (Transform obj in _content) Destroy(obj.gameObject);
        
        GenerateViews();
        Invoke("UpdateView", 0.1f);
    }

    private void UpdateView()
    {
        GetComponent<VerticalLayoutGroup>().spacing += 0.1f;
    }

    private void GenerateViews()
    {
        for (var index = 0; index < _scores.Scores.Count; index++)
        {
            var score = _scores.Scores[index];
            var scoreView = Instantiate(_viewPrefab, _content);
            scoreView.GetComponent<Text>().text = $"<color='#FDBA01'>{(index + 1)}.</color> {score}";
        }
    }
}
