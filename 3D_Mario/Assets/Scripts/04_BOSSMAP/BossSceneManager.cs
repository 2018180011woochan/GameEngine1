using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneManager : MonoBehaviour
{
    public BossEnemy Boss;
    public GameObject GamePanel;
    public RectTransform BossHealthGroup;
    public RectTransform BossHealthBar;

    private void LateUpdate()
    {
        BossHealthBar.localScale = new Vector3((float)Boss.curHealth / Boss.maxHealth, 1, 1);
    }
}
