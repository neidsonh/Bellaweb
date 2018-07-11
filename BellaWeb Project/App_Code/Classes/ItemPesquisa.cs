using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemPesquisa
/// </summary>
public class ItemPesquisa
{
    // codigo, fantasia, imgurl, end, info, plus, servicos
    private long estCodigo;
    private string estFantasia;
    private string imagemUrl;
    private string endereco;
    private string info;
    private bool plus;
    private string servicos;
    private JArray jServicos;

    public long EstCodigo
    {
        get
        {
            return estCodigo;
        }

        set
        {
            estCodigo = value;
        }
    }

    public string EstFantasia
    {
        get
        {
            return estFantasia;
        }

        set
        {
            estFantasia = value;
        }
    }

    public string ImagemUrl
    {
        get
        {
            return imagemUrl;
        }

        set
        {
            imagemUrl = value;
        }
    }

    public string Endereco
    {
        get
        {
            return endereco;
        }

        set
        {
            endereco = value;
        }
    }

    public string Info
    {
        get
        {
            return info;
        }

        set
        {
            info = value;
        }
    }

    public bool Plus
    {
        get
        {
            return plus;
        }

        set
        {
            plus = value;
        }
    }

    public string Servicos
    {
        get
        {
            return servicos;
        }

        set
        {
            servicos = value;
            jServicos = JArray.Parse(servicos);
        }
    }

    public JArray ServicosJSON
    {
        get
        {
            return jServicos;
        }
    }
}