using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

class CommandInput
{
    public CommandInput(KeyCode _input, float _lifeTime)
    {
        input = _input;
        // lifeTime = _lifeTime;
        lifeTime = Time.time + _lifeTime;
    }

    public KeyCode input;
    public float lifeTime;
}


[Serializable]
public class CommandSkill
{
    // send skillname message to player.
    public string skillname;
    public KeyCode[] Command;
}

public class SkillCommandManager : BASIC_SINGLETON<SkillCommandManager>
{
    public float commandLifeTime = 2f;
    public CommandSkill[] skills;
    CHARACTER _mario;

    KeyCode[] keyTable =
{
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow,

        KeyCode.LeftControl,
        KeyCode.Space
    };

    List<CommandInput> commandInputlist;    // �Է°� ����� �Բ� ����

    void Start()
    {
        _mario = FindObjectOfType<CHARACTER>();
        commandInputlist = new List<CommandInput>();
    }

    private void Update()
    {
        // Ŀ�ǵ� ����Ʈ �Է� ����
        foreach (var key in keyTable)
        {
            if (Input.GetKeyDown(key))
            {
                commandInputlist.Add(new CommandInput(key, commandLifeTime));
            }
        }

        // Ŀ�ǵ� ����Ʈ ���� ����
        foreach (var skill in skills)
        {
            int i = 0;
            var length = skill.Command.Length;

            if (length <= 0) // ��ų Ŀ�ǵ尡 ����
                continue;

            foreach (var commands in commandInputlist)
            {
                if (commands.input == skill.Command[i]) // Ŀ�ǵ� �ϳ� ��ġ
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                if (length <= i) // ��ųĿ�ǵ� �� Ŭ���� => ����
                {
                    _mario.SendMessage(skill.skillname);
                    break;
                }
            }
        }

        //  commandInputlist.ForEach(command => { print(command.input + "!" + command.lifeTime); command.lifeTime -= Time.deltaTime; });
        // commandInputlist.RemoveAll(command => command.lifeTime <= 0);

        commandInputlist.RemoveAll(command => command.lifeTime <= Time.time);
    }
}
