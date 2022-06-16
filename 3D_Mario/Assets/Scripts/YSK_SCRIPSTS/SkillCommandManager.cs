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

    List<CommandInput> commandInputlist;    // 입력값 수명과 함꼐 저장

    void Start()
    {
        _mario = FindObjectOfType<CHARACTER>();
        commandInputlist = new List<CommandInput>();
    }

    private void Update()
    {
        // 커맨드 리스트 입력 관리
        foreach (var key in keyTable)
        {
            if (Input.GetKeyDown(key))
            {
                commandInputlist.Add(new CommandInput(key, commandLifeTime));
            }
        }

        // 커맨드 리스트 실행 관리
        foreach (var skill in skills)
        {
            int i = 0;
            var length = skill.Command.Length;

            if (length <= 0) // 스킬 커맨드가 없음
                continue;

            foreach (var commands in commandInputlist)
            {
                if (commands.input == skill.Command[i]) // 커맨드 하나 일치
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                if (length <= i) // 스킬커맨드 올 클리어 => 실행
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
