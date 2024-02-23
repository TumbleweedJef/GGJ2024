using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TakeScoreTools : MonoBehaviour
{
    private void Start()
    {
        string inputString = "abc123def456ghi";
        int firstNumber = FindFirstNumber(inputString);
        Debug.Log(firstNumber);
    }

    public static int FindFirstNumber(string input)
    {
        return FindFirstDigit(input);
        // // 使用正则表达式匹配数字
        // Regex regex = new Regex(@"\d+");
        // Match match = regex.Match(input);
        //
        // // 如果找到了匹配项，将其转换为整数并返回
        // if (match.Success)
        // {
        //     if (int.TryParse(match.Value, out int result))
        //     {
        //         return result;
        //     }
        // }
        //
        // // 如果未找到数字，可以根据实际情况返回默认值或抛出异常等
        // // 在这里，我返回0作为默认值
        // return 0;
    }

    public static int FindFirstDigit(string input)
    {
        foreach (char character in input)
        {
            // 找到第一个数字字符并返回其整数值
            if (char.IsDigit(character))
            {
                return int.Parse(character.ToString());
            }
        }

        // 如果未找到数字，可以根据实际情况返回默认值或抛出异常等
        // 在这里，我返回0作为默认值
        return 0;
    }
}