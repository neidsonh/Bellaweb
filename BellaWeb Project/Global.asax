<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("", "", "~/Pages/Index.aspx");
        routes.MapPageRoute("Login", "login", "~/Pages/Login.aspx");
        routes.MapPageRoute("Cadastro", "cadastro", "~/Pages/CadastroEstab.aspx");
        routes.MapPageRoute("Quem Somos", "quem-somos", "~/Pages/QuemSomos.aspx");
        routes.MapPageRoute("Termos de Uso", "termos-de-uso", "~/Pages/TermosDeUso.aspx");
        routes.MapPageRoute("Políticas de Privacidade", "politica-de-privacidade", "~/Pages/PoliticaDePrivacidade.aspx");
        routes.MapPageRoute("Perguntas Frequentes", "perguntas-frequentes", "~/Pages/PerguntasFrequentes.aspx");
        routes.MapPageRoute("Fale Conosco", "fale-conosco", "~/Pages/FaleConosco.aspx"); 
        routes.MapPageRoute("Pesquisa", "pesquisa", "~/Pages/Pesquisa.aspx");
        routes.MapPageRoute("Editar Estabelecimento", "editar", "~/Pages/EditarEstab.aspx");
        routes.MapPageRoute("Opções Estabelecimento", "editar/{opcao}", "~/Pages/EditarEstab.aspx");
        routes.MapPageRoute("Estabelecimento", "estabelecimento/{codigo}", "~/Pages/PerfilEstab.aspx");
        routes.MapPageRoute("Administrador", "admin", "~/Pages/AdmIndex.aspx");
        routes.MapPageRoute("Opções Administrador", "admin/{opcao}", "~/Pages/AdmIndex.aspx");
        routes.MapPageRoute("Analisar Cadastro", "analise-cadastro/{id}", "~/Pages/AnaliseEstab.aspx");
        routes.MapPageRoute("Plus", "plus/{id}", "~/Pages/Plus.aspx");
        routes.MapPageRoute("404", "404", "~/Pages/NotFound404.aspx");
    }
       
</script>
