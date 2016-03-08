declare var $: any;
declare var google: any;
declare var map: any;

//Address class which im not using
class Address {
    line1: string;
    line2: string;
    city: string;
    state: string;
    zip: number;
}

//show details of the event clicked in the event list
function showDetails(id: number) {
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
    });
};

$('Form').submit(function(e) {
    e.preventDefault();
    
    var inputs = $('#editDetailForm :input');
    var values = {};
    inputs.each(function () {
        values[this.name] = $(this).val();
    });
    var url = '/Event/Edit/' + values['ID'];
    $.ajax({
        type: "POST",
        url: url,
        data: values,
        success: function(result) {
            showDetails(values['ID']);
        }
    });
});

//Highlight the event click in the event list
$('.eventContainer').on('click', function () {
    $('#EventListDiv>div .panel-primary').removeClass("panel-primary");
    $(this).addClass("panel-primary");
});

//load the edit screen of the event when the "edit" button is clicked
function loadEditScreen(id: number) {
    var url = '/Event/Edit/' + id;
    $('#DetailsContainer').load(url);
    $('#map').addClass('hidden');
}


//----------------------------Google Maps---------------------------------//

//this function loads the google maps onto the page
function initMap(latitude: string, longitude: string, zoom: number, exist:boolean) {
//assign lat and long to a google variable
    var myLatlng = new google.maps.LatLng(parseFloat(latitude), parseFloat(longitude));
    //give the map the settings we want
    var mapOptions = {
        center: myLatlng,
        zoom: zoom
    };
    //loads the map
    map = new google.maps.Map(document.getElementById('map'), mapOptions);
}
    

//get coordinates of the address passed to google
function getCoor() {
    var address = $('#addressElem').text();
    //initialize the function that gets the google coordinates
    var coor = new google.maps.Geocoder();
    coor.geocode({ address: address }, function (results, status:string) {
        if (status == google.maps.GeocoderStatus.OK) {
            var lat = results[0].geometry.location.lat();
            var lng = results[0].geometry.location.lng();
            initMap(lat, lng, 16, true);
            //center the map over the result
            map.setCenter(results[0].geometry.location);
            //place a marker at the location
            var marker = new google.maps.Marker(
                {
                    map: map,
                    position: results[0].geometry.location
                });
            if (results[0].geometry.viewport)
                map.fitBounds(results[0].geometry.viewport);
        } else {
            console.log('Geocode was not successful for the following reason: ' + status);
        }
    });
    
}

//----------------------------Google Maps End---------------------------------//





