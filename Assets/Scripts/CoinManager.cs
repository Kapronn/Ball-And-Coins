using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private List<Coin> coinList = new List<Coin>();

    private void Start()
    {
        CoinSpawn();
    }

    private void CoinSpawn()
    {
        for (int i = 0; i < 50; i++)
        {
            Vector3 position = new Vector3(Random.Range(-26f, 26f), 0.7f, Random.Range(-28f, 28f));
            GameObject newCoin = Instantiate(coinPrefab, position, Quaternion.identity);
            coinList.Add(newCoin.GetComponent<Coin>());
        }
    }

    public void CollectCoin(Coin coin)
    {
        coinList.Remove(coin);
        Destroy(coin.gameObject);
    }

    public Coin GetClosestCoin(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closestCoin = null;
        for (int i = 0; i < coinList.Count; i++)
        {
            float distance = Vector3.Distance(point, coinList[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestCoin = coinList[i];
            }
        }

        return closestCoin;
    }
}