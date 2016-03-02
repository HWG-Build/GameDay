var map;
function showDetails(id, line1, line2, city, state, zip) {
    var url = '/Event/Details/' + id;
    $('#DetailsContainer').load(url);
}
;
$('.eventContainer').on('click', function () {
    $('#EventListDiv>div .panel-primary').removeClass("panel-primary");
    $(this).addClass("panel-primary");
});
function loadEditScreen(id, line1, line2, city, state, zip) {
    var url = '/Event/Edit/' + id;
    $('#DetailsContainer').load(url);
}
function initMap(latitude, longitude, zoom, exist) {
    var myLatlng = new google.maps.LatLng(parseFloat(latitude), parseFloat(longitude));
    var mapOptions = {
        center: myLatlng,
        zoom: parseInt(zoom)
    };
    map = new google.maps.Map(document.getElementById('map'), mapOptions);
    if (exist == true) {
        var marker = new google.maps.Marker({
            map: map,
            position: myLatlng
        });
    }
}
function getCoor() {
    var address = $('#addressLine1').val() + " " + $('#addressLine2').val() + ", " + $('#city').val() + ", " + $('#state').val() + " " + $('#zip').val();
    var coor = new google.maps.Geocoder();
    coor.geocode({ address: address }, function (results, status) {
        console.log(results);
        if (status == google.maps.GeocoderStatus.OK) {
            var cntl = {
                lat: lat,
                lng: lng
            };
            var ;
            var ;
        }
        ;
        map.setCenter(results[0].geometry.location); //center the map over the result
        //place a marker at the location
        var marker = new google.maps.Marker({
            map: map,
            position: results[0].geometry.location
        });
        cntl.submitData();
        if (results[0].geometry.viewport)
            sabio.page.map.fitBounds(results[0].geometry.viewport);
    }, {
        alert: function () { }, 'Geocode was not successful for the following reason: ': +status });
}
;
//sabio.page.loadGoogleMaps = function (lat, lng, zoom, exist) {
//    var myLatlng = new google.maps.LatLng(parseFloat(lat), parseFloat(lng));
//    var mapOptions = {
//        center: myLatlng,
//        zoom: parseInt(zoom)
//    };
//    sabio.page.map = new google.maps.Map(document.getElementById('map'), mapOptions);
//    if (exist == true) {
//        var marker = new google.maps.Marker({
//            map: sabio.page.map,
//            position: myLatlng
//        });
//    }
//}
//D: \Workspaces\C07\Sabio.Web\Views\Address\AddressIndex.cshtml(151):                        sabio.page.loadGoogleMaps(viewModel.item.lat, viewModel.item.lng, 16, true);
