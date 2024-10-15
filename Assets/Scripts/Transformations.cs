using System;
using UnityEngine;

namespace Mathematics.Week5
{
    public class Transformations : MonoBehaviour
    {
        [Header("Start values")]
        [SerializeField] private Vector3 startPosition = Vector3.zero;
        //Inicializa una variable tipo Vector 3 en 0,0,0
        [Header("Start values")]
        [SerializeField] private Vector3 currentPosition = Vector3.zero;
        //Inicializa una variable tipo Vector 3 en 0,0,0
        [Header("Transformations")]
        [SerializeField] private Vector3 translationValue = Vector3.zero;
        //Inicializa una variable tipo Vector 3 en 0,0,0
        [SerializeField] private Vector3 rotationValue = Vector3.zero;
        //Inicializa una variable tipo Vector 3 en 0,0,0
        [SerializeField] private Vector3 scaleValue = Vector3.one;
        //Inicializa una variable tipo Vector 3 en 0,0,0

        public static event Action<Vector3> Translate;
        //Crea un evento para transladar
        public static event Action<Vector3> Rotate;
        //Crea un evento para rotar
        public static event Action<Vector3> Scale;
        //Crea un evento para escalar

        public static event Action<Vector3, Vector3> UpdatePosition;
        //Crea un evento para actualizar la posicion de un vector 3

        private void Update()
        {
            currentPosition = startPosition + translationValue;
            //como se calcula la posicion actual 
            UpdatePosition?.Invoke(currentPosition, translationValue);
            //llama al evento para actualizar posicion y le pasa los parametros
            Scale?.Invoke(scaleValue);
            //llama al evento para escalar
            Rotate?.Invoke(rotationValue);
            //llama al evento para rotar
        }

        [ContextMenu("Update Translate")]
        private void UpdateTranslate()
        {
            Translate?.Invoke(translationValue);
            //llama al evento para rotar y le pasa el valor de la rotacion realizada
        }
    }
}