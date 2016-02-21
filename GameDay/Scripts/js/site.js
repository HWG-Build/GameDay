function showDetails(id) {
    var url = '/Event/Details/' + id;
    $('#DetailsContainer').load(url);
}
function loadEditScreen(id) {
    var url = '/Event/Edit/' + id;
    $('#DetailsContainer').load(url);
}
//# sourceMappingURL=site.js.map