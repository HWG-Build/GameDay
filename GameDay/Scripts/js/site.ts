declare var $: any;

function showDetails(id: number) {
    var url = '/Event/Details/' + id;
    $('#DetailsContainer').load(url);
};

function loadEditScreen(id: number) {
    var url = '/Event/Edit/' + id;
    $('#DetailsContainer').load(url);
}


$(function () {
    $.connection.hub.logging = true;
    var myhub = $.connection.gameDayHub;

    //myhub.client.hello = function (name) {
    //    alert("Hello " + name);
    //};

    $.connection.hub.start().done(function () {
    });
});