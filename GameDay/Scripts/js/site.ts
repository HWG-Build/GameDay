declare var $: any;

function showDetails(id: number) {
    var url = '/Event/Details/'+id;
    $('#DetailsContainer').load(url);
}

function loadEditScreen(id: number) {
    var url = '/Event/Edit/' + id;
    $('#DetailsContainer').load(url);
}


