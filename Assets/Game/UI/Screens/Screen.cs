using UnityEngine;

namespace OPG.UI
{
    using Input;

    /// <summary>
    /// Base class for UI screens.
    /// </summary>
    public class Screen : MonoBehaviour
    {
        [SerializeField] protected MainInputContext inputContext;
    }
}