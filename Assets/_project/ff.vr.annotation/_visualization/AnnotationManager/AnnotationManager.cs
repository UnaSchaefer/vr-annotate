using System.Collections.Generic;
using UnityEngine;
using ff.vr.annotate;
using ff.nodegraph;
//using ff.vr.annotate;

namespace ff.vr.annotate.viz
{
    /* 
        A singleton, that handles loading and adding annotations
        - Can be selected.
        - Can be hovered.
        - We be generated on the fly
        - Is grouped under a Annotations-Group
    */
    public class AnnotationManager : MonoBehaviour
    {
        private List<Annotation> AllAnnotations = new List<Annotation>();
        private List<AnnotationGizmo> AllAnnotationGizmos = new List<AnnotationGizmo>();
        public AnnotationGizmo _annotationGizmoPrefab;

        void Awake()
        {

            _gizmoContainer = new GameObject();
            _gizmoContainer.name = "GizmoContainer";
            _gizmoContainer.transform.SetParent(this.transform, false);
        }

        public void CreateAnnotation(Node context, Vector3 position)
        {
            var newAnnotation = new Annotation()
            {
                Position = position,
                ContextId = context.Id,
                Id = System.Guid.NewGuid(),
            };

            AllAnnotations.Add(newAnnotation);

            var newGizmo = Instantiate(_annotationGizmoPrefab);
            newGizmo.transform.position = position;
            newGizmo.transform.SetParent(_gizmoContainer.transform, false);
        }

        private GameObject _gizmoContainer;
    }
}
