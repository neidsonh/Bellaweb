using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Paginacao
/// </summary>
public class Paginacao
{
    private int numeroDaPagina;
    private int limitePorPagina;

    public Paginacao()
    {
        LimitePorPagina = 10;    
    }

    public int NumeroDaPagina
    {
        get
        {
            return numeroDaPagina;
        }

        set
        {
            if (value < 1)
                throw new Exception("NumeroDaPagina deve ser no mínimo maior que 1");
            numeroDaPagina = value;
        }
    }

    public int LimitePorPagina
    {
        get
        {
            return limitePorPagina;
        }

        set
        {
            limitePorPagina = value;
        }
    }

    public int IndiceDaPagina()
    {
        return (NumeroDaPagina - 1) * LimitePorPagina;
    }

    public int Offset()
    {
        return NumeroDaPagina * LimitePorPagina;
    }
}