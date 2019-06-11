using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour
{
    // префаб добавляемого объекта
    public GameObject prefab;
    // коллекция неактивных экземпляров префабов
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    // возвращает экземпляр префаба
    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        // если есть неактивный экземпляр префаба, готовый к возврату, вернет его
        if (inactiveInstances.Count > 0)
        {
            // удалит экземпляр из коллекции неактивных экземпляров
            spawnedGameObject = inactiveInstances.Pop();
        }
        // в противном случае, создаст новый экземпляр
        else
        {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

            // добавьте компонент PooledObject в сборку, чтобы мы знали, что он пришел из этого пула
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        // поместит экземпляр в корень сцены и включит его
        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);

        // возвращает ссылку на экземпляр
        return spawnedGameObject;
    }

    // Возврат экземпляра префаба в пул
    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        // если экземпляр пришел из этого пула, вернет его в пул
        if (pooledObject != null && pooledObject.pool == this)
        {
            // сделайте экземпляр дочерним для него и отключит
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            // добавление экземпляра в коллекцию неактивных
            inactiveInstances.Push(toReturn);
        }
        // в противном случае просто уничтожит его
        else
        {
            Debug.LogWarning(toReturn.name + " был возвращен в pool, из которого он не был порожден! Уничтожаю.");
            Destroy(toReturn);
        }
    }
}

// компонент, который просто идентифицирует пул, из которого вышел GameObject
public class PooledObject : MonoBehaviour
{
    public SimpleObjectPool pool;
}
