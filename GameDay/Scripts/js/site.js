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
//# sourceMappingURL=site.js.map