// JScript File

function GetDecimalDelimiter() {
    return ',';
}

function GetCommaDelimiter() {
    return '';
}

function addCommas(nStr) {
    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    x2 = x2.replace('.', ',');
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + '.' + '$2');
    }
    return x1 + x2;
}

function FormatClean(num) {
    var sVal = '';
    var nVal = num.length;
    var sChar = '';


    try {
        for (c = 0; c < nVal; c++) {
            sChar = num.charAt(c);
            nChar = sChar.charCodeAt(0);
            if ((nChar >= 48) && (nChar <= 57)) { sVal += num.charAt(c); }
        }
    }
    catch (exception) { AlertError("Format Clean", exception); }
    return sVal;
}

function FormatInteiro(campo) {
    var sVal = '';
    var nVal = campo.value.length;
    var sChar = '';


    try {
        for (c = 0; c < nVal; c++) {
            sChar = campo.value.charAt(c);
            nChar = sChar.charCodeAt(0);
            if ((nChar >= 48) && (nChar <= 57)) { sVal += campo.value.charAt(c); }
        }
    }
    catch (exception) { AlertError("Format Clean", exception); }

    campo.value = sVal;
}


function MascaraCentroCusto(campo) {
    var sVal = '';
    var nVal = campo.value.length;
    var sChar = '';

    try {
        for (c = 0; c < nVal; c++) {
            sChar = campo.value.charAt(c);
            nChar = sChar.charCodeAt(0);
            if (nChar == 57 || nChar == 46 || nChar == 8 || nChar == 127) {
                sVal += campo.value.charAt(c);
            }
        }
        campo.value = sVal;
    }
    catch (exception) { AlertError("MascaraCentroCusto", exception); }
}

function FortmataZeroAEsquerda(num) {
    var tamanho = num.length;
    try {
        caractere = num.charAt(0)
        while ((caractere == '0' || caractere == '.') && num.length > 1) {
            num = num.replace(num.charAt(0), "");
            caractere = num.charAt(0);
        }
    }
    catch (exception) { AlertError("Format Clean", exception); }
    return num;
}


function FormatCurrency(campo, useSymbol) {
    try {

        decimalPlaces = 2;
        comma = GetCommaDelimiter();
        dec = GetDecimalDelimiter();

        if (decimalPlaces < 1) { dec = ''; }
        if (campo.value.lastIndexOf("-") == 0) {
            minus = '-';
        }
        else {
            minus = '';
        }


        preDecimal = FormatClean(campo.value);
        preDecimal = FortmataZeroAEsquerda(preDecimal);

        if (preDecimal.length == 0) {

            result = '';

        } else if (preDecimal.length == 1) {

            result = '0' + GetDecimalDelimiter() + '0' + preDecimal;

        } else if (preDecimal.length == 2) {

            result = '0' + GetDecimalDelimiter() + preDecimal;

        } else if (preDecimal.length > 2) {

            result = preDecimal.substring(0, preDecimal.length - 2) + GetDecimalDelimiter() + preDecimal.substring(preDecimal.length - 2);
        }

        if (useSymbol)
            result += "R$ ";

        if (result == '0' + GetDecimalDelimiter() + '00')
            minus = '';

        if (useSymbol)
            result = "R$ " + result;

        campo.value = minus + result;

    }
    catch (exception) { AlertError("Format Number", exception); }
}

function AlertError(methodName, e) {
    if (e.description == null) {
        alert(methodName + " Exception: " + e.message);
    }
    else {
        alert(methodName + " Exception: " + e.description);
    }
}

function FormatNumber(campo, casasDecimais) {
    try {

        if (casasDecimais == "0")

            FormatInteiro(campo);

        else {
            decimalPlaces = casasDecimais;
            comma = GetCommaDelimiter();
            dec = GetDecimalDelimiter();

            if (decimalPlaces < 1) { dec = ''; }
            if (campo.value.lastIndexOf("-") == 0) {
                minus = '-';
            }
            else {
                minus = '';
            }


            preDecimal = FormatClean(campo.value);
            preDecimal = FortmataZeroAEsquerda(preDecimal);

            if (preDecimal.length == 0) {

                result = '';

            } else if (preDecimal.length < decimalPlaces) {

                result = '0' + GetDecimalDelimiter();

                numeroDeZeros = decimalPlaces - preDecimal.length;

                for (i = 0; i < numeroDeZeros; i++)
                    result = result + '0';

                result = result + preDecimal;

            } else if (preDecimal.length == decimalPlaces) {

                result = '0' + GetDecimalDelimiter() + preDecimal;

            } else if (preDecimal.length > decimalPlaces) {

                result = preDecimal.substring(0, preDecimal.length - decimalPlaces) + GetDecimalDelimiter() + preDecimal.substring(preDecimal.length - decimalPlaces);
            }

            campo.value = minus + result;
        }

    }
    catch (exception) { AlertError("Format Number", exception); }
}

function CompletarCasasDecimais(campo, casasAntesDavirgula, casasDecimais, usarSeparador) {
    var posicaoCursor = doGetCaretPosition(campo);

    var numeroParaFormatar = campo.value;
    var indiceDaVirgula = numeroParaFormatar.indexOf(",");

    var numeroDepoisDaVirgula = "";

    var indiceAntesDaVirgula = indiceDaVirgula;
    if (indiceAntesDaVirgula == -1)
        indiceAntesDaVirgula = numeroParaFormatar.length;
    else
        numeroDepoisDaVirgula = numeroParaFormatar.substring(indiceDaVirgula + 1, numeroParaFormatar.length);

    var numeroAntesDaVirgula = numeroParaFormatar.substring(0, indiceAntesDaVirgula);

    var valorFormatado = "";

    if (casasDecimais > 0) {
        if (numeroDepoisDaVirgula.length > casasDecimais)
            numeroDepoisDaVirgula = numeroDepoisDaVirgula.substring(0, casasDecimais);

        numeroDepoisDaVirgula = PadRight(numeroDepoisDaVirgula, casasDecimais, "0");
        valorFormatado = numeroAntesDaVirgula + "," + numeroDepoisDaVirgula;
    }
    else
        if (indiceDaVirgula != -1 && casasDecimais > 0) {
            valorFormatado = numeroAntesDaVirgula + ",";
        }
        else {
            valorFormatado = numeroAntesDaVirgula;
        }

    campo.value = valorFormatado;
    setCaretPosition(campo, posicaoCursor);
}

function BuscarQuantidadeInicialAntesDaVirgula(campo, teclaSeparador) {
    var indiceAntesDaVirgula = campo.value.indexOf(teclaSeparador);
    if (indiceAntesDaVirgula == -1)
        indiceAntesDaVirgula = campo.value.length;

    var numeroAntesDaVirgula = campo.value.substring(0, indiceAntesDaVirgula);

    return numeroAntesDaVirgula.length;
}

function UltimaPosicao(campo, posicaoCursor, teclaSeparador) {
    var indiceDaVirgulaUtilizandoPonto = campo.value.indexOf(teclaSeparador);
    if (indiceDaVirgulaUtilizandoPonto == -1)
        indiceDaVirgulaUtilizandoPonto = campo.value.length;

    var numeroAntesDaVirgulaUtilizandoPonto = campo.value.substring(0, indiceDaVirgulaUtilizandoPonto);
    var UltimaPosicao = (posicaoCursor == numeroAntesDaVirgulaUtilizandoPonto.length);

    return UltimaPosicao;
}

function QuantidadeDePontosInicial(campo, posicaoCursor, teclaSeparador) {
    return parseInt(campo.value.substring(0, posicaoCursor).length / 3);
}

function FormatarCampoNumerico(campo, evento, casasAntesDavirgula, casasDecimais, usarSeparador, teclaSeparador) {

    var keyCode = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode;

    if (keyCode == 9 || keyCode == 16 || keyCode == 36 || keyCode == 35)
        return;

    var posicaoCursor = doGetCaretPosition(campo);

    var quantidadeInicialAntesDaVirgula = BuscarQuantidadeInicialAntesDaVirgula(campo, teclaSeparador);

    var ultimaPosicao = UltimaPosicao(campo, posicaoCursor, teclaSeparador);

    var quantidadeDePontosInicial = QuantidadeDePontosInicial(campo, posicaoCursor, teclaSeparador);

    var idTeclaPrecionada = keyCode;
    if (idTeclaPrecionada != 37 && idTeclaPrecionada != 39) // <- ->
    {
        var numeroParaFormatar = campo.value;

        numeroParaFormatar = replaceAll(numeroParaFormatar, ".", "");
        var indiceDaVirgula = numeroParaFormatar.indexOf(teclaSeparador);
        numeroParaFormatar = FormatClean(numeroParaFormatar);

        var numeroDepoisDaVirgula = "";

        var indiceAntesDaVirgula = indiceDaVirgula;
        if (indiceAntesDaVirgula == -1) {
            indiceAntesDaVirgula = numeroParaFormatar.length;
        }
        else {
            numeroDepoisDaVirgula = numeroParaFormatar.substring(indiceDaVirgula, numeroParaFormatar.length);
        }

        var numeroAntesDaVirgula = numeroParaFormatar.substring(0, indiceAntesDaVirgula);

        if (casasAntesDavirgula != "" && numeroAntesDaVirgula.length > casasAntesDavirgula)
            numeroAntesDaVirgula = numeroAntesDaVirgula.substring(0, casasAntesDavirgula);

        if (usarSeparador)
            numeroAntesDaVirgula = formatarComPonto(numeroAntesDaVirgula);

        var valorFormatado = "";

        if (casasDecimais > 0 && numeroDepoisDaVirgula != "") {
            if (numeroDepoisDaVirgula.length > casasDecimais)
                numeroDepoisDaVirgula = numeroDepoisDaVirgula.substring(0, casasDecimais);

            valorFormatado = numeroAntesDaVirgula + teclaSeparador + numeroDepoisDaVirgula;
        }
        else
            if (indiceDaVirgula != -1 && casasDecimais > 0) {
                valorFormatado = numeroAntesDaVirgula + teclaSeparador;
            }
            else {
                valorFormatado = numeroAntesDaVirgula;
            }

        campo.value = valorFormatado;

        if (ultimaPosicao) {
            var diferenca = numeroAntesDaVirgula.length - quantidadeInicialAntesDaVirgula;
            posicaoCursor += diferenca;
        }
        else {
            var ultimaPosicaoDoCursor = campo.value.substring(posicaoCursor - 1, posicaoCursor);
            if (ultimaPosicaoDoCursor == ".")
                posicaoCursor++;
        }

        setCaretPosition(campo, posicaoCursor);
    }

}



function doGetCaretPosition(ctrl) {
    var CaretPos = 0;
    // IE Support     
    if (document.selection) {
        ctrl.focus();
        var Sel = document.selection.createRange();
        Sel.moveStart('character', -ctrl.value.length);
        CaretPos = Sel.text.length;
    }
    // Firefox support
    else
        if (ctrl.selectionStart || ctrl.selectionStart == '0')
            CaretPos = ctrl.selectionStart; return (CaretPos);
}

function setCaretPosition(ctrl, pos) {
    if (ctrl.setSelectionRange) {
        ctrl.focus();
        ctrl.setSelectionRange(pos, pos);
    }
    else if (ctrl.createTextRange) {
        var range = ctrl.createTextRange();
        range.collapse(true);
        range.moveEnd('character', pos);
        range.moveStart('character', pos);
        range.select();
    }
}

function replaceAll(string, valorAntigo, valorNovo) {
    while (string.indexOf(valorAntigo) != -1) {
        string = string.replace(valorAntigo, valorNovo);
    }
    return string;
}

function formatarComPonto(valor) {
    var resto = valor.length % 3;
    var quant = parseInt(valor.length / 3);

    var array = new Array();

    array.push(valor.substring(0, resto));

    var primeiraPosicao = resto;
    for (i = 0; i < quant; i++) {
        var ultimaPosicao = primeiraPosicao + 3;
        var v = valor.substring(primeiraPosicao, ultimaPosicao)
        array.push(v);
        primeiraPosicao += 3;
    }

    if (array != null && array.length > 0 && array[0] == "")
        array.shift();

    valor = array.join(".");

    return valor;
}

function PadLeft(value, tamanho, caracter) {
    var contador = value.length;

    if (value.length != tamanho) {
        do {
            value = caracter + value;
            contador += 1;

        } while (contador < tamanho)
    }

    return value;
}

function PadRight(value, tamanho, caracter) {
    var contador = value.length;

    if (value.length != tamanho) {
        do {
            value = value + caracter;
            contador += 1;

        } while (contador < tamanho)
    }

    return value;
}

function ForcaTextChanged(textbox) {

    if (textbox.defaultValue != textbox.value)
        setTimeout("__doPostBack('" + textbox.id + "','')", 0);
}


function FormatarCampoHoraMinuto(campo, casasAntesDosMinutos) {
    var posicaoCursor = doGetCaretPosition(campo);

    var quantidadeInicialAntesMinutos = BuscarQuantidadeInicialAntesDosMinutos(campo);

    var ultimaPosicao = UltimaPosicao(campo, posicaoCursor);

    var idTeclaPrecionada = event.keyCode;
    if (idTeclaPrecionada != 37 && idTeclaPrecionada != 39) // <- ->
    {
        var numeroParaFormatar = campo.value;

        var indiceMinutos = numeroParaFormatar.indexOf(":");

        numeroParaFormatar = FormatClean(numeroParaFormatar);

        var numeroDepoisMinutos = "";

        var casasDecimais = 2;

        var indiceAntesMinutos = indiceMinutos;
        if (indiceAntesMinutos == -1) {
            indiceAntesMinutos = numeroParaFormatar.length;
        }
        else {
            numeroDepoisMinutos = numeroParaFormatar.substring(indiceMinutos, numeroParaFormatar.length);
        }

        var numeroAntesMinutos = numeroParaFormatar.substring(0, indiceAntesMinutos);

        if (casasAntesDosMinutos != "" && numeroAntesMinutos.length > casasAntesDosMinutos)
            numeroAntesMinutos = numeroAntesMinutos.substring(0, casasAntesDosMinutos);

        var valorFormatado = "";

        if (casasDecimais > 0 && numeroDepoisMinutos != "") {
            if (numeroDepoisMinutos.length > casasDecimais)
                numeroDepoisMinutos = numeroDepoisMinutos.substring(0, casasDecimais);

            valorFormatado = numeroAntesMinutos + ":" + numeroDepoisMinutos;
        }
        else
            if (indiceMinutos != -1 && casasDecimais > 0) {
                valorFormatado = numeroAntesMinutos + ":";
            }
            else {
                valorFormatado = numeroAntesMinutos;
            }

        campo.value = valorFormatado;

        if (ultimaPosicao) {
            var diferenca = numeroAntesMinutos.length - quantidadeInicialAntesMinutos;
            posicaoCursor += diferenca;
        }
        else {
            var ultimaPosicaoDoCursor = campo.value.substring(posicaoCursor - 1, posicaoCursor);
            if (ultimaPosicaoDoCursor == ".")
                posicaoCursor++;
        }

        setCaretPosition(campo, posicaoCursor);
    }

}

function BuscarQuantidadeInicialAntesDosMinutos(campo) {
    var indiceAntesDaMinutos = campo.value.indexOf(":");
    if (indiceAntesDaMinutos == -1)
        indiceAntesDaMinutos = campo.value.length;

    var numeroAntesDaMinutos = campo.value.substring(0, indiceAntesDaMinutos);

    return numeroAntesDaMinutos.length;
}
