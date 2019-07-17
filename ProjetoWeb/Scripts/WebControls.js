/*
Ajuste da Hora
*/

function HoraCerta() {

    var d = new Date();
    var t = d.toLocaleTimeString();

    document.getElementById('dataHora').childNodes[0].data = ' - ' + d.toLocaleDateString() + ' - ' + t;
}

/*
Ocultar Mensagem
*/

//function OcultarMensagem() {
//    
//    var mensagem = document.getElementById("ctl00_MainContent_trMensagemPageCadastro");
//    if (mensagem != null) { 
//        mensagem.style.visibility = 'hidden';
//    }
//       
//    return true;
//}

//*
//Ajuste do Menu
//*/
function ModificarCSS(clientID, cssClassName) {
    document.getElementById(clientID).className = cssClassName;
}

//*
//Ajuste da Altura do Formulario
//*/
function AlturaDoFormPrincipal(clientID, clientID_ct, offsetTop) {
    if (document.getElementById(clientID) != null) {
        document.getElementById(clientID).style.maxHeight = ($(window).height() - 60 - offsetTop) + "px";
        document.getElementById(clientID).style.minHeight = ($(window).height() - 60 - offsetTop) + "px";
        document.getElementById(clientID).style.height = ($(window).height() - 60 - offsetTop) + "px";
    }

    if (document.getElementById(clientID_ct) != null) {
        document.getElementById(clientID_ct).style.maxHeight = ($(window).height() - 60 - offsetTop) + "px";
        document.getElementById(clientID_ct).style.minHeight = ($(window).height() - 60 - offsetTop) + "px";
        document.getElementById(clientID_ct).style.height = ($(window).height() - 60 - offsetTop) + "px";
    }
}


/*
Ajuste do Calendário para o Português Brasil
*/
$(document).ready(function () {
    $.datepicker.regional['pt-BR'] = {
        closeText: 'Fechar',
        prevText: '&#x3c;Anterior',
        nextText: 'Pr&oacute;ximo&#x3e;',
        currentText: 'Hoje',
        monthNames: ['Janeiro', 'Fevereiro', 'Mar&ccedil;o', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        dayNames: ['Domingo', 'Segunda-feira', 'Ter&ccedil;a-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
        dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
        weekHeader: 'Sm',
        numberOfMonths: 1,
        dateFormat: 'dd/mm/yy',
        firstDay: 0,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''

    };
    $.datepicker.setDefaults($.datepicker.regional['pt-BR']);

});


/*
Texto Upper
*/
function UpperCase(obj) {
    obj.value = obj.value.toUpperCase();
}

/*
Chamada dos métodos de Validação de CPF e de CNPJ
*/
function valida_CPFCNPJ(oSrc, args) {

    args.Value = args.Value.replace(/\./g, '').replace(/\-/g, '').replace(/\_/g, '').replace('/', '');

    if (args.Value.length == 11) {

        valida_CPF(oSrc, args);

    } else if (args.Value.length == 14) {

        valida_CNPJ(oSrc, args);

    } else {

        return args.IsValid = false;

    }

}


/*
Validação de CPF
*/
function valida_CPF(oSrc, args) {

    if ((args.Value == 11111111111) || (args.Value == 22222222222) || (args.Value == 33333333333) || (args.Value == 44444444444) || (args.Value == 55555555555) || (args.Value == 66666666666) || (args.Value == 77777777777) || (args.Value == 88888888888) || (args.Value == 99999999999) || (args.Value == 00000000000)) {

        return args.IsValid = false;
    }

    s = args.Value;

    if (isNaN(s)) {

        return args.IsValid = false;

    }

    var i;

    var c = s.substr(0, 9);

    var dv = s.substr(9, 2);

    var d1 = 0;

    for (i = 0; i < 9; i++) {

        d1 += c.charAt(i) * (10 - i);

    }

    if (d1 == 0) {

        return args.IsValid = false;

    }

    d1 = 11 - (d1 % 11);

    if (d1 > 9) d1 = 0;

    if (dv.charAt(0) != d1) {

        return args.IsValid = false;

    }

    d1 *= 2;

    for (i = 0; i < 9; i++) {

        d1 += c.charAt(i) * (11 - i);

    }

    d1 = 11 - (d1 % 11);

    if (d1 > 9) d1 = 0;

    if (dv.charAt(1) != d1) {

        return args.IsValid = false;

    }

    return args.IsValid = true;

}


/*
Validação de CPF
*/
function valida_CNPJ(oSrc, args) {


    s = args.Value;

    if (isNaN(s)) {

        return args.IsValid = false;

    }

    var i;

    var c = s.substr(0, 12);

    var dv = s.substr(12, 2);

    var d1 = 0;

    for (i = 0; i < 12; i++) {

        d1 += c.charAt(11 - i) * (2 + (i % 8));

    }

    if (d1 == 0)

        return args.IsValid = false;

    d1 = 11 - (d1 % 11);

    if (d1 > 9) d1 = 0;

    if (dv.charAt(0) != d1) {

        return args.IsValid = false;

    }

    d1 *= 2;

    for (i = 0; i < 12; i++) {

        d1 += c.charAt(11 - i) * (2 + ((i + 1) % 8));

    }

    d1 = 11 - (d1 % 11);

    if (d1 > 9)

        d1 = 0;

    if (dv.charAt(1) != d1) {

        return args.IsValid = false;

    }

    return args.IsValid = true;

}


/*
Disparar o PostBack da Tela de Dentro do Grid
*/
function dispararPostBackGridView(rowIndex, buttonUniqueID, hiddenID) {
    document.getElementById(hiddenID).value = rowIndex.toString();
    __doPostBack(buttonUniqueID, '1');
}


/*
Exibir Mensagem de Confirmação de dentro de um GridView
*/
function ExibirMensagemConfirmacaoGridView(controle, index) {

    $('<div class="mensagem"> Confirma a exclusão deste registro? </div>').dialog(
    {
        title: 'SINAF - Seguros',
        modal: true,
        resizable: false,
        draggable: true,
        closeOnEscape: true,
        minWidth: 350,
        minHeight: 120,
        zIndex: 9999,
        buttons:
        {
            'Sim': function () {
                $(this).dialog('close');
                __doPostBack(controle, 'Delete$' + index);
            },

            'Não': function () {
                $(this).dialog('close');
            }
        }
    });

    return false;
}


/*
Exibir Mensagem de Confirmacao
*/
function ExibirMensagemConfirmacao(msg) {
    if (confirm(msg))
        return true;
    return false;
}


/*
Formatar Números com Decimais 
*/
function FormatarNumero(numero, casaDecimais, usarSeparadorMilhar) {
    var num = numero.value.replace(/\./g, "").replace(/\,/g, "");
    var tecla = num.substr(num.length - 1, 1)
    if (isNaN(parseFloat(tecla))) {
        numero.value = numero.value.substr(0, numero.value.length - 1);
        return numero.value;
    }

    var numeroFormatado;

    if (casaDecimais == 0)
        numeroFormatado = "";
    else
        numeroFormatado = ',' + num.substr(num.length - casaDecimais, casaDecimais);

    var numeroAux = '';

    var numeroAux2 = '';

    if (usarSeparadorMilhar) {
        for (i = num.length - casaDecimais - 1; i >= 0; i--) {
            if (numeroAux2.length % 3 != 0 || numeroAux2.length == 0)
                numeroAux = num.charAt(i) + numeroAux;
            else
                numeroAux = num.charAt(i) + '.' + numeroAux;

            numeroAux2 += num.charAt(i);
        }
    }
    else
        numeroFormatado = num.substr(0, num.length - casaDecimais) + numeroFormatado;

    numeroFormatado = numeroAux + numeroFormatado;

    if (numeroFormatado == ",")
        numeroFormatado = "";

    numero.value = numeroFormatado;

    return numero.value;

}

/*
Validação de Data
*/
function ValidarData(sender, args) {
    args.IsValid = VerificaData(args);
}

/*
Validação de Data
*/
function VerificaData(textBox) {
    var data = textBox.value;

    var tam = data.length;

    if (tam != 10) {
        //textBox.value = '';
        return false;
    }
    var dia = data.substr(0, 2)

    var mes = data.substr(3, 2)

    var ano = data.substr(6, 4)

    switch (mes) {
        case '01':

            if (dia <= 31)

                return (true);

            break;

        case '02':

            if (dia <= 29)

                return (true);

            break;

        case '03':

            if (dia <= 31)

                return (true);

            break;

        case '04':

            if (dia <= 30)

                return (true);

            break;

        case '05':

            if (dia <= 31)

                return (true);

            break;

        case '06':

            if (dia <= 30)

                return (true);

            break;

        case '07':

            if (dia <= 31)

                return (true);

            break;

        case '08':

            if (dia <= 31)

                return (true);

            break;

        case '09':

            if (dia <= 30)

                return (true);

            break;

        case '10':

            if (dia <= 31)

                return (true);

            break;

        case '11':

            if (dia <= 30)

                return (true);

            break;

        case '12':

            if (dia <= 31)

                return (true);

            break;
    }

    {

        return false;

    }

    return true;
}


/*
Variável Declarada para Abrir NovaJanela no Chrome
*/
var IDActiveElement = '';


/*
Função para abrir em nova janela
*/
function NovaJanela() {
    var element = '';

    if (document.activeElement != null) {
        if (document.activeElement.nodeName.toUpperCase() == 'BODY')
            element = document.getElementById(IDActiveElement);
        else
            element = document.activeElement;

        if (element != null && element.getAttribute('NovaJanela') != null && element.getAttribute('NovaJanela').toUpperCase() == 'TRUE') {
            document.forms[0].target = '_blank';
            document.body.focus();
        }
        else
            document.forms[0].target = '';
    }

    IDActiveElement = '';
}

/*
Exibir mensagem de confirmação
*/
function ExibirMensagemConfirmacao(unidqueIDControle, mensagem, unidqueIDControleCancelar) {
    $('<div class="mensagem">' + mensagem + '</div>').dialog(
    {
        title: 'SINAF - Seguros',
        modal: true,
        resizable: false,
        draggable: true,
        closeOnEscape: true,
        minWidth: 350,
        minHeight: 120,
        zIndex: 9999,
        buttons:
        {
            'Sim': function () {
                $(this).dialog('close');
                __doPostBack(unidqueIDControle, '1');
            },

            'Não': function () {
                $(this).dialog('close'); //close confirmation    
                if (unidqueIDControleCancelar != null)
                    __doPostBack(unidqueIDControleCancelar, '1');
            }
        }
    });

    return false;

}


/*
Exibir Mensagem
*/
function ExibirMensagem(mensagem) {

    $('<div class="mensagem">' + mensagem + '</div>').dialog(
    {
        title: 'SINAF - Seguros',
        modal: true,
        resizable: false,
        draggable: true,
        closeOnEscape: true,
        minWidth: 350,
        minHeight: 120,
        zIndex: 9999,
        buttons:
        {
            'OK': function () {
                $(this).dialog('close');
            }
        }
    });

    return false;

}

function Aguarde() {

    $.blockUI.defaults.css = {
        padding: 0,
        margin: 0,
        width: '30%',
        top: '40%',
        left: '35%',
        textAlign: 'center',
        color: 'Black',
        cursor: 'wait',

    };

    $.blockUI.defaults.overlayCSS = {
        backgroundColor: 'Black',
        opacity: 0.2,
        cursor: 'wait'
    };

    $.blockUI.defaults.baseZ = 99999999999;

    var CaminhoImagemAguardando = "Images/processando6.gif";

    $.blockUI(
        {
            message: '<div style="font-size:15px;font-family: Verdana,sans-serif;font-weight: normal; color:#5E6063"><img src="' + CaminhoImagemAguardando + '" /><span style="color: white;">&nbsp;Processando...</span></div>'
        });

}