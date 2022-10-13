// The program checks if a five-digit number is a palindrome

using System;
class Program
{
    public int GetNumber(string VarName)
    {
        int res;
        string input;
        bool is_number = false;
        bool is_5d_number = false;
        do
        {
            Console.WriteLine(String.Format("Enter a 5-digit number: {0} = ", VarName));
            input = Console.ReadLine();
            
            is_number = int.TryParse(input, out res);
            if(is_number) {
                is_5d_number = TestNumber_5d(res);
                if (!is_5d_number) {
                    Console.WriteLine(String.Format("The {0} is not a 5-digit number!", res));
                }
            }
            
        } while (!is_number || !is_5d_number);

        return res;
    }
    
    public bool TestNumber_3c(int num) {
        
        if (num >= 100 && num < 1000) {
            return true;
        } else {
            return false;
        }
    }
    public bool TestNumber_5d(int num) {
        
        if (num >= 10000 && num < 100000) {
            return true;
        } else {
            return false;
        }
    }
    public bool TestOnPalindrome(int num) {
        
        List<int> digits = ConvertNumberToArrayOfDigit(num);
        bool res = true;
        int count = digits.Count();
        int mid = digits.Count() / 2;
        for(int i = 0; i <= mid; i++){
            if (digits[i] != digits[count-i-1]) {
                res = false;
                break;
            }
        }
        return res;
    }
    public List<int> ConvertNumberToArrayOfDigit(int num)
    {
        List<int> DigitOfNumber = new List<int>();
        int Rest = 0;
        int LastNumber = num;
        int Base = 10;
        while(LastNumber != 0)
        {
            Rest = LastNumber % Base;
            DigitOfNumber.Add(Rest);
            LastNumber = (LastNumber - Rest) / Base;
        }
        return DigitOfNumber;
    }
    public void PrintNumberInDecimalNotation(int Number, List<int> NumberInDecimalNotation)
    {
        string Result = GetStringToPrintNumberInDecimalNotation(NumberInDecimalNotation);
        Console.WriteLine(String.Format("{0} = {1}", Number, Result));
    }

    public string GetStringToPrintNumberInDecimalNotation(List<int> NumberInDecimalNotation)
    {
        string Result = "";
        bool is_first_row = true;
        int MaxPower = 0;
        foreach(int digit in NumberInDecimalNotation) {
            
            if(is_first_row) {
                Result = Result + String.Format("{0}", digit, MaxPower);
                is_first_row = false;
                MaxPower = MaxPower + 1;
                continue;
            }
            string text_format = "{0}*10^{1} + ";
            if (MaxPower == 1) {
                text_format = "{0}*10 + ";
            }
            Result = String.Format(text_format, digit, MaxPower) + Result;
            MaxPower = MaxPower + 1;
        }
        return Result;
    }

    public static void Main(string[] args)
    {
        Program pr = new Program(); // Creating a class Object  
        Console.WriteLine("The program checks if a five-digit number is a palindrome.");

        string VarName_N = "N";
        int N = pr.GetNumber(VarName_N);
        bool is_palindrome = pr.TestOnPalindrome(N);
        
        string text_msg_format = "The {0} is a palindrome!";
        if(!is_palindrome) {
         text_msg_format = "The {0} is not a palindrome!";
        }
        Console.WriteLine(String.Format(text_msg_format, N));

        
    }
}