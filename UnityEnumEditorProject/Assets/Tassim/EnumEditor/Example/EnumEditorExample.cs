using UnityEngine;
using System;

namespace EnumEditorTest {
    [Flags]
    public enum AnimalType {
        None = 0,        
        Cat = 1,
        Cow = 2,
        Dog = 4,
        Fish = 8,
        Racoon = 16
    }

    public class EnumEditorExample : MonoBehaviour {
        [EnumFlag]
        public AnimalType Animal;

        void Start() {
            if (Animal.HasFlag(AnimalType.Cat)) {
                Debug.Log("Cat flag is set");
            }

            if (Animal.HasFlag(AnimalType.Cat | AnimalType.Fish)) {
                Debug.Log("Cat & Fish flag set");
            }
        }
    }
}
