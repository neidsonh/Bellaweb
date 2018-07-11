var notify = {};

//Mensagens Editar Perfil
//sucesso
notify.a = function sucessoNotifyMensagem() {
    new PNotify({
        title: 'Perfil alterado com Sucesso!',
        type: 'success'
    });
};
//erro
notify.A = function erroNotifyMensagem() {
    new PNotify({
        title: 'Erro ao alterar perfil!',
        type: 'error'
    });
};

//Mensagens Editar Perfil
//sucesso
notify.b = function sucessoNotifyMensagem() {
    new PNotify({
        title: 'Senha alterada com Sucesso!',
        type: 'success'
    });
};
//erro
notify.B = function erroNotifyMensagem() {
    new PNotify({
        title: 'Erro ao alterar senha!',
        type: 'error'
    });
};

//Mensagens Ativar Plus
notify.c = function sucessoNotifyMensagem() {
    new PNotify({
        title: 'Plus Ativado!',
        type: 'success'
    });
};
//Mensagem Desativar Plus
notify.C = function erroNotifyMensagem() {
    new PNotify({
        title: 'Plus Desativado!',
        type: 'error'
    });
};

//Mensagens Adicionar Serviços
//sucesso
notify.d = function sucessoNotifyMensagem() {
    new PNotify({
        title: 'Serviço adicionado com Sucesso!',
        type: 'success'
    });
};
//erro
notify.D = function erroNotifyMensagem() {
    new PNotify({
        title: 'Erro ao adicionar serviço!',
        type: 'error'
    });
};

//Mensagens Cadastro TipoServiço
//sucesso
notify.s = function sucessoNotifyServico() {
    new PNotify({
        title: 'Tipo de Serviço cadastrado com sucesso!',
        type: 'success'
    });
};

//erro
notify.S = function erroNotifyServico() {
    new PNotify({
        title: 'Erro ao cadastrar serviço!',
        text: 'Não foi possível cadastrar o serviço.</br>Tente novamente.',
        type: 'error'
    });
};

//Mensagens Cadastro SubTipoServiço
//sucesso
notify.j = function sucessoNotifyTipoServico() {
    new PNotify({
        title: 'Sub-tipo de Serviço cadastrado com sucesso!',
        type: 'success'
    });
};

//erro
notify.J = function erroNotifyTipoServico() {
    new PNotify({
        title: 'Erro ao cadastrar Sub-tipo Serviço!',
        text: 'Não foi possível cadastrar o sub-tipo de serviço.</br>Tente novamente.',
        type: 'error'
    });
};

//erro nome de serviço ja existe
notify.X = function erroNotifyServico2() {
    new PNotify({
        title: 'Erro ao cadastrar serviço!',
        text: 'Não é possivel cadastrar serviços com o mesmo nome',
        type: 'error'
    });
};

//Mensagens Exclusao TipoServiço
//sucesso
notify.k = function sucessoExcluirTipoServico() {
    new PNotify({
        title: 'Tipo de Serviço excluído com sucesso!',
        type: 'success'
    });
};

//erro
notify.K = function erroExcluirTipoServico() {
    new PNotify({
        title: 'Erro ao excluir Tipo de Serviço!',
        text: 'Não foi possível excluir o serviço.</br>Verifique se ele possui Sub-tipo de serviços atrelados.',
        type: 'error'
    });
};

//Mensagens Cadastro Cidades
//sucesso
notify.p = function sucessoCadastrarCidades() {
    new PNotify({
        title: 'Cidade cadastrada com sucesso!',
        type: 'success'
    });
};

//erro
notify.P = function erroCadastrarCidades() {
    new PNotify({
        title: 'Erro ao cadastrar cidade!',
        text: 'Não foi possível cadastrar.',
        type: 'error'
    });
};

//Mensagens Excluir Cidades
//sucesso
notify.l = function sucessoExcluirCidades() {
    new PNotify({
        title: 'Cidade excluída com sucesso!',
        type: 'success'
    });
};

//erro
notify.L = function erroExcluirCidades() {
    new PNotify({
        title: 'Erro ao excluir cidade!',
        text: 'Não foi possível excluir.',
        type: 'error'
    });
};

//Mensagens Cadastrar Estados
//sucesso
notify.o = function sucessoCadastrarUf() {
    new PNotify({
        title: 'Estado cadastrado com sucesso!',
        type: 'success'
    });
};

//erro
notify.O = function erroCadastrarUf() {
    new PNotify({
        title: 'Erro ao cadastrar estado!',
        text: 'Não foi possível cadastrar.',
        type: 'error'
    });
};

//Mensagens Excluir Estados
//sucesso
notify.m = function sucessoExcluirUf() {
    new PNotify({
        title: 'Estado excluído com sucesso!',
        type: 'success'
    });
};

//erro
notify.M = function erroExcluirUf() {
    new PNotify({
        title: 'Erro ao excluir estado!',
        text: 'Não foi possível excluir, pois existem Cidades Cadastradas.',
        type: 'error'
    });
};

//Mensagens Cadastrar Destaques
//sucesso
notify.u = function sucessoCadastrarDestaque() {
    new PNotify({
        title: 'Destaque cadastrado com sucesso!',
        type: 'success'
    });
};

//erro
notify.U = function erroCadastrarDestaque() {
    new PNotify({
        title: 'Erro ao cadastrar destaque!',
        text: 'Não foi possível cadastrar destaque.',
        type: 'error'
    });
};

//Mensagens Excluir Destaques
//sucesso
notify.y = function sucessoExcluirDestaque() {
    new PNotify({
        title: 'Destaque excluido com sucesso!',
        type: 'success'
    });
};

//erro
notify.Y = function erroExcluirDestaque() {
    new PNotify({
        title: 'Erro ao excluir destaque!',
        text: 'Não foi possível excluir destaque.',
        type: 'error'
    });
};

//Mensagens Analise Estabelecimento
//Aprovado
notify.H = function sucessoAprovado() {
    new PNotify({
        title: 'Estabelecimento Aprovado!',
        type: 'success'
    });
};

//Negado
notify.h = function sucessoNegado() {
    new PNotify({
        title: 'Estabelecimento Negado!',
        type: 'error'
    });
};

//Aguardando
notify.g = function sucessoAguardando() {
    new PNotify({
        title: 'Estabelecimento Aguardando!',
        type: 'info'
    });
};

//Mensagens Cadastros Estabelecimentos
        //sucesso
notify.q = function sucessoNotifyCadastro() {
    new PNotify({
        title: 'Cadastrado com sucesso!',
        text: 'Aguarde a aprovação do administrador.',
        type: 'success'
    });
};
        
        //erro
notify.Q = function erroNotifyCadastro() {
    new PNotify({
        title: 'Erro ao Cadastrar!',
        text: 'Desculpe, nao foi possível completar o cadastro.</br>Tente novamente.',
        type: 'error'
    });
};
        //Mensagens Fale Conosco
        //sucesso
notify.y = function sucessoNotifyMensagem() {
    new PNotify({
        title: 'Mensagem enviada com sucesso!',
        type: 'success'
    });
};
        //erro
notify.Y = function erroNotifyMensagem() {
    new PNotify({
        title: 'Erro ao enviar mensagem!',
        type: 'error'
    });
};



//Mensagens Excluir Serviços
//sucesso
notify.z = function sucessoNotifyMensagem() {
    new PNotify({
        title: 'Serviço excluído com Sucesso!',
        type: 'success'
    });
};
//erro
notify.Z = function erroNotifyMensagem() {
    new PNotify({
        title: 'Erro ao excluir serviço!',
        type: 'error'
    });
};





function run(n) {
    notify[n]();
}
