using UnityEngine;
using System;

namespace EnumFlagsTest {
    // A Flags enum
    [Flags]
    public enum AnimalType {
        None = 0,
        Cat = 1,
        Cow = 2,
        Dog = 4,
        Fish = 8,
        Racoon = 16
    }

    public class EnumFlagsExample : MonoBehaviour {
        // Use attribute EnumFlags to enable EnumEditor
        [EnumFlags]
        public AnimalType Animal;

        void Start() {
            // A helper extension is provided to check for flags
            if (Animal.HasFlag(AnimalType.Cat)) {
                Debug.Log("Cat flag is set");
            }

            if (Animal.HasFlag(AnimalType.Cat | AnimalType.Fish)) {
                Debug.Log("Cat & Fish flags are set");
            }
        }
    }
}
