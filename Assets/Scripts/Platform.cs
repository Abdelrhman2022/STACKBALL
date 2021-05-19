using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> tileMeshRenderers = new List<MeshRenderer>();
    [SerializeField] private List<Rigidbody> tileRigidbodies = new List<Rigidbody>();

    public void Initialize(List<int> damageTileIndecies, Material normalMat, Material damageMat)
    {
        for(int i = 0; i < tileMeshRenderers.Count; i++)
        {
            //if this is a damage tile.
            if(damageTileIndecies.Contains(i))
            {
                tileMeshRenderers[i].material = damageMat;
                tileMeshRenderers[i].tag = "Damage Tile";
            }
            //if this is a normal tile
            else
            {
                tileMeshRenderers[i].material = normalMat;
                tileMeshRenderers[i].tag = "Normal Tile";
            }
        }
    }

    public void DestroyPlatform()
    {
        for(int i = 0; i < tileRigidbodies.Count; i++)
        {
            tileRigidbodies[i].isKinematic = false;
            tileRigidbodies[i].AddExplosionForce(1000, transform.position - new Vector3(0, 1, 0), 2);
        }
        Destroy(gameObject, 1);
    }
}
