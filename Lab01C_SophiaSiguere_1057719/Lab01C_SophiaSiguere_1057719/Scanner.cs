using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01C_SophiaSiguere_1057719
{
    class Scanner
    {
        //El scanner lee token por token
        //Llamadas consecutivas a getToken por eso se realiza global 
        private string _regexp = "";
        private int _index = 0;
        private int _state = 0;
        private const char EOF = (char)0;
     
        /*Se le agrega un caracter al final para saber que se finalizo, es el delimitador
        para no leer toda la cadena para encontrar el final
             */

        public Scanner(string regexp)
        {
            _regexp = regexp + (char)TokenType.EOF;
            _index = 0;
            _state = 0;
        }

        // a un token se le asocia un valor y un nombre, por lo tanto 2 campos que devuelve un tipo de dato
        public Token GetToken()
        {
            Token result = new Token() { Value = (char)0 };//vacio inicia
            bool tokenFound = false;
            while (!tokenFound)
            {
                char peek = _regexp[_index];

                switch (_state)
                {

                    case 0:

                        // Whitespace removal
                        while (char.IsWhiteSpace(peek))
                        {
                            _index++;
                            peek = _regexp[_index];
                        }

                        switch (peek)
                        {
                            case '\\':
                                _state = 1;
                                break;
                            case (char)TokenType.LParen:
                            case (char)TokenType.RParen:
                            case (char)TokenType.Suma:
                            case (char)TokenType.Multiplicacion:
                            case (char)TokenType.Division:
                            case (char)TokenType.Resta:
                            case (char)TokenType.EOF:
                                tokenFound = true;
                                result.Tag = (TokenType)peek;
                                break;
                            default:
                                tokenFound = true;
                                result.Tag = TokenType.Numero;
                                result.Value = peek;
                                break;
                        } //Switch peek

                        break; // case state0
                    case 1:
                        switch (peek)
                        {
                            case (char)TokenType.LParen:
                            case (char)TokenType.RParen:
                            case (char)TokenType.Suma:
                            case (char)TokenType.Multiplicacion:
                            case (char)TokenType.Division:
                            case (char)TokenType.Resta:
                            case '\\':
                            case ' ':
                                tokenFound = true;
                                result.Tag = TokenType.Numero;
                                result.Value = peek;
                                break;
                            default:
                                throw new Exception("Lex Error");

                        }
                        break; //case state1

                    default:
                        break;
                } //Switch state

                _index++;

            } //While -TokenFound
            _state = 0;
          
            return result;
            
        }//GET Token

    }
}


