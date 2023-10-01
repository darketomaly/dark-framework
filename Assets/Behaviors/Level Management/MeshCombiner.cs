using UnityEditor;
using UnityEngine;

namespace DarkFramework
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class MeshCombiner : MonoBehaviour 
    {
        #if UNITY_EDITOR

        [ContextMenu("Combine meshes")]
        public void CombineMeshes() 
        {
            Quaternion oldRot = transform.rotation;
            Vector3 oldPos = transform.position;

            transform.rotation = Quaternion.identity;
            transform.position = Vector3.zero;

            MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

            Debug.LogError($"<color=olive>Combining {filters.Length} meshes as {name}</color>");

            Mesh finalMesh = new Mesh();

            CombineInstance[] combiners = new CombineInstance[filters.Length];

            for (int i = 0; i < filters.Length; i++) {

                if (filters[i].transform == transform)
                    continue;

                combiners[i].subMeshIndex = 0;
                combiners[i].mesh = filters[i].sharedMesh;
                combiners[i].transform = filters[i].transform.localToWorldMatrix;
            }

            finalMesh.CombineMeshes(combiners);
            GetComponent<MeshFilter>().sharedMesh = finalMesh;

            transform.rotation = oldRot;
            transform.position = oldPos;

            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(false);

            AssetDatabase.CreateAsset(finalMesh, $"Assets/{name}-{GUID.Generate()}.mesh");
            AssetDatabase.SaveAssets();
        }

        #endif
    }
}