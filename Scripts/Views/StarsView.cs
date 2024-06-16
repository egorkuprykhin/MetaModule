using System.Collections.Generic;
using Animation;
using UnityEngine;

namespace Infrastructure.Views
{
    public class StarsView : MonoBehaviour
    {
        [SerializeField] public List<AnimatedShowScale> Stars;

        public void ShowAnimation()
        {
            Stars.ForEach(star => star.Show());
        }
    }
}