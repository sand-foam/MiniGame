using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class CGBoyController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShowWaveEffect()
        {

        }

        IEnumerator WaitToTransition()
        {
            yield return new WaitForSeconds(3);
            GameController.Instance.TransitionToNextLevel();
        }
    }
}