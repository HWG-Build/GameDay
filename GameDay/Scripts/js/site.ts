declare var $: any;
declare var google: any;
var map;
var map2;

function showDetails(id: number) {
    var url = '/Event/Details/' + id;
    $('#DetailsContainer').load(url);
};

$('.eventContainer').on('click', function () {
    $('#EventListDiv>div .panel-primary').removeClass("panel-primary");
    $(this).addClass("panel-primary");
});

function loadEditScreen(id: number) {
    var url = '/Event/Edit/' + id;
    $('#DetailsContainer').load(url);
}

function initMap() {
    map = new google.maps.Map(document.getElementById('googlemapDetail'), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 8
    });
    
    map2 = new google.maps.Map(document.getElementById('googlemapEdit'), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 8
    });
}