var map;
var Address = (function () {
    function Address() {
    }
    return Address;
})();
function showDetails(id) {
    $('#map').removeClass('hidden');
    var url = '/Event/Details/' + id;
    $.ajax({
        type: "GET",
        url: url,
        data: null,
        success: function (result) {
            $('#DetailsContainer').html(result);
            getCoor();
        },
        error: function (req, status, error) {
            // do something with error   
        }
    });
}
;
$('.eventContainer').on('click', function () {
    $('#EventListDiv>div .panel-primary').removeClass("panel-primary");
    $(this).addClass("panel-primary");
});
function loadEditScreen(id, line1, line2, city, state, zip) {
    var url = '/Event/Edit/' + id;
    $('#DetailsContainer').load(url);
    $('#map').addClass('hidden');
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
    console.log('hello');
    var address = $('#addressElem').text();
    var coor = new google.maps.Geocoder();
    coor.geocode({ address: address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            var lat = results[0].geometry.location.lat();
            var lng = results[0].geometry.location.lng();
            initMap(lat, lng, 16, true);
            map.setCenter(results[0].geometry.location); //center the map over the result
            //place a marker at the location
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });
            if (results[0].geometry.viewport)
                map.fitBounds(results[0].geometry.viewport);
        }
        else {
            console.log('Geocode was not successful for the following reason: ' + status);
        }
    });
}
