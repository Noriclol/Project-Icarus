using UnityEngine;
using UnityEngine.SceneManagement;


    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        //protected DestructionMethod Type = DestructionMethod.DestroyThis;

        /// <summary>
        /// The instance.
        /// </summary>
        private static T instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                instance = FindObjectOfType<T>();

                if (instance != null)
                {
                    return instance;
                }

#if UNITY_EDITOR
                if (UnityEditor.EditorApplication.isPlaying && !UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                    return null;
#endif

                var obj = new GameObject
                {
                    name = typeof(T).Name
                };

                instance = obj.AddComponent<T>();

                Debug.Log($"[Singleton] Adding {typeof(T).Name} in scene {SceneManager.GetActiveScene().name}");

                return instance;
            }
        }

        protected void InitializeSelfAsSingleton()
        {
            if (instance != null)
            {
                return;
            }

            instance = this.gameObject.GetComponent<T>();
        }

        /// <summary>
        /// Use this for initialization.
        /// </summary>
        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                //var obj = Type == DestructionMethod.DestroyThis
                //    ? this.gameObject
                //    : instance.gameObject;
                //
                //Debug.Log($"[Singleton] Destroying {obj.name.Bold()} in scene {SceneManager.GetActiveScene().name.Bold()}");
                //
                //if (Type == DestructionMethod.DestroyThat)
                //{
                //    instance = obj.GetOrAddComponent<T>();
                //}

                Destroy(this.gameObject);
            }
        }
    }
