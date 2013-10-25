function createHttpRequest() {
    var httpRequest = null;
    
    if (window.XMLHttpRequest) {
        httpRequest = new XMLHttpRequest();
    } else {
        httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
    }

    return httpRequest
}

function atualizacaoAutomatica(timeout, callback, url) {
    if (typeof (url) == "undefined" || url == null) {
        url = "WebService.asmx/FoiAtualizado";
    }

    window.setInterval(function () {
        var httpRequest = createHttpRequest();
        httpRequest.open("POST", url, false);
        httpRequest.send();

        var xmlResponse = httpRequest.responseXML;
        if (xmlResponse.childNodes[0].childNodes[0].nodeValue == "true") {
            callback();
        }

    }, timeout);
}