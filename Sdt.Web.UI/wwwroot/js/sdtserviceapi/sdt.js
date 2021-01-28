var MySdt = MySdt || {};

//IIFE
MySdt.ApiService = (function() {

    var baseApiServiceUrl = "https://localhost:44319/api/";
    var apiServiceUrlSpruch = baseApiServiceUrl + "sprueche/";

    var getSpruchDesTages = function () {
        return $.getJSON(apiServiceUrlSpruch + "randomsdt");
    };

    return {
        getSpruchDesTages: getSpruchDesTages
    };
})();

MySdt.SpruchDesTages = function() {
    var $autor = $("#autor"),
        $beschreibung = $("#beschreibung"),
        $spruch = $("#spruch"),
        $geburtsdatum = $("#geburtsdatum"),
        $bild = $("#bild");

    var renderData = function(data) {
        //console.table(data);
        $autor.html(data.autorName);
        $beschreibung.html(data.autorBeschreibung);
        $spruch.html(data.spruchText);
        $geburtsdatum.html(new Date(data.autorGeburtsdatum).toLocaleDateString());

        $bild.html(!data.autorBildType ? "<img src='https://via.placeholder.com/150' />" : "<img src='data:" + data.autorBildType + ";base64," + data.autorBild + "'/>");
    };

    var callService = function () {
        MySdt.ApiService.getSpruchDesTages().done(renderData);
    };

    return {
        init: callService
    };
}();