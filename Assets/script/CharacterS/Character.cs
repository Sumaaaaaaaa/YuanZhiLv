using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private int attack; // 攻击力
    [SerializeField] private int life; // 生命值
    public PlayerTag owner; // 指定属于哪个玩家

}
