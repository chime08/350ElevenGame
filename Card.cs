using System;
using System.Collections.Generic;
using System.Data;
using System.Net;

public class Card
{
    private int value;
    private string suit;
    public static string[] Suits = {"Clubs", "Hearts", "Diamonds", "Spades"};
    public static int[] Value = {1,2,3,4,5,6,7,8,9,10,11,12,13};

    public string getvalueName() //switch nums to names 1=> A
    {
        switch(value)
        {
            case 1: return "A";
            case 11: return "J";
            case 12: return "Q";
            case 13: return "K";
            default: return value.ToString();
        }
    }
    public Card(string suit, int value)
    {
        this.suit = suit;
        this.value = value;
    }
    public int getValue()
    {
        return value;
    }
    public override string ToString()
    {
        return $"{suit} of {value}";
    }
}