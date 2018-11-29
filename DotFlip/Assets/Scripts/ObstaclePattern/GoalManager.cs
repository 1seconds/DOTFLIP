using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public int nextStage;
    private void OnTriggerStay(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            switch (obj.GetComponent<PlayerMove>().currentDirect)
            {
                case Direct.DOWN:
                    if (obj.transform.position.y < gameObject.transform.position.y)
                    {
                        string stage = "0";
                        if (System.Convert.ToInt32(nextStage.ToString()) < 10)
                            stage += nextStage.ToString();
                        else
                            stage = nextStage.ToString();

                        SceneManager.LoadScene(stage);
                    }
                    break;
                case Direct.UP:
                    if (obj.transform.position.y > gameObject.transform.position.y)
                    {
                        string stage = "0";
                        if (System.Convert.ToInt32(nextStage.ToString()) < 10)
                            stage += nextStage.ToString();
                        else
                            stage = nextStage.ToString();

                        SceneManager.LoadScene(stage);
                    }
                    break;
                case Direct.RIGHT:
                    if (obj.transform.position.x > gameObject.transform.position.x)
                    {
                        string stage = "0";
                        if (System.Convert.ToInt32(nextStage.ToString()) < 10)
                            stage += nextStage.ToString();
                        else
                            stage = nextStage.ToString();

                        SceneManager.LoadScene(stage);
                    }
                    break;
                case Direct.LEFT:
                    if (obj.transform.position.x < gameObject.transform.position.x)
                    {
                        string stage = "0";
                        if (System.Convert.ToInt32(nextStage.ToString()) < 10)
                            stage += nextStage.ToString();
                        else
                            stage = nextStage.ToString();

                        SceneManager.LoadScene(stage);
                    }
                    break;
            }
        }
    }
}
