using System.Collections.Generic;
using UnityEngine;

public class FrontSearchPattern : ICharacterFinder
{
    private float _viewinRange;
    private Transform _center;

    public FrontSearchPattern(float viewinRange, Transform center)
    {
        _viewinRange = viewinRange;
        _center = center;
    }

    public IEnumerable<Character> Find()
    {
        RaycastHit[] hits = Physics.RaycastAll(new Ray(_center.position, _center.forward), _viewinRange);

        List<Character> findedCharacter = new List<Character>();    

        foreach (RaycastHit hit in hits)
            if(hit.collider.TryGetComponent(out Character character))
                if(character.transform != _center)
                    findedCharacter.Add(character);

        return findedCharacter;
    }
}
