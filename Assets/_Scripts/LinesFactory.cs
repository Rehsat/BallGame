using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LinesPool))]
public class LinesFactory : MonoBehaviour
{

    [SerializeField] private float _secondsToDespawn = 15;
    [SerializeField] private float _yCoordinateRandomize = 3;

    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Line _ballPrefab;

    private SessionData _sessionData;

    private List<Line> _lines;
    private LinesPool _linesPool;

    public void Init(SessionData sessionData)
    {
        _sessionData = sessionData;
        _sessionData.PlayerFactory.OnNewBallCreated += DespawnAllLines;
        _linesPool = GetComponent<LinesPool>();
        _lines = new List<Line>();
    }
    public void CreateLine()
    {
        var randomizedY = Random.Range(-_yCoordinateRandomize, _yCoordinateRandomize);
        var spawnPosition = new Vector2(_spawnPosition.position.x, _spawnPosition.position.y + randomizedY);

        var newLine = _linesPool.Spawn(_ballPrefab, spawnPosition, Quaternion.identity);
        _lines.Add(newLine);

        StartCoroutine(DespawningLine(newLine));
    }
    private void DespawnLine(Line line)
    {
        _lines.Remove(line);
        _linesPool.Despawn(line);
    }
    private void DespawnAllLines(PlayerBall ball)
    {
        foreach (var line in _lines.ToList())
        {
            DespawnLine(line);
        }
    }    
    private IEnumerator DespawningLine(Line line)
    {
        yield return new WaitForSeconds(_secondsToDespawn);
        DespawnLine(line);
    }
    private void OnDisable()
    {
        DespawnAllLines(null);
        _sessionData.PlayerFactory.OnNewBallCreated -= DespawnAllLines;
    }
}
