using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TestTranslator {
        GameObject go;
        Rigidbody2D rb;
        Translator trans;
        Vector3 oldPos;

        [SetUp]
        public void Setup() {
            go = new GameObject();
            rb = go.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            trans = go.AddComponent<Translator>();
            oldPos = go.transform.position;
        }
        [UnityTest]
        public IEnumerator GivenZeroMovementVectorTheGameObjectStaysInPlace() {
            yield return null; //Wait for Start Event

            trans.Move(Vector2.zero);

            yield return new WaitForSeconds(1f); //Wait for velocity to take place

            Assert.AreEqual(oldPos, go.transform.position);
        }
        [UnityTest]
        public IEnumerator GivenNonZeroMovementVectorTheGameObjectMovesAsExpected() {
            yield return null; //Wait for Start Event

            trans.Move(Vector2.right);

            yield return new WaitForSeconds(1f); //Wait for velocity to take place

            Assert.AreEqual(oldPos.y, go.transform.position.y);
            Assert.IsTrue(Mathf.Approximately(1f, go.transform.position.x), "transform.position.x is not 1f as expected");
        }
        [RequireComponent(typeof(Rigidbody2D))]
        public class Translator : MonoBehaviour {
            Rigidbody2D rb;

            public void Start() {
                rb = GetComponent<Rigidbody2D>();
            }
            public void Move(Vector2 velocity) {
                rb.velocity = velocity;
            }
        }
    }

}
