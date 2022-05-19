// Initialize and add the map
function initMap() {
    // The location of SanDiego
    const SanDiego = { lat: 32.9580544, lng: -117.2307968 };
    const Hollywood = { lat: 34.09829, lng: -118.3580 };
    const LasVegas = { lat: 36.174465, lng: -115.139830 };
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("map"), {
      zoom: 4,
      center: SanDiego,
    });
    // The marker, positioned at SanDiego
    const marker = new google.maps.Marker({
      position: SanDiego,
      map: map,
    });
    const marker2 = new google.maps.Marker({
        position: Hollywood,
        map: map,
    });
    const marker3 = new google.maps.Marker({
        position: LasVegas,
        map: map,
    });
  }
  
  window.initMap = initMap;