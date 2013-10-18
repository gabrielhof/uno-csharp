function createHttpRequest() {
    var httpRequest = null;
    
    if (window.XMLHttpRequest) {
        httpRequest = new XMLHttpRequest();
    } else {
        httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
    }

    return httpRequest
}

function atualizacaoAutomatica(timeout, callback) {
    window.setInterval(function () {
        var httpRequest = createHttpRequest();
        httpRequest.open("POST", "WebService.asmx/FoiAtualizado", false);
        httpRequest.send();

        var xmlResponse = httpRequest.responseXML;
        if (xmlResponse.childNodes[0].childNodes[0].nodeValue == "true") {
            callback();
        }

    }, timeout);
}