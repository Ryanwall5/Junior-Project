

function computeTotalDistance() {

    google.maps.geometry.spherical.computeDistanceBetween(locations[i - 1], locations[i]);

}

window.onload = function () {
    var mapOptions = {
        center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
        zoom: 16,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    //console.log("Latitude:  " + markers[0].lat);
    //console.log("longitude:  " + markers[0].lng);
    var infoWindow = new google.maps.InfoWindow();
    var map = new google.maps.Map(document.getElementById("googlemap"), mapOptions);
    for (i = 0; i < markers.length; i++) {
        var data = markers[i];
        var myLatlng = new google.maps.LatLng(data.lat, data.lng);
        var marker = new google.maps.Marker({

            position: myLatlng,
            map: map,
            title: data.title
        });
        (function (marker, data) {
            google.maps.event.addListener(marker,
                "click",
                function (e) {
                    infoWindow.setContent(data.title, data.description);
                    infoWindow.open(map, marker);
                });
        })(marker, data);
    }

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(displayLocation);
    } else {
        alert("Sorry, this browser doesn't support geolocation!");
    }


    //var locations = [];
    function displayLocation(position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;

        var mylocation = new google.maps.LatLng(
            latitude,
            longitude);
        var storelocation = new google.maps.LatLng(markers[0].lat, markers[0].lng);

        var d = google.maps.geometry.spherical.computeDistanceBetween(mylocation, storelocation) / 1609.34;

        var pLocation = document.getElementById("location");
        pLocation.innerHTML += "Distance Between you and " + data.title + " is " + d.toFixed(2) + " miles";

    }

}