using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.SceneManagement;

public class MoveTest
{
    GameObject obg = Resources.Load<GameObject>("Prefab/Plaer");
    GameObject player;
    Controller controllerPlaer;
    [SetUp]
    public void Setup()
    {
        Vector3 playerPos = Vector3.zero;
        Quaternion playerDir = Quaternion.identity;
        player = GameObject.Instantiate(obg, playerPos, playerDir);
        controllerPlaer = player.GetComponent<Controller>();
        controllerPlaer.Init();
    }
    [TearDown]
    public void Teardown()
    {
        Object.Destroy(player.gameObject);
    }
    [UnityTest]
    public IEnumerator MoveLeft()
    { 

        Plaer plaerMove = controllerPlaer.plaer;

        float posihonBifoMoveLeft = controllerPlaer.transform.position.x;
        plaerMove.MoveLeftPlaer();
        yield return new WaitForSecondsRealtime(0.1f);

        Assert.Less(controllerPlaer.transform.position.x, posihonBifoMoveLeft);

    }
    [UnityTest]
    public IEnumerator MoveRight()
    {

        Plaer plaerMove = controllerPlaer.plaer;

        float posihonBifoMoveRight = controllerPlaer.transform.position.x;
        plaerMove.MoveRightPlaer();
        yield return new WaitForSecondsRealtime(0.1f);

        Assert.Greater(controllerPlaer.transform.position.x, posihonBifoMoveRight);

    }
}
