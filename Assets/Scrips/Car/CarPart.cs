using Scrips.Gride;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scrips
{
    public class CarPart : MonoBehaviour
    {
        [HideInInspector] public GridePlate currentPlate;

        public void GetCurrentPlate()
        {
            Physics.Raycast(new Ray(transform.position, Vector3.down), out RaycastHit raycastHit, 1f);
            currentPlate = raycastHit.collider.GetComponent<GridePlate>();
        }
    }
}
