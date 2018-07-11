using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MargemValor define um valor minímo e um máximo entre dois valores de ponto flutuante
/// </summary>
public class PriceRange
{
    private double menorValor;
    private double maiorValor;

    public PriceRange(double menorValor, double maiorValor)
    {
        if (menorValor > maiorValor)
        {
            double aux = menorValor;
            menorValor = maiorValor;
            maiorValor = aux;
        }

        this.menorValor = menorValor;
        this.maiorValor = maiorValor;
    }

    public double MenorValor
    {
        get
        {
            return menorValor;
        }
    }

    public double MaiorValor
    {
        get
        {
            return maiorValor;
        }
    }

    public bool isValid()
    {
        return menorValor > 0 && maiorValor > 0;
    }
}