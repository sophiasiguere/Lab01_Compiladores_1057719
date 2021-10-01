using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Lab01C_SophiaSiguere_1057719
{
    class Parser
    {
        Scanner scanner;
        Token token;
        double resultado = 0;
        string resul = "";
        string resulta = "";

        int Operator(int op1, int op2, string op)
        {
            if (op == "*") return op1 * op2;
            if (op == "/") return op1 / op2;

            throw new ArgumentException("Specify a valid operator", "op");
        }

        private double E()
        {
            switch (token.Tag)
            {

                case TokenType.LParen:
                case TokenType.Numero:
                case TokenType.Resta:
                    return T() + EP();
                default:
                    return 0;
            }

        }
        private double EP()
        {
            switch (token.Tag)
            {
                case TokenType.Suma:
                    Match(TokenType.Suma);
                    return T() + EP();
                    
                case TokenType.Resta:
                    Match(TokenType.Resta);
                    return -T() + EP();
                default:
                    return 0;
            }
        }

        private double Neg()
        {
            switch (token.Tag)
            {
                case TokenType.Resta:
                    Match(TokenType.Resta);
                    return -Neg();
                default:
                    return 1;
            }
        }

        private double T()
        {
            switch (token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Numero:
                case TokenType.Resta:
                    return   Neg() * F() * TP();
                default:
                    return 0; 
            }

        }
        private double TP()
        {
            switch (token.Tag)
            {
                case TokenType.Multiplicacion:
                    Match(TokenType.Multiplicacion); 
                    return Neg() * F() * TP(); 
                case TokenType.Division:
                    Match(TokenType.Division);
                    return Neg() * F() * TP(); 
                default:
                    return 1;
            }
        }
        private double F()
        {
            switch (token.Tag)
            {
                case TokenType.LParen:
                    Match(TokenType.LParen);
                    resultado = E();
                    Match(TokenType.RParen);
                    return resultado + FP();
                case TokenType.Numero:
                    resul = token.Value.ToString();
                    Match(TokenType.Numero);
                    return FP();
                default:
                    return 0;
            }
        }
        private double FP()
        {
            switch (token.Tag)
            {
                case TokenType.Numero:
                    resulta = token.Value.ToString();
                    Match(TokenType.Numero);
                    resul += resulta;
                    return FP(); 
                default:
                    return (double.Parse(resul));
            }
        }
        private void Match(TokenType tag)
        {
            if (tag != TokenType.EOF)
            {
                if (token.Tag == tag)
                {
                    token = scanner.GetToken();
                }
                else
                {
                    throw new Exception("Syntax Error");
                }
            }
            else
            {
                if (token.Tag == tag)
                {
                }
                else
                {
                    throw new Exception("Syntax Error");
                }

            }

        }


        public void Parse(string entrada)
        {
            scanner = new Scanner(entrada);

            token = scanner.GetToken();

            switch (token.Tag)
            {

                case TokenType.LParen:
                case TokenType.Numero:
                case TokenType.Resta:
                    Console.WriteLine(E()); 
                    break;
                default:
                    break;
            }
            
            Match(TokenType.EOF);

        }
    }
}
