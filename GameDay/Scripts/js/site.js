function showDetails(id) {
    var url = '/Event/Details/' + id;
    $('#DetailsContainer').load(url);
}
;
$('.eventContainer').on('click', function () {
    $('#EventListDiv>div .panel-primary').removeClass("panel-primary");
    $(this).addClass("panel-primary");
});
function loadEditScreen(id) {
    var url = '/Event/Edit/' + id;
    $('#DetailsContainer').load(url);
}
$(function () {
    var myhub = $.connection.gameDayHub;
    //myhub.client.hello = function (name) {
    //    alert("Hello " + name);
    //};
    $.connection.hub.start().done(function () {
    });
});
//# sourceMappingURL=site.js.map