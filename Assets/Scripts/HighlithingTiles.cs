using UnityEngine;

public class HighlithingTiles : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private Material _defaultMaterial;

    [SerializeField] 
    private Material _overlayMaterial;
    
    private GameObject _previousTile;
    
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, 50, _layerMask))
        {
            if (hitInfo.collider.gameObject != _previousTile)
            {
                ResetPreviousTileColor();
                hitInfo.collider.gameObject.GetComponent<Renderer>().material = _overlayMaterial;
                _previousTile = hitInfo.collider.gameObject;
            }
        }
        else
        {
            ResetPreviousTileColor();
        }
    }

    private void ResetPreviousTileColor()
    {
        if (_previousTile != null)
        {
            _previousTile.GetComponent<Renderer>().material = _defaultMaterial;
            _previousTile = null;
        }
    }
}
