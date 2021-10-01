using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01C_SophiaSiguere_1057719
{
    // representacion de todos los tokens posibles
    //es un enumerado
   public enum TokenType
    {
        Suma = '+',
        Resta = '-',
        Multiplicacion = '*',
        Division = '/',
        LParen ='(',
        RParen = ')',
        EOF = (char)0,
        Empty = (char)1,
        Null = (char)2,
        Numero = (char)3,

    }
}
