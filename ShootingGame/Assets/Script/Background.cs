using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Background : MonoBehaviour {

    [SerializeField][Range(1f, 20f)] float speed = 3f;
    List<Transform> waters = new List<Transform>();
    void Start() {
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).name == "Water") {
                for (int j = 0; j < transform.GetChild(i).childCount; j++) {
                    waters.Add(transform.GetChild(i).GetChild(j));
                }
            }
        }

    }

    void Update() {
        WaterMove(25.073f);
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
            waters[i].position = pos + Vector2.right * (Time.deltaTime * speed);
        }
    }
}
