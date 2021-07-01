using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Interactions {

    [RequireComponent(typeof(Collider2D))]
    public class FadeLight : AInteraction
    {
        public float enterTarget;
        public float exitTarget;
        public float initIntensity;
        public float fadeSpeed;
        public bool singleUse;
        public Light2D light2D;
        private bool isEntered;
        private bool isUsed;

        void Awake() {
            light2D.intensity = initIntensity;
            isEntered = false;
            isUsed = false;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "MainCharacter") {
                isEntered = true;
                isUsed = true;
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "MainCharacter") {
                isEntered = false;
            }
        }

        public override bool Trigger()
        {
            return true;
        }

        public override void Interact()
        {
            if (singleUse && isUsed) return;
            if (isEntered) {
                Fade(enterTarget);
            }
            else {
                Fade(exitTarget);
            }
        }

        private void Fade(float target) {
            light2D.intensity = Mathf.MoveTowards(light2D.intensity, target, fadeSpeed * Time.deltaTime);
        }
    }

}