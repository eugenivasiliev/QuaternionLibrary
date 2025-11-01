using System.Collections.Generic;

namespace Geometry {
    public class TransformManager : UnityEngine.MonoBehaviour
    {
        [UnityEngine.SerializeField] private List<Transform> transforms = new List<Transform>();
        void Start()
        {
            foreach (Transform t in transforms) t.Setup();
        }

        void LateUpdate()
        {
            foreach (Transform t in transforms) t.Refresh();
        }
    }
}
