using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Background : MonoBehaviour {

    [SerializeField][Range(0.5f, 20f)] float waterSpeed = 3f;
    [SerializeField][Range(0.5f, 20f)] float mountainSpeed = 1f;
    List<Transform> waters = new List<Transform>();
    List<Transform> mountain = new List<Transform>();
    void Start() {
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).name == "Water") {
                for (int j = 0; j < transform.GetChild(i).childCount; j++) {
                    waters.Add(transform.GetChild(i).GetChild(j));
                }
            }
            if (transform.GetChild(i).name == "Mountain") {
                for (int j = 0; j < transform.GetChild(i).childCount; j++) {
                    mountain.Add(transform.GetChild(i).GetChild(j));
                }
            }
        }
    }

    void Update() {
        WaterMove(25.073f);
        MountainMove();
    }

    void WaterMove(float offset) {
        for (int i = 0; i < waters.Count; i++) {
            Vector2 pos = waters[i].position;
            if (pos.x >= 24f) {
                int j = i + 1;
                if (j >= waters.Count) j = 0;
                waters[i].position = new Vector2(waters[j].position.x - offset, pos.y);
                break;
            }
            waters[i].position = pos + Vector2.right * (Time.deltaTime * waterSpeed);
        }
    }

    void MountainMove() {
        int flip = Random.Range(0, 2);
        float xOffset = Random.Range(0f, 50f);
        for (int i = 0; i < mountain.Count; i++) {
            Vector2 pos = mountain[i].position;
            var sprite = mountain[i].GetComponent<SpriteRenderer>();
            if (pos.x >= 20f) {
                mountain[i].position = new Vector2(-40 + (-1 *xOffset), pos.y);
                sprite.flipX = Convert.ToBoolean(flip);
                break;
            }
            mountain[i].position = pos + Vector2.right * (Time.deltaTime * mountainSpeed);
        }
    }
}
